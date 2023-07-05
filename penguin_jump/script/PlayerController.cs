using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gridLayout_option;
    public int Count=0;
    public GameObject gridLayout_question;
    public GameObject gridLayout_platform;
    public GameObject platform;
    public float jumpSpeed = 5f; // Adjust this value to control the speed of the jump
    public GameObject Prefab;
    public GameObject[] _Numbers;
    public int answer=1;
    public GameObject multiplication;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        generateQuesandAns();
        canvas.enabled=false;
    }
    void generateQuesandAns(){
        answer=1;
        int le = Random.Range(0,10);
        answer=answer*le;
        SetNumber(le,0);
        GameObject Multiplication = Instantiate(multiplication,new Vector3(3.47542214f,-7.96189833f,-125.099998f),Quaternion.Euler(0f,0f,0f));
        Multiplication.transform.SetParent(gridLayout_question.transform);
        le = Random.Range(0,5);
        answer=answer*le;
        SetNumber(le,0);
        GameObject platform1 = Instantiate(platform,new Vector3(0f,0f,0f),Quaternion.Euler(0f,0f,0f));
        GameObject platform2 = Instantiate(platform,new Vector3(0f,0f,0f),Quaternion.Euler(0f,0f,0f));
        GameObject platform3 = Instantiate(platform,new Vector3(0f,0f,0f),Quaternion.Euler(0f,0f,0f)); 
        platform1.transform.SetParent(gridLayout_platform.transform);
        platform2.transform.SetParent(gridLayout_platform.transform);
        platform3.transform.SetParent(gridLayout_platform.transform);

        SetNumber(answer,1);
        le=Random.Range(0,100);
        SetNumber(le,1);
        le=Random.Range(0,100);
        SetNumber(le,1);


    }
    void JumpToPlatform()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Platform") ||hit.collider.CompareTag("Correct"))
            {
                Vector3 jumpDirection = hit.point - transform.position;
                Debug.Log(jumpDirection.magnitude);

                // Calculate the distance between the player and the target
                float distance = jumpDirection.magnitude;

                // Calculate the initial vertical velocity required to reach the target height
                float initialVerticalVelocity = Mathf.Sqrt(2f * jumpSpeed * distance);

                // Calculate the time of flight using the vertical velocity and gravity
                float timeOfFlight = 2f*initialVerticalVelocity / 9.81f;

                // Calculate the horizontal velocity required to cover the distance in the given time
                float horizontalVelocity = distance / timeOfFlight;

                // Calculate the force in x, y, and z directions
                float forceX = jumpDirection.normalized.x * horizontalVelocity;
                float forceY = initialVerticalVelocity;
                float forceZ = jumpDirection.normalized.z * horizontalVelocity;

                // Apply the force to the player
                GetComponent<Rigidbody>().AddForce(new Vector3(forceX, forceY, forceZ), ForceMode.VelocityChange);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            JumpToPlatform();
            checkIf();
        }
        if(Count==3){
                canvas.enabled=true;
        }
    }

    void checkIf(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Correct"))
            {
                Count=Count+1;
                Debug.Log(Count);
                for (int i = gridLayout_question.transform.childCount - 1; i >= 0; i--)
        {
            // Get the child GameObject at index 'i'
            GameObject childObject = gridLayout_question.transform.GetChild(i).gameObject;

            // Destroy the child GameObject
            Destroy(childObject);
        }
                generateQuesandAns();
            }
        }

    }
    public void SetNumber(int Temp, int opt)
    {
        GameObject numberHolder = Instantiate(Prefab, Vector3.zero, Quaternion.Euler(0, 180, 0));

        if (Temp < 10)
        {
            GameObject a = Instantiate(_Numbers[Temp], new Vector3(0, 0, 0f), Quaternion.Euler(0, 180, 0));
            a.transform.SetParent(numberHolder.transform);
        }
        else
        {
            GameObject a = Instantiate(_Numbers[Temp / 10], new Vector3(-0.35f, 0, 0f), Quaternion.Euler(0, 180, 0));
            GameObject b = Instantiate(_Numbers[Temp % 10], new Vector3(0.35f, 0, 0f), Quaternion.Euler(0, 180, 0));
            a.transform.SetParent(numberHolder.transform);
            b.transform.SetParent(numberHolder.transform);
        }

        if (opt == 1)
        {
            numberHolder.transform.SetParent(gridLayout_option.transform);
            if (Temp == answer)
            {
                numberHolder.tag = "Correct";
            }
            else
            {
                numberHolder.name = "wrong";
            }
        }
        else
        {
            numberHolder.transform.SetParent(gridLayout_question.transform);
            Vector3 positiony = numberHolder.transform.position;
            positiony.y=0;
            numberHolder.transform.position=positiony;
        }
    }
}
