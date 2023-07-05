using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cakecherries : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject parentObject;
    public void GenerateSphere(int numberOfSpheres)
{
    StartCoroutine(GenerateSpheresWithDelay(numberOfSpheres));
}

private IEnumerator GenerateSpheresWithDelay(int numberOfSpheres)
{
    for (int i = 0; i < numberOfSpheres; i++)
    {
        Vector3 position = new Vector3(0, 0, 0);
        GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
        sphere.transform.SetParent(parentObject.transform);

        yield return new WaitForSeconds(0.1f);
    }
    yield return new WaitForSeconds(2f);
    reload();
}

public void reload(){
        SceneManager.LoadScene("threeDScene");
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    
}
