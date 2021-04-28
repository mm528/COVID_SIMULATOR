using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class windowGraph : MonoBehaviour
{
   

[SerializeField] private Sprite circleSprite;


public int positionList;
 public int countInfectionPeople=0;
private RectTransform graphContainer;
  public List<int> valueList;
  public int previousCount;
   GameObject[] ALllDots;
   public int counter=0;
   public GameObject gameUp; 
    public float yMaximum = 40f;// people INFECTED
   public  float xSize = 5f; // TIME DELTA!
   public   float graphHeight;
   public bool number = false;
  
    private void Awake (){

        graphContainer = transform.Find("Graph_Container").GetComponent<RectTransform>();
        // CreateCircle(new Vector2(200,200));
        valueList = new List<int>();
       // ShowGraoh(valueList);
        previousCount = 0;
          gameUp = GameObject.FindGameObjectWithTag("A");
      
   
    }

/*
Every time where the graph changes lenth values, and we update the graph
@peopleInf : is the length of the list
*/
      public void ChangeGraph(int peopleInf){
     
          ALllDots = GameObject.FindGameObjectsWithTag("DOTS");
               if (ALllDots.Length == 0){
                        valueList = new List<int>();
            }
            if (previousCount < peopleInf){
                previousCount = peopleInf;
             valueList.Add(peopleInf);
             counter++;
           //  Debug.Log("Graph list is: " + valueList.ToString());
             //valueList.Sort();
            ShowGraoh(valueList);
            }else{
                previousCount = peopleInf;
            }
          

            

          
    }
    /*
    
    We have to add the dot on the graph, each. We have a start point (0,0)
    */   public void CreateCircle (Vector2 AnchoredPosition ){
        GameObject gameObject = new GameObject ("Circle", typeof (Image));
        gameObject.transform.SetParent(graphContainer,false);
       
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = AnchoredPosition;
        rectTransform.sizeDelta = new Vector2(11,11);
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0,0);
        gameObject.tag = "DOTS";

    }

/*

Show the Graph - represents the Values of the list
*/
public void ShowGraoh(List<int> valueList){
  
  graphHeight  = graphContainer.sizeDelta.y;
    
    if (gameUp.GetComponent<Game_Up>().CustomerInfected.Length > 35){
             DeleteAllDots();
            yMaximum = 200f;
            xSize = 2f;
    }
 
     if (number == true){
         number= false;
             DeleteAllDots();
            yMaximum = 40f;
            xSize = 5f;
    }
    
    for (int i=0; i< valueList.Count; i++){
        float xPosition = xSize + i* xSize;
        float yPosition = (valueList[i]/ yMaximum) *graphHeight;
        CreateCircle(new Vector2(xPosition, yPosition));

    }



}


/*

Here we destroy the elements from the List -> In order to have fresh data
*/
public void DeleteAllDots(){
   
    foreach(GameObject h in ALllDots){
        
        Destroy(h.gameObject);
    }
}
}