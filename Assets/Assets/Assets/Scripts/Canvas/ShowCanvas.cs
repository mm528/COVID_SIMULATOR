using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    // Start is called before the first frame update

   public Animator Animation;
   public Canvas canvas;
   public Canvas canvCamera;
   [SerializeField]
   public Camera camera1;
   [SerializeField]
   public Camera camera2;

   [SerializeField] 
   private GameObject textmessage;


   public GameObject moon;
    void Start()
    {
      Animation = gameObject.GetComponent<Animator>();
      moon = GameObject.FindGameObjectWithTag("Moon").gameObject;
      moon.SetActive(false);
      
      
    canvas = GameObject.FindGameObjectWithTag("CanvasE").GetComponent<Canvas>();
    canvCamera = GameObject.FindGameObjectWithTag("CanvasCamera").GetComponent<Canvas>();

    canvas.enabled=false;
    camera1.enabled = true;
    camera2.enabled = false;
     canvCamera.enabled=false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 0.8){
            textmessage.SetActive(false);
        }
        if (Time.time>13){
            canvCamera.enabled=true;
            
        }
        if (Time.time>18){
             canvCamera.enabled=false;
        }
        if(Animation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){  //If normalizedTime is 0 to 1 means animation is playing, if greater than 1 means finished
       
        
         if (camera2.enabled == true){
               canvas.enabled=false;
         }else{
              canvas.enabled=true;
                moon.SetActive(true);
         }
        
         if (Input.GetKeyDown(KeyCode.C)) {
         camera1.enabled = !camera1.enabled;
         
         camera2.enabled = !camera2.enabled;
     }

    
 }else{
         // canvas.enabled=true;
 }

    }
}
