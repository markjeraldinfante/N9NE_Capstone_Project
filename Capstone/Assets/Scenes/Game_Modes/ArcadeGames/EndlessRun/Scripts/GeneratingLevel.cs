using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] level;
    public float zPos = 42.1f;
    public bool creatingSection = false;
    public int secNum;


    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateLevel());
        }
    }
    IEnumerator GenerateLevel()
    {
        secNum = Random.Range(0,3);
        Instantiate(level[secNum], new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 42.1f;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
