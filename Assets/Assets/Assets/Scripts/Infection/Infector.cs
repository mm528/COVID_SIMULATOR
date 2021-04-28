using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infector : MonoBehaviour
{

    public bool hasMask;
    public float counter = 0;
    public bool isInfected = false;

    public bool nextToInfected = false;

    const float counterDropRate = 0.1f;
    Material material;
    public Customers customer;
    public GameObject getGraph; 
      public GameObject gameUp; 


    private void OnTriggerStay(Collider other)
    {
        Infector properties = other.GetComponent<Infector>();
        if (properties == null) return;
        if (!properties.isInfected) return;

        nextToInfected = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        getGraph = GameObject.FindGameObjectWithTag("W");
        gameUp = GameObject.FindGameObjectWithTag("A");
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;

        if (!hasMask)
            material.color = Color.black;
        else material.color = Color.blue;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (nextToInfected) {
            if (hasMask){
                counter = (counter + Time.deltaTime)-0.5f;
            }else{
            counter += Time.deltaTime;
            }
        }
        else if (counter>=0){
            counter -= Time.deltaTime * counterDropRate;

        }

        if( !isInfected && counter > 30.0f){
            isInfected = true;
           // Debug.Log("Infected");
            gameObject.tag = "Infected";
             getGraph.GetComponent<windowGraph>().ChangeGraph(gameUp.GetComponent<Game_Up>().CustomerInfected.Length);

            
        }
        
        if (isInfected){
            material.color = Color.red;
        
           
           
        }


        nextToInfected = false;
    }
}
