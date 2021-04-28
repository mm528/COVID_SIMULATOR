using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_game : MonoBehaviour
{
    [SerializeField]
    public Text normalCustomers;
    public Text infectCustomers;
    public Text CustomMask;


    public Game_Up game;
    public void ChangesValues()
    {
       
        foreach (GameObject k in game.CustomersLis)
        {
            Destroy(k);
        }
        foreach (GameObject k in game.CustomerInfected)
        {
            Destroy(k);
        }
        foreach (GameObject k in game.CustomerMask)
        {
            Destroy(k);
        }
       
        int norcustom;
        int infectedc;
        int mask;
       

        int.TryParse(normalCustomers.text, out norcustom);
        game.customerInteger = norcustom;
        game.createCustomer();


        int.TryParse(infectCustomers.text, out infectedc);
        game.infectedInteger = infectedc;
        Debug.Log(infectedc);
  


        game.intLeghtMask = 0;
        int.TryParse(CustomMask.text, out mask);
        game.maskInteger = mask;
        

        
    }


public void ExitGame(){


 Application.Quit();
 
            UnityEditor.EditorApplication.isPlaying = false;

}
}
