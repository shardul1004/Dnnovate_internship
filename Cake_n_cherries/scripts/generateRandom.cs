using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class generateRandom : MonoBehaviour
{
    bool shouldI=true;
    int av;
    int bv;
    int answer=0;
    cakecherries cake;
    public GameObject Prefab;
    GameObject obj1,obj2;
    public GameObject[] _Numbers;
    public GameObject grid_layout;
    public GameObject grid_layout_ans;
    public GameObject grid_layout_ques;
    public GameObject circlular;
    IEnumerator WaitForFunction(int i)
{
    Debug.Log("Delay"); 
    yield return new WaitForSeconds(i); 
}

public void startwithout(){
    StartCoroutine(startwithdelay());
}
private IEnumerator startwithdelay(){
    av = Random.Range(6,10);
    Setquestion(av);
        bv = Random.Range(1,5);
    Setquestion(bv);
        answer = av*bv;
        int num1 = Random.Range(3,100);
        int num2 = Random.Range(2,100);
        yield return new WaitForSeconds(0.5f);
        SetNumber(answer);
        yield return new WaitForSeconds(0.5f);
        SetNumber(num1);
        yield return new WaitForSeconds(0.5f);
        SetNumber(num2);
}
    public void Setquestion(int Temp){
    //    GameObject prefab = Instantiate(Prefab,new Vector3(0f,0f,0f),new Quaternion(0,180, 0, 1));
        if(Temp < 10)
        {
            GameObject a = Instantiate(_Numbers[Temp], new Vector3(0,0,-0.3f),new Quaternion(0,180,0,1));
            Transform a_transform = a.GetComponent<Transform>();
            a.transform.SetParent(grid_layout_ques.transform);
            // prefab.transform.SetParent(grid_layout_ans.transform);
            Debug.Log(Temp);
        }
        if(Temp >= 10)
        {
            GameObject a =Instantiate(_Numbers[Temp / 10], new Vector3(-0.35f, 0, -0.3f), new Quaternion(0, 180, 0, 1));
            GameObject b  =Instantiate(_Numbers[Temp % 10], new Vector3(0.35f, 0, -0.3f), new Quaternion(0, 180, 0, 1));
            a.transform.SetParent(grid_layout_ques.transform);
            b.transform.SetParent(grid_layout_ques.transform);
            // prefab.transform.SetParent(grid_layout_ans.transform);
            Debug.Log(Temp / 10 + " " + Temp % 10);
        }

        // if(Temp==answer){
        //     prefab.name = "correct";
        // }
    }
    public void SetNumber(int Temp)
    {   GameObject prefab = Instantiate(Prefab,new Vector3(0f,0f,0f),new Quaternion(0,180, 0, 1));
        if(Temp < 10)
        {
            GameObject a = Instantiate(_Numbers[Temp], new Vector3(0,0,-0.3f),new Quaternion(0,180,0,1));
            a.transform.SetParent(prefab.transform);
            prefab.transform.SetParent(grid_layout.transform);
            Debug.Log(Temp);
        }
        if(Temp >= 10)
        {
            GameObject a =Instantiate(_Numbers[Temp / 10], new Vector3(-0.35f, 0, -0.3f), new Quaternion(0, 180, 0, 1));
            GameObject b  =Instantiate(_Numbers[Temp % 10], new Vector3(0.35f, 0, -0.3f), new Quaternion(0, 180, 0, 1));
            a.transform.SetParent(prefab.transform);
            b.transform.SetParent(prefab.transform);
            prefab.transform.SetParent(grid_layout.transform);
            Debug.Log(Temp / 10 + " " + Temp % 10);
        }

        if(Temp==answer){
            prefab.name = "correct";
        }
    }
    private GameObject FindNumberInLayout(Transform parent)
    {
        if (parent.childCount > 0)
        {
            return parent.GetChild(0).gameObject;
        }

        return null;
    }
    // Start is called before the first frame update
    void Start()
    {

        startwithout();
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Transform layoutTransform = grid_layout_ans.transform;
        GameObject numberInLayout = FindNumberInLayout(layoutTransform);
        if (numberInLayout != null)
        {
            Debug.Log(numberInLayout.tag);
            Debug.Log(numberInLayout.name);
            if (numberInLayout.name == "correct" && shouldI==true)
            {
                cake = circlular.GetComponent<cakecherries>();
                cake.GenerateSphere(answer);
                shouldI=false;
            }
            else if (numberInLayout.name == "wrong")
            {
                Destroy(numberInLayout);
            }
        }


    }

}
