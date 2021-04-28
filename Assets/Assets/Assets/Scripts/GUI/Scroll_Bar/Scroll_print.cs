using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll_print : MonoBehaviour
{

    // Start is called before the first frame update
[SerializeField]
    public Text numberCustomers; //ALLcUSTOMER
    public Text percentageNormalCustomer;
        public Text percentageMaskCustomer;
            public Text percentageInfectorsCustomer;


    public Slider slider; //ALL CUSTOMER
    public Slider sliderCustomerNomral;
    public Slider sliderCustomerwithMask;
    public Slider sliderCustomerInfectors;
        public float pithanotitaNormalCustomer;
     public float pithanotitaMaskCustomer;
      public float pithanotitaInfectorsCustomer;

    public int newCustomersNumber;
    public float maxValues;
      public int customerInteger;

      public float previousPerecentageCustomer=0.0f;
      public float previousMaskCustomer = 0.0f;
      public float previousInfectorsCustomer=0.0f;
      public float TOTALFLOAT;
      public bool answerChange = true;
          
    void Start()
    {
        slider.GetComponent<Slider>().wholeNumbers = true;
        slider.GetComponent<Slider>().maxValue = 120;
        slider.GetComponent<Slider>().minValue = 0;
        sliderCustomerNomral.value = Mathf.Round(sliderCustomerNomral.value *100.0f)*0.01f;
    }

    // Update is called once per frame
    void Update()
    {
          sliderCustomerNomral.value = Mathf.Round(sliderCustomerNomral.value *100.0f)*0.01f;
                 sliderCustomerwithMask.value = Mathf.Round(sliderCustomerwithMask.value *100.0f)*0.01f;   
                 sliderCustomerInfectors.value = Mathf.Round(sliderCustomerInfectors.value *100.0f)*0.01f;          
        numberCustomers.text = slider.value.ToString();
        percentageNormalCustomer.text = sliderCustomerNomral.value.ToString();
        percentageMaskCustomer.text = sliderCustomerwithMask.value.ToString();
        percentageInfectorsCustomer.text = sliderCustomerInfectors.value.ToString();

        
                customerInteger = int.Parse(slider.value.ToString());
                pithanotitaNormalCustomer = Mathf.Round((float.Parse(percentageNormalCustomer.text.ToString()))*100.0f)*0.01f;
                pithanotitaMaskCustomer = Mathf.Round((float.Parse(percentageMaskCustomer.text.ToString()))*100.0f)*0.01f;
                 pithanotitaInfectorsCustomer = Mathf.Round((float.Parse(percentageInfectorsCustomer.text.ToString()))*100.0f)*0.01f;


                if ((sliderCustomerNomral.value != previousPerecentageCustomer)){
                 
                
                    AdjustBar();

                    previousPerecentageCustomer = sliderCustomerNomral.value;
                               // previousPerecentageCustomer = pithanotitaNormalCustomer;
                                //previousMaskCustomer = pithanotitaMaskCustomer;
                              //  previousInfectorsCustomer=0.0f;

                }
                if (sliderCustomerwithMask.value != previousMaskCustomer){
                    AdjustBar();
                    previousMaskCustomer = sliderCustomerwithMask.value;
                }
                if (sliderCustomerInfectors.value != previousInfectorsCustomer){
                    AdjustBar();
                    previousInfectorsCustomer = sliderCustomerInfectors.value;
                }
            

    }

    void AdjustBar(){

            //   customerInteger = int.Parse(slider.value.ToString());
            //     pithanotitaNormalCustomer = float.Parse(percentageNormalCustomer.text.ToString());
            //     pithanotitaMaskCustomer = float.Parse(percentageMaskCustomer.text.ToString());
            //      pithanotitaInfectorsCustomer = float.Parse(percentageInfectorsCustomer.text.ToString());
      






            //customerInteger = int.Parse(slide1.value.ToString());
           // pithanotitaNormalCustomer = float.Parse(percentageNormalCustomer.value.ToString());
           //  pithanotitaMaskCustomer = float.Parse(percentageMaskCustomer.value.ToString());
            // pithanotitaInfectorsCustomer = float.Parse(percentageInfectors.value.ToString());

            sliderCustomerNomral.maxValue = 1- (pithanotitaMaskCustomer + pithanotitaInfectorsCustomer);
            sliderCustomerNomral.maxValue = Mathf.Round( sliderCustomerNomral.maxValue * 100.0f)*0.01f;
            sliderCustomerwithMask.maxValue = 1 - (pithanotitaNormalCustomer + pithanotitaInfectorsCustomer);
            sliderCustomerwithMask.maxValue = Mathf.Round(sliderCustomerwithMask.maxValue *100.0f )*0.01f;
            sliderCustomerInfectors.maxValue =  1- (pithanotitaNormalCustomer + pithanotitaMaskCustomer);

            sliderCustomerInfectors.maxValue = Mathf.Round(sliderCustomerInfectors.maxValue * 100.0f)*0.01f;
            
            if ((pithanotitaNormalCustomer + pithanotitaMaskCustomer +pithanotitaInfectorsCustomer ) <=1 && (pithanotitaNormalCustomer + pithanotitaMaskCustomer +pithanotitaInfectorsCustomer )!=0){
                        if (pithanotitaNormalCustomer >= pithanotitaMaskCustomer && pithanotitaNormalCustomer >=pithanotitaInfectorsCustomer ){
                                   maxValues = Mathf.Round(pithanotitaNormalCustomer*100.0f)*0.01f;
                                   // maxValues =  1 - (pithanotitaNormalCustomer + pithanotitaMaskCustomer + pithanotitaInfectorsCustomer);
                                     sliderCustomerwithMask.value =    sliderCustomerwithMask.value + maxValues/2;
                                      sliderCustomerwithMask.value = Mathf.Round( sliderCustomerwithMask.value * 100.0f)*0.01f;
                                   sliderCustomerInfectors.value =  sliderCustomerInfectors.value + maxValues/2;
                                    sliderCustomerInfectors.value = Mathf.Round( sliderCustomerInfectors.value * 100.0f)*0.01f;
                                   TOTALFLOAT =    sliderCustomerwithMask.value + sliderCustomerInfectors.value + maxValues;
                                            //  if (TOTALFLOAT >1){
                                            //     sliderCustomerNomral.value = Mathf.Round(sliderCustomerNomral.value - (sliderCustomerNomral.value - 1) *100.0f)*0.01f ;
                                            //       TOTALFLOAT =    sliderCustomerwithMask.value + sliderCustomerInfectors.value + maxValues;
                                            //  }
                        }else if (pithanotitaMaskCustomer >= pithanotitaInfectorsCustomer && pithanotitaMaskCustomer > pithanotitaNormalCustomer){
                                maxValues = Mathf.Round(pithanotitaMaskCustomer *100.0f)*0.01f;
                            //  maxValues =  1 - (pithanotitaMaskCustomer + pithanotitaNormalCustomer + pithanotitaInfectorsCustomer);
                              sliderCustomerNomral.value = Mathf.Round((sliderCustomerNomral.value + maxValues/2)*100.0f)*0.01f;
                              sliderCustomerInfectors.value = Mathf.Round((sliderCustomerInfectors.value +  maxValues/2)*100.0f)*0.01f;
                             
                            //   if (TOTALFLOAT >1){
                            //                     sliderCustomerwithMask.value= Mathf.Round(sliderCustomerwithMask.value - (sliderCustomerwithMask.value -1) *100.0f)*0.011f;
                            //                       TOTALFLOAT =     sliderCustomerNomral.value + sliderCustomerInfectors.value + maxValues;
                            //                  }

                        }
                        else if (pithanotitaInfectorsCustomer > pithanotitaNormalCustomer && pithanotitaInfectorsCustomer > pithanotitaMaskCustomer){
                               maxValues = Mathf.Round(pithanotitaInfectorsCustomer * 100.0f)*0.01f;
                                // maxValues =  1 - (pithanotitaInfectorsCustomer + pithanotitaNormalCustomer + pithanotitaMaskCustomer);
                                sliderCustomerNomral.value =  Mathf.Round((sliderCustomerNomral.value +  maxValues/2)*100.0f)*0.01f;
                                 sliderCustomerwithMask.value =  Mathf.Round((sliderCustomerwithMask.value  + maxValues/2)*100.0f)*0.01f;
                                //  TOTALFLOAT =    sliderCustomerwithMask.value +  sliderCustomerNomral.value + maxValues;
                                //  if (TOTALFLOAT >1){
                                //               sliderCustomerInfectors.value = Mathf.Round(sliderCustomerInfectors.value -(sliderCustomerInfectors.value -1)*100.0f)*0.01f;
                                //                          TOTALFLOAT =    sliderCustomerwithMask.value +  sliderCustomerNomral.value + maxValues;
                                //              }

                        }
                    
              

           }



    }
}
