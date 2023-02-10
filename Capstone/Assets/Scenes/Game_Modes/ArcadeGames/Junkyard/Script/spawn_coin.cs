using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_coin : MonoBehaviour
{
    [SerializeField] GameObject[] bCoin;
    [SerializeField] float secondSpawn = 0.3f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
   

  
    // Start is called before the first frame update

    void Start(){
        StartCoroutine (BrokenCoinSpawn());
    }

    // Update is called once per frame
IEnumerator BrokenCoinSpawn(){
    while(true) {
        var wanted = Random.Range(minX, maxX);
        var position = new Vector3(wanted, transform.position.y);
        GameObject gameObject = Instantiate(bCoin[Random.Range(0, bCoin.Length)], position, Quaternion.identity);
        yield return new WaitForSeconds(secondSpawn);
        Destroy(gameObject,3f);

    }

    
    

}
    

}
