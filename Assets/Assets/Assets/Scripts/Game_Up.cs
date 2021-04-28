using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;
public class Game_Up : MonoBehaviour
{


    public GameObject[] CustomersLis;

    public GameObject[] CustomerMask;



    public GameObject[] CustomerInfected;

    public GameObject[] allObejctOneList;

    public GameObject[] KidsList;
    public GameObject mask;
    public int maskInteger;
    public GameObject infected;
    public int infectedInteger;
    public GameObject customer;
    public int customerInteger;
    public int splitValue;
    public bool NotEnterToCreateGraph = true;


    


    public int intLeghtCustomer;
    public int intLeghtMask;
    public int intLeghtInfected;


    public int totalALLCust;

    public Text InfectedResults;

    public Text HealthCustomersResults;

    public float spawnProbability = 0.1f;
    public float kremain = 2;
    public bool answer;
    public int cc = 0;
    public int remainWEdontknow =0;
    public Slider slide1;
    public int previousValueCustomerInteger = 0;

    public Slider percentageNormalCustomer;
    public Slider percentageMaskCustomer;
    public Slider percentageInfectors;


    public float d;
    public float pithanotitaNormalCustomer;
    public float pithanotitaMaskCustomer;
    public float pithanotitaInfectorsCustomer;

    public int newCustomersNumber;
    public float maxValues;

    public Text NoOf;
    public int NumOfCust;
    public Text NoOfInf;

    public Text InfectionPerc;

    public bool controlAfter = false;
    public int counterGetIn = 0;
    public GameObject Maskobj;
    public GameObject InfectorsObj;
    public GameObject WithoutMask;
    public bool changeBoolcc = true;
    public GameObject getGraph; 
    void Awake()
    {
        pithanotitaNormalCustomer = float.Parse(percentageNormalCustomer.value.ToString());
        pithanotitaMaskCustomer = float.Parse(percentageMaskCustomer.value.ToString());
        pithanotitaInfectorsCustomer = float.Parse(percentageInfectors.value.ToString());
    }
    void Start()
    {
        newCustomersNumber = 0;
        answer = false;
        customerInteger = 0;
   
        maskInteger = 0;
        infectedInteger = 0;

        /*
            We need to hide all the checkpoints in the Game.
        */

        for (int i = 0; i <= 16; i++)
        {
            GameObject.Find("" + i).GetComponent<Renderer>().enabled = false;
        }
        GameObject.Find(""+ (-1)).GetComponent<Renderer>().enabled = false;

        getGraph = GameObject.FindGameObjectWithTag("W");

        /*
        Prepared all the lists to collect all the infromation about our customer
        */
        CustomersLis = GameObject.FindGameObjectsWithTag("Customer");
        CustomerInfected = GameObject.FindGameObjectsWithTag("Infected");
        CustomerMask = GameObject.FindGameObjectsWithTag("Mask");
      

        var MasterList = CustomersLis.Union(CustomerInfected).Union(CustomerMask).ToList();

        NumOfCust = MasterList.Count;
        NoOf.text = NumOfCust.ToString();
        NoOfInf.text = CustomerInfected.Length.ToString();
            if (NumOfCust > 0)
            {
                    float temp = Mathf.FloorToInt(CustomerInfected.Length / NumOfCust);
                    InfectionPerc.text = temp.ToString() + "%";

                }
            else
            {
                InfectionPerc.text = "0" + "%";
            }





    }

