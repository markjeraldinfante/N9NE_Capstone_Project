using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

   IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(1, 3);
            zPos = Random.Range(1, 3);
            Instantiate(theEnemy, new Vector3(xPos, 3, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount += 2;
        }
    }
}
