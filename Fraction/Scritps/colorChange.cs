using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChange : MonoBehaviour
{
    public Text numerator;
    public Material mat01;
    public Material mat02;
    bool isblue ;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = mat01;
        isblue = true;
    }

    public void Switch()
    {
        if(isblue){
            this.GetComponent<Renderer>().material = mat02;
            isblue = false;
            
            countSphere.count++;
            
             Debug.Log(countSphere.count);   
             numerator.text = countSphere.count.ToString();
            
            
        }
        else if(!isblue){
            this.GetComponent<Renderer>().material = mat01;
            isblue = true;
            if(countSphere.count==0){
            countSphere.count = 0;
            }else{
                countSphere.count--;
            }
            Debug.Log(countSphere.count);     
            numerator.text = countSphere.count.ToString();       
        }
        
    }

    void update(){
       
    }
    
}
