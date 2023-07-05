using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class children : MonoBehaviour
{
    [SerializeField] GameObject grid;
    [SerializeField] GameObject circle;
    [SerializeField] Text gridText;
    [SerializeField] Text CirleText;

     void Update() {
        
    }
    
   
    public void GetChild(){
        gridText.text = grid.transform.childCount.ToString();
        CirleText.text = circle.transform.childCount.ToString();
        
        
        
    }
    

    
    
}