    void Update()
    {
 
       
        

        NumOfCust = CustomersLis.Length + CustomerInfected.Length + CustomerMask.Length;
        NoOf.text = NumOfCust.ToString();
        NoOfInf.text = CustomerInfected.Length.ToString();
            if (NumOfCust > 0)
            {

                float temp = ((CustomerInfected.Length * 100 / NumOfCust));

                InfectionPerc.text = temp.ToString() + "%";
            // Debug.Log(temp);
            }
            else
            {
                InfectionPerc.text = "0" + "%";
            }



        /*
            Values from the Scroll Bars
        */
        previousValueCustomerInteger = customerInteger;
        customerInteger = int.Parse(slide1.value.ToString());
        pithanotitaNormalCustomer = float.Parse(percentageNormalCustomer.value.ToString());
        pithanotitaMaskCustomer = float.Parse(percentageMaskCustomer.value.ToString());
        pithanotitaInfectorsCustomer = float.Parse(percentageInfectors.value.ToString());

        //All elemetns from the list all together
        var MasterList = CustomersLis.Union(CustomerInfected).Union(CustomerMask).ToList();

                /*
                    Check the possibilities whereas the values are 0 or have a value on the scrol bar.
                    
                */

            if (customerInteger != previousValueCustomerInteger && percentageInfectors.value != 0.0f)
            {
                counterGetIn++;
                if (counterGetIn == 1)
                {
                    createCustomer();
                }

            }
            else if (customerInteger != previousValueCustomerInteger && percentageNormalCustomer.value != 0.0f)
            {
                counterGetIn++;
                if (counterGetIn == 1)
                {
                    createCustomer();
                }

            }


        /*

            While running game we need to update the customer walk-in the game
        */

        if (customerInteger != previousValueCustomerInteger && controlAfter == true)
        {
            changeBoolcc = false;
            if (customerInteger >= previousValueCustomerInteger)
                    {
                         changeBoolcc = true;
                         newCustomersNumber = (customerInteger - MasterList.Count);

                         createCustomerAfter();
                         NotEnterToCreateGraph= true;
                      }
            else if (customerInteger != 0 && previousValueCustomerInteger > customerInteger)
                    {
                        changeBoolcc = false;
                        NotEnterToCreateGraph= true;

                        newCustomersNumber = previousValueCustomerInteger - customerInteger;
                         float percentageCustomerNormal;
                         float percentageCustomerMask;
                        float percentageCustomerInfectors;
                            if (previousValueCustomerInteger !=0){
                         percentageCustomerNormal = (float)intLeghtCustomer / (float)previousValueCustomerInteger;
                            }else{
                                 percentageCustomerNormal=0;
                                 }
                            if (previousValueCustomerInteger!=0){
                          percentageCustomerMask = (float)intLeghtMask/ (float)previousValueCustomerInteger;
                            }else{
                                percentageCustomerMask = 0;
                            }
                            if (previousValueCustomerInteger!=0){
                            percentageCustomerInfectors = (float) intLeghtInfected/ (float)previousValueCustomerInteger;

                            }else{
                                  percentageCustomerInfectors=0;
                            }
                            int ValueAfterReduce = previousValueCustomerInteger - customerInteger;
                            /*

                            Find the percentafe of people need to reduce inside the game.Take it statisticly
                            Every value counts on the game

                            */

                            float normalCustomerTakeout = Mathf.Round(percentageCustomerNormal * newCustomersNumber);
                            float normalMaskTakeout = Mathf.Round(percentageCustomerMask * newCustomersNumber);
                                float  normalInfectorTakeout = Mathf.Round(percentageCustomerInfectors * newCustomersNumber);


                            Debug.Log("The previous Value INteger is : " + previousValueCustomerInteger);
                            Debug.Log("Percentage Customer Normal = :"+ percentageCustomerNormal);
                            Debug.Log("Percentage Mask Normal = :"+ percentageCustomerMask);
                                Debug.Log("Percentage Infectors  = :"+ percentageCustomerInfectors);
                                
                                Debug.Log("Customer Normal = :"+ normalCustomerTakeout);
                            Debug.Log(" Mask Normal = :"+ normalMaskTakeout);
                                Debug.Log(" Infectors  = :"+ normalInfectorTakeout);


                                 if (CustomersLis.Length != 0)
                                      {
                                    for (int i = 0; i < normalCustomerTakeout; i++)
                                    {

                                        CustomersLis[i].GetComponent<Customers>().timeRemaining = 0;
                                    }
                                    }
                                if (CustomerInfected.Length != 0)
                                     {
                                            for (int i = 0; i < normalMaskTakeout; i++)
                                            {

                                                CustomerMask[i].GetComponent<Customers>().timeRemaining = 0;
                                            }

                                                 }
                                if (CustomerMask.Length != 0)
                                {
                                            for (int i = 0; i < normalInfectorTakeout; i++)
                                            {

                                                CustomerInfected[i].GetComponent<Customers>().timeRemaining = 0;
                                            }
                                }
       

            }
            else
            {
            /*

            In case the user Want 0 customer in the game(Like reset)
            */
            newCustomersNumber = 0;
            answer = false;
            customerInteger = 0;
    
            maskInteger = 0;
            infectedInteger = 0;
            changeBoolcc = false;
            previousValueCustomerInteger = 0;
            splitValue =0;

               
                            if (CustomersLis.Length != 0)
                            {
                                for (int i = 0; i < CustomersLis.Length; i++)
                                {

                                    CustomersLis[i].GetComponent<Customers>().timeRemaining = 0;
                                }
                            }
                            if (CustomerInfected.Length != 0)
                            {
                                for (int i = 0; i < CustomerInfected.Length; i++)
                                {

                                    CustomerInfected[i].GetComponent<Customers>().timeRemaining = 0;
                                }

                            }
                            if (CustomerMask.Length != 0)
                            {
                                for (int i = 0; i < CustomerMask.Length; i++)
                                {

                                    CustomerMask[i].GetComponent<Customers>().timeRemaining = 0;
                                }
                            }
                         
                              getGraph.GetComponent<windowGraph>().DeleteAllDots();
                              NotEnterToCreateGraph = false;
                              getGraph.GetComponent<windowGraph>().number = true;
                             
                          
                        }
                    



        }

        if (NotEnterToCreateGraph == true){
        getGraph.GetComponent<windowGraph>().ChangeGraph(CustomerInfected.Length);
        }

        if (cc >= 1)
        {
         
            createCustomerAfterDestroy();

        }


        CustomersLis = GameObject.FindGameObjectsWithTag("Customer");
        CustomerInfected = GameObject.FindGameObjectsWithTag("Infected");
        CustomerMask = GameObject.FindGameObjectsWithTag("Mask");

        intLeghtCustomer = CustomersLis.Length;

        intLeghtInfected = CustomerInfected.Length;
        intLeghtMask = CustomerMask.Length;




    }

