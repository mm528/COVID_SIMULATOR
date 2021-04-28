using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test_Customer : MonoBehaviour
{

    public GameObject[] CustomersLis;
    public float d;
        void Start(){
                       
        }

        void Update(){
                 CustomersLis = GameObject.FindGameObjectsWithTag("Customer");
                d = Random.Range(0, 100000f);
        if (d < 10 && CustomersLis.Length <= 30)
        {

            GameObject go1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go1.transform.SetParent(GameObject.Find("ListOfCustomers").transform);
            int counterObject = Random.Range(9, 100);
            go1.name = "Customer" + counterObject;
            go1.AddComponent<Rigidbody>();

            go1.AddComponent<NavMeshAgent>();
            go1.AddComponent<Player>();
            // Debug.Log(Agent);
            Customers k = go1.AddComponent<Customers>();

            k.Agent = go1.GetComponent<NavMeshAgent>();

            k.transform.localScale = new Vector3(4, 3, 4);

            k.transform.position = new Vector3(0, -3, -156);

            k.tag = "Customer";
            k.moveSpeed = 15f;

            go1.AddComponent<Transform>();
            go1.GetComponent<Rigidbody>().useGravity = true;


        }



        }
    

}
