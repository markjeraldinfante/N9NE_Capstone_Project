using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
   
    public float spawnRate = 1f;
    public GameObject trapPrefab;
    private float nTime = 1f;
    
   
    // Start is called before the first frame update
    
  
   

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= nTime)
        {
            
            Instantiate(trapPrefab, Vector3.zero, Quaternion.identity);
            nTime = Time.time + 1f / spawnRate;
          
          
        }

        




    }
}
