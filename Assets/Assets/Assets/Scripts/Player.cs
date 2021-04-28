using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   RaycastHit hit;
   RaycastHit hit1;  
   RaycastHit hit2;
   RaycastHit hit3;
  public float maxDist;
  public  float ExposureDistanceMeters;

   public float ExposureProbabilityAtZeroDistance;
   public float ExposureProbabilityAtMaxDistance;
   bool Expos = false;
   public Material mat ; 
   bool Healthy = true;
   public float mAsk  = 0f;
   public float co2;
   public bool maskware = false;
  public float maxInfectionProbability;
   public float minInfectionProbability;

   public Customers Customer;
   public float getValue ;

 

        void Start(){
            
            Customer = GetComponent<Customers>();
              getValue  = Customer.finalINfection;
              
            maxDist = 4f;
            ExposureDistanceMeters = 4;
        
            ExposureProbabilityAtZeroDistance = 0.5f + getValue/100;
            ExposureProbabilityAtMaxDistance = 0.0f +getValue/100 ;
            

        if(maskware == true){
        ExposureProbabilityAtZeroDistance = 0.2f;
        }
}

void Update(){
         
    
     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.green);
     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 3, Color.green);
     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 3, Color.green);
     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 3, Color.green);
            

     if( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,maxDist)){
     if(hit.collider.tag == "Infected" ){
      
      Expos = ShouldExposeHealthy(gameObject,hit.distance);
      
     }
     } 
    if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit1,maxDist)){
     if(hit1.collider.tag == "Infected")
     {
      
      Expos =  ShouldExposeHealthy(gameObject,hit1.distance);
      
     } }
    if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit2,maxDist)){
     if( hit2.collider.tag == "Infected")
     {
     
     Expos = ShouldExposeHealthy(gameObject,hit2.distance); 
      
     } 
    }
    if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit3,maxDist)){
    if(hit3.collider.tag == "Infected")
     {
    
     Expos = ShouldExposeHealthy(gameObject,hit3.distance); 
     
    }
    }
    if (Expos == true && Healthy == true){
        //Debug.Log("Touch!" + getValue.ToString());
        gameObject.GetComponent<Renderer>().material = mat;
        Healthy = false;
        gameObject.tag = "Infected";
    }
       
 
}

  bool ShouldExposeHealthy(GameObject healthy, float distance)
    {
      
        if (distance > ExposureDistanceMeters)
        {
            return false;
        }
       
        var t = distance / ExposureDistanceMeters;
        var prob = ExposureProbabilityAtZeroDistance * (1.0f - t) + ExposureProbabilityAtMaxDistance * t; 
        var probPerFrame = 1.0f - Mathf.Pow(1.0f - prob, Time.deltaTime);
        return UnityEngine.Random.value < probPerFrame;
    }



}
