using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShootingArea : MonoBehaviour
{
    public GameObject spawnEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int enemyToAdd;
    public float wait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while(enemyCount < enemyToAdd)
        {
            xPos = Random.Range(-7,9);
            zPos = Random.Range(-8,0);
            Instantiate(spawnEnemy,new Vector3(xPos,1,zPos),Quaternion.identity);
            yield return new WaitForSeconds(wait);
           // Object.Destroy(spawnEnemy,wait);
            enemyCount +=1 ;
        }
    }


}