    public void createCustomer()
    {

        StartCoroutine(CreateObjects());


    }
        /*

            Create the capsules in the game
            Giving a delay while entering the scene
            Random range
            Each door has a possibility split into 3 kinds of customers


        */
    public IEnumerator CreateObjects()
    {

        WaitForSeconds wait = new WaitForSeconds(Random.Range(1f, 5f));


        for (int i = 0; i < customerInteger; i++) // edw ginete *2 why?
        {

            customerInteger = int.Parse(slide1.value.ToString());
            float randomVal = Random.value;
            if (randomVal < 0.5) //PILI!
            {
                float p = Random.value;

                if (p < percentageNormalCustomer.value) //KANONIKI CUS
                {

                    var objectCustomer = Instantiate(customer, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                    Infector properties = customer.GetComponent<Infector>();
                    objectCustomer.transform.parent = WithoutMask.transform;

                }
                else if (p < percentageMaskCustomer.value + percentageNormalCustomer.value) //MASKES
                {
                    var objectMask = Instantiate(mask, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                    Infector properties = mask.GetComponent<Infector>();
                    properties.hasMask = true;
                    objectMask.transform.parent = Maskobj.transform;
                }
                else if (p < percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value) // INFECTORS 
                {
                    var objectInfector = Instantiate(infected, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                    Infector properties = infected.GetComponent<Infector>();
                    properties.isInfected = true;
                    objectInfector.transform.parent = InfectorsObj.transform;
                }


            }
            else if (randomVal < 0.8)
            {
                float p = Random.value;
                if (p < percentageNormalCustomer.value)
                {
                    var objectCustomer = Instantiate(customer, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                    Infector properties = customer.GetComponent<Infector>();
                    objectCustomer.transform.parent = WithoutMask.transform;
                }
                else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectMask = Instantiate(mask, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                    Infector properties = mask.GetComponent<Infector>();
                    properties.hasMask = true;
                    objectMask.transform.parent = Maskobj.transform;
                }
                else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectInfector = Instantiate(infected, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                    Infector properties = infected.GetComponent<Infector>();
                    properties.isInfected = true;
                    objectInfector.transform.parent = InfectorsObj.transform;
                }

            }
            else
            {
                float p = Random.value;
                if (p < percentageNormalCustomer.value)
                {
                    var objectCustomer = Instantiate(customer, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                    Infector properties = customer.GetComponent<Infector>();
                    objectCustomer.transform.parent = WithoutMask.transform;
                }
                else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectMask = Instantiate(mask, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                    Infector properties = mask.GetComponent<Infector>();
                    properties.hasMask = true;
                    objectMask.transform.parent = Maskobj.transform;
                }
                else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectInfector = Instantiate(infected, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                    Infector properties = infected.GetComponent<Infector>();
                    properties.isInfected = true;
                    objectInfector.transform.parent = InfectorsObj.transform;
                }






            }
            yield return wait;
        }
        controlAfter = true;

    }
    public void createCustomerAfter()
    {


        StartCoroutine(CreateC());
        newCustomersNumber -= 1;


    }
    public void createCustomerAfterDestroy()
    {


        StartCoroutine(createAfterDestroyObject());


    }

/*

    In case we would like looping customers get inside the scene. 1 CUSTOMER destory another comes in
    With a a delay of 3f
    Accordigly with doors and properties of the customer
*/
    public IEnumerator CreateC()
    {
        WaitForSeconds wait = new WaitForSeconds(3f);
        for (int i = 0; i <= newCustomersNumber; i++)
        {
            float randomVal = Random.value;
            if (randomVal < 0.5)
            {
                float p = Random.value;
                if (p < percentageNormalCustomer.value)
                {

                    var objectCustomer = Instantiate(customer, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                    Infector properties = customer.GetComponent<Infector>();
                    objectCustomer.transform.parent = WithoutMask.transform;

                }
                else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectMask = Instantiate(mask, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                    Infector properties = mask.GetComponent<Infector>();
                    properties.hasMask = true;
                    objectMask.transform.parent = Maskobj.transform;
                }
                else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectInfector = Instantiate(infected, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                    Infector properties = infected.GetComponent<Infector>();
                    properties.isInfected = true;
                    objectInfector.transform.parent = InfectorsObj.transform;
                }


            }
            else if (randomVal < 0.8)
            {
                float p = Random.value;
                if (p < percentageNormalCustomer.value)
                {
                    var objectCustomer = Instantiate(customer, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                    Infector properties = customer.GetComponent<Infector>();
                    objectCustomer.transform.parent = WithoutMask.transform;
                }
                else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectMask = Instantiate(mask, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                    Infector properties = mask.GetComponent<Infector>();
                    properties.hasMask = true;
                    objectMask.transform.parent = Maskobj.transform;
                }
                else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectInfector = Instantiate(infected, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                    Infector properties = infected.GetComponent<Infector>();
                    properties.isInfected = true;
                    objectInfector.transform.parent = InfectorsObj.transform;
                }

            }
            else
            {
                float p = Random.value;
                if (randomVal < percentageNormalCustomer.value)
                {
                    var objectCustomer = Instantiate(customer, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                    Infector properties = customer.GetComponent<Infector>();
                    objectCustomer.transform.parent = WithoutMask.transform;

                }
                else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectMask = Instantiate(mask, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                    Infector properties = mask.GetComponent<Infector>();
                    properties.hasMask = true;
                    objectMask.transform.parent = Maskobj.transform;

                }
                else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
                {
                    var objectInfector = Instantiate(infected, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                    Infector properties = infected.GetComponent<Infector>();
                    properties.isInfected = true;
                    objectInfector.transform.parent = InfectorsObj.transform;
                }
            }


            yield return wait;



        }



    }

    /*
        Reset button, destory all elements inside the game
    */
    public void DestroyAllObjects()
    {
        
        for (int i = 0; i < CustomersLis.Length; i++)
        {
            if (CustomersLis[i] !=null){
            Destroy(CustomersLis[i].GetComponent<Customers>().gameObject);
            }

        }
        for (int i = 0; i < CustomerInfected.Length; i++)
        {
                 if (CustomerInfected[i] !=null){
            Destroy(CustomerInfected[i].GetComponent<Customers>().gameObject);
                 }
        }
        for (int i = 0; i < CustomerMask.Length; i++)
        {
if (CustomerMask[i] !=null){
            Destroy(CustomerMask[i].GetComponent<Customers>().gameObject);
        }
        }


            newCustomersNumber = 0;
            answer = false;
            customerInteger = 0;
            maskInteger = 0;
            infectedInteger = 0;
            changeBoolcc = true;
            previousValueCustomerInteger = 0;
            splitValue =0;

         getGraph.GetComponent<windowGraph>().DeleteAllDots();
         getGraph.GetComponent<windowGraph>().number = true;


    }

    public IEnumerator createAfterDestroyObject()
    {



        WaitForSeconds wait = new WaitForSeconds(0.1f);

        float randomVal = Random.value;
        if (randomVal < 0.5)
        {
            float p = Random.value;
            if (p < percentageNormalCustomer.value)
            {

                var objectCustomer = Instantiate(customer, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                Infector properties = customer.GetComponent<Infector>();
                objectCustomer.transform.parent = WithoutMask.transform;

            }
            else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
            {
                var objectMask = Instantiate(mask, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                Infector properties = mask.GetComponent<Infector>();
                properties.hasMask = true;
                objectMask.transform.parent = Maskobj.transform;
            }
            else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
            {
                var objectInfector = Instantiate(infected, GameObject.Find("entrance1").transform.position, Quaternion.identity);
                Infector properties = infected.GetComponent<Infector>();
                properties.isInfected = true;
                objectInfector.transform.parent = InfectorsObj.transform;
            }


        }
        else if (randomVal < 0.8)
        {
            float p = Random.value;
            if (p < percentageNormalCustomer.value)
            {
                var objectCustomer = Instantiate(customer, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                Infector properties = customer.GetComponent<Infector>();
                objectCustomer.transform.parent = WithoutMask.transform;
            }
            else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
            {
                var objectMask = Instantiate(mask, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                Infector properties = mask.GetComponent<Infector>();
                properties.hasMask = true;
                objectMask.transform.parent = Maskobj.transform;
            }
            else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
            {
                var objectInfector = Instantiate(infected, GameObject.Find("entrance2").transform.position, Quaternion.identity);
                Infector properties = infected.GetComponent<Infector>();
                properties.isInfected = true;
                objectInfector.transform.parent = InfectorsObj.transform;
            }

        }
        else
        {
            float p = Random.value;
            if (randomVal < percentageNormalCustomer.value)
            {
                var objectCustomer = Instantiate(customer, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                Infector properties = customer.GetComponent<Infector>();
                objectCustomer.transform.parent = WithoutMask.transform;

            }
            else if (p < (percentageMaskCustomer.value + percentageNormalCustomer.value))
            {
                var objectMask = Instantiate(mask, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                Infector properties = mask.GetComponent<Infector>();
                properties.hasMask = true;
                objectMask.transform.parent = Maskobj.transform;

            }
            else if (p < (percentageInfectors.value + percentageMaskCustomer.value + percentageNormalCustomer.value))
            {
                var objectInfector = Instantiate(infected, GameObject.Find("entrance3").transform.position, Quaternion.identity);
                Infector properties = infected.GetComponent<Infector>();
                properties.isInfected = true;
                objectInfector.transform.parent = InfectorsObj.transform;
            }
        }
        cc--;

        yield return wait;



    }



}
