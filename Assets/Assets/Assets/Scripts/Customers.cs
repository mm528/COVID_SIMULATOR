using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customers : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform position;

    public NavMeshAgent Agent;
    public Vector3 myPos2; // Position Customer
    public float moveSpeed; //Speed of the Customer
    public int count; //Take each Checkpoint
    public float SetTimerToBeInTheStore = 0;

    public List<GameObject> players;
    private bool actriveMethod = true;

    private float nextFire = 0.0f;
    private float fireRate = 0.5f;
    public GameObject[] extraCustomer;
    public GameObject[] CustomersLis;
    public GameObject[] outsideCustomer;
    public int increaseNumberAfterTouchingFinalCheckpoint = 0;
    private bool letCustomerIn = true;
    public UnityEngine.Object prefab;
    public float d;
    public float duration = 0f;

    private Color currentColor;
    private Material materialColored;
    private int parentLj = 0;
    public float timeRemaining;

      public float maxInfectionProbability;
   public float minInfectionProbability;
   public float halftime;

    public GameObject Gameup;

public   float dekadiko;
public float findtime ;
public float finalINfection;
public GameObject cls;
public ParticleSystem particles;



    void Start()
    {
        
        particles.Stop();
        cls = GameObject.FindGameObjectWithTag("A");
        
         count = Random.Range(0,16);
       
            maxInfectionProbability = 0.34f;
            minInfectionProbability=0.06f;
           // halftime = 0.12f;


        Gameup = GameObject.FindGameObjectWithTag("Game");
        SetTimerToBeInTheStore = 10f;//Random.Range(5,25);
        timeRemaining = Random.Range(200, 300);

        float findtime = Mathf.Round(timeRemaining/60);
        
        if (findtime > 20 && findtime <= 30){
            dekadiko = 30 - findtime; 
            finalINfection = minInfectionProbability + (minInfectionProbability/dekadiko);
          
        } 

           if (findtime > 30 && findtime <= 60){
            dekadiko = 60 - findtime; 
            finalINfection = maxInfectionProbability - (maxInfectionProbability/dekadiko)-0.02f;
           
        } 




    }

    // Update is called once per frame
    void Update()
    {


        if (timeRemaining < 0)
        {

            MoveToCheckpoint(GameObject.Find("" + -1).transform.position);

        }
        else
        {
            if (count == 15)
            {
                count = 0;
            }

            MoveToCheckpoint(GameObject.Find("" + count).transform.position);
            timeRemaining -= Time.deltaTime;

        }
        Infector infd = gameObject.GetComponent<Infector>();
        if (infd.isInfected == false){
            particles.Play();
        }



    }

    void MoveToCheckpoint(Vector3 point)
    {

        Vector3 myPos = transform.position;
        Vector3 difference = point - myPos;
        Vector3 direction = difference.normalized;
        transform.position += direction * Time.deltaTime * moveSpeed;
        transform.rotation = Quaternion.LookRotation(direction);
        //Agent.isStopped = false;
        Agent.SetDestination(point);

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("" + count))
        {
            int previous = count;
            //Destroy(other);
            count = Random.Range(1, 15) + 1;
            while (count == previous)
            {
                count = Random.Range(0, 16);
            }

        }

        if (other.gameObject.name.Equals("-1"))
        {
          
            Destroy(gameObject);
            
           // Debug.Log(cls.GetComponent<Game_Up>().cc);
            if (cls.GetComponent<Game_Up>().changeBoolcc == true){
            cls.GetComponent<Game_Up>().cc = cls.GetComponent<Game_Up>().cc+1;
            }else{
                cls.GetComponent<Game_Up>().cc = 0;
            }
        
            // if (cls.GetComponent<Game_Up>().cc >= cls.GetComponent<Game_Up>().customerInteger ){
            //     cls.GetComponent<Game_Up>().cc =0;
            // }
            // Debug.Log(cls.GetComponent<Game_Up>().cc);
         //   Debug.Log("Object Desttroy");

        }

    }


}
