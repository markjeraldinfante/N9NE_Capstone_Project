using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject batoObject;
    [SerializeField] private GameObject newObject;
    [SerializeField] private int batoPoolSize;
    [SerializeField] private int newPoolSize;
    [SerializeField] private Transform parentTransform;

    private List<GameObject> batoPool = new List<GameObject>();
    private List<GameObject> newPool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < batoPoolSize; i++)
        {
            GameObject obj = Instantiate(batoObject);
            obj.SetActive(false);
            obj.transform.parent = parentTransform;
            batoPool.Add(obj);
        }

        for (int i = 0; i < newPoolSize; i++)
        {
            GameObject obj = Instantiate(newObject);
            obj.SetActive(false);
            obj.transform.parent = parentTransform;
            newPool.Add(obj);
        }
    }

    public GameObject GetPooledObject(bool useNewObject, float destroyTime)
    {
        List<GameObject> pool = useNewObject ? newPool : batoPool;
        int poolSize = useNewObject ? newPoolSize : batoPoolSize;

        for (int i = 0; i < poolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                GameObject obj = pool[i];

                obj.SetActive(false);
                obj.transform.position = Vector3.zero;
                obj.transform.rotation = Quaternion.identity;
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;

                obj.SetActive(true);
                StartCoroutine(DestroyAfterTime(obj, destroyTime));

                return obj;
            }
        }

        GameObject newObj = Instantiate(useNewObject ? newObject : batoObject);
        newObj.SetActive(false);
        newObj.transform.parent = parentTransform;

        pool.Add(newObj);

        newObj.SetActive(true);
        StartCoroutine(DestroyAfterTime(newObj, destroyTime));

        return newObj;
    }

    private IEnumerator DestroyAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);

        obj.SetActive(false);
        obj.transform.parent = parentTransform;
    }
}
