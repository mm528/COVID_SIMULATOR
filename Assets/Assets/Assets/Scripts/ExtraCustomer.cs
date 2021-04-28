using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ExtraCustomer : MonoBehaviour
{
    private float nextFire = 0.0f;
    private float nextFire2 = 0.0f;
    private float fireRate = 0.5f;
    public Transform position;
    public NavMeshAgent Agent;
    public Vector3 myPos2;
    private float moveSpeed = 0.8f;
    private int count = 0;
    public GameObject[] extraCustomer;
    private int listnu = 0;
    private bool answer=true;
    public float SetTimerToBeInTheStore = 5f;
     public GameObject[] outsideCustomer;

    private GameObject[] allCustomerInTheStore;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        myPos2 = transform.position;

        // Agent.speed = 0;
        extraCustomer = GameObject.FindGameObjectsWithTag("ExtraC");
        //GameObject listC = gameObject.find("ListOfCustomers");
        
        //Debug.Log("Hey!!!!!!!!!!!!!!!!! " + allCustomerInTheStore.Length.ToString());
         //GameObject GameObject = Instantiate(allCustomerInTheStore.Find(x => x.name == "ObjectNameString")) as GameObject;
        extraCustomer[listnu].GetComponent<NavMeshAgent>().acceleration = 30f; //Change Speed in order to COME more Customer IN
        

    }

    // Update is called once per frame
    void Update()
    {
        allCustomerInTheStore = GameObject.FindGameObjectsWithTag("Customer");
        outsideCustomer = GameObject.FindGameObjectsWithTag("Outside");
        
        if (count == 9)
        {
            Debug.Log("Here");

            count = 0;
            // MoveToCheckpoint(GameObject.Find("" + count).transform.position);
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            nextFire2 = Time.time + fireRate;
        }
        if (nextFire > 3)
        {
            nextFire = 0;
            if (allCustomerInTheStore.Length-1 <= 4){
            if (listnu <= extraCustomer.Length-1)
            {
                 extraCustomer[listnu].GetComponent<NavMeshAgent>().speed = 30f; //Change Speed in order to COME more Customer IN
                 extraCustomer[listnu].GetComponent<NavMeshAgent>().acceleration = 20f; //Change Speed in order to COME more Customer IN
                 extraCustomer[listnu].GetComponent<NavMeshAgent>().angularSpeed = 8f; //Change Speed in order to COME more Customer IN
                 extraCustomer[listnu].GetComponent<Transform>().tag = "Customer"; // DAME ALLAZW TO EKSW CUSTOMER NA MPI STIN LISTA MESA STO DWMATION! ESTI METRO POSA ATOMA EHW MESA STON HWRO :)
                 MoveToCheckpoint(GameObject.Find("" + count).transform.position);
                 
            }else{
                answer = false;
                if (nextFire2 <= SetTimerToBeInTheStore){
                 MoveToCheckpoint(GameObject.Find("" + count).transform.position);
                }else{
                    ExitCustomer();
                }
            }

        }

          

        }
        







    }

    void MoveToCheckpoint(Vector3 point)
    {

        Vector3 myPos = transform.position;
        Vector3 difference = point - myPos;
        Vector3 direction = difference.normalized;


        transform.position += direction * Time.deltaTime * moveSpeed;
        //transform.rotation = Quaternion.LookRotation(direction);



        Agent.isStopped = false;
        Agent.SetDestination(point);


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("" + count))
        {
            if (answer == true){
            listnu++;
            };
            int previous = count;
            //Destroy(other);
            count = Random.Range(0, 8) + 1;
            while (count == previous)
            {
                count = Random.Range(0, 6);
            }
            // Debug.Log("Touch");
        };

        if (other.gameObject.name.Equals("-1")){
             gameObject.transform.tag = "Outside";
        }


    }


    void ExitCustomer(){
        Vector3  positionExit = GameObject.Find("-1").transform.position;
         Vector3 myPos = transform.position;
        Vector3 difference = positionExit - myPos;
        Vector3 direction = difference.normalized;
        

         transform.position += direction * Time.deltaTime * moveSpeed;
        transform.rotation = Quaternion.LookRotation(direction);

        Agent.isStopped = false;
        Agent.SetDestination(positionExit);
       
        //Debug.Log(outsideCustomer.Length);
        



    }
    

}
