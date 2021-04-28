using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaneColor : MonoBehaviour
{
    [SerializeField]

    public Text U;
       public Text C;
       public ParticleSystem virus1;
        public ParticleSystem virus2;

    float ti;
    // Start is called before the first frame update
    void Start()
    {
    ti = Time.time;
    virus2.Stop();
 

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 5.5){
        C.color = Color.red;
            virus1.Play();
        }
         if (Time.time > 7){
        U.color = Color.red;
        virus2.Play();
        }
    }
}
