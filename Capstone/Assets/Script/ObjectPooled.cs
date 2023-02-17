using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooled : MonoBehaviour
{
    public static ObjectPooled instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountPool = 10;
    [SerializeField] private GameObject BatoPrefab;

    private void Awake()
    {
       if (instance ==null)
       {
        instance = this;
       }
    }
    void Start()
    {
        for (int i = 0; i < amountPool; i++)
        {
            GameObject objBato = (GameObject)Instantiate(BatoPrefab);
            objBato.SetActive(false);
            pooledObjects.Add(objBato);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
                
            }
        }
        return null;

    }

   
}
