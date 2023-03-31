using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject batoObject;

    [SerializeField] private int poolSize;
    [SerializeField] private Transform parentTransform;
    TrailRenderer trail;

    private List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        trail = batoObject.GetComponent<TrailRenderer>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(batoObject);
            obj.SetActive(false);
            obj.transform.parent = parentTransform;
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject(float destroyTime)
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
            {

                pool[i].SetActive(false);
                pool[i].transform.position = Vector3.zero;
                pool[i].transform.rotation = Quaternion.identity;
                pool[i].GetComponent<Rigidbody>().velocity = Vector3.zero;

                pool[i].SetActive(true);
                StartCoroutine(DestroyAfterTime(pool[i], destroyTime));

                return pool[i];
            }
        }

        GameObject obj = Instantiate(batoObject);
        obj.SetActive(false);
        obj.transform.parent = parentTransform;
        pool.Add(obj);

        obj.SetActive(true);
        StartCoroutine(DestroyAfterTime(obj, destroyTime));

        return obj;
    }
    private IEnumerator DestroyAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        trail.Clear();
        obj.transform.parent = parentTransform;
        obj.SetActive(false);
    }
}
