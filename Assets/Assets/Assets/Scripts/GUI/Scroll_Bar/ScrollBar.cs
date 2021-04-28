using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    // Start is called before the first frame update

[SerializeField]
    public Slider sliderCustomerWithoutMask;
    [SerializeField]
    public Slider sliderCustomerWithMask;
    [SerializeField]
    
    public Slider sliderCustomerInfected;

    public float custmerWithoutMaskvalue=0.0f;
    public float custmerWithMaskvalue=0.0f;
    public float customerInfectorsValue=0.0f;

    


    public void changedValueCustomerNormal(){
                    
                    sliderCustomerWithMask.value = (1 - sliderCustomerWithoutMask.value)/2 ;
                    custmerWithMaskvalue = sliderCustomerWithMask.value;
                    sliderCustomerInfected.value = (1 - sliderCustomerWithoutMask.value)/2;
                    customerInfectorsValue =  sliderCustomerInfected.value;
    }
    // public void changedValueCustomerMask(){
        
    //                 sliderCustomerWithoutMask.value = (1 - sliderCustomerWithMask.value)/2 ;
    //                 sliderCustomerInfected.value = (1 - sliderCustomerWithMask.value)/2;
    // }

        public void changedValueCustomerInfected(){
        
                    sliderCustomerWithoutMask.value = ( 1 - sliderCustomerInfected.value) ;
                    sliderCustomerWithMask.value = (1 - sliderCustomerInfected.value);
        }
    






}
