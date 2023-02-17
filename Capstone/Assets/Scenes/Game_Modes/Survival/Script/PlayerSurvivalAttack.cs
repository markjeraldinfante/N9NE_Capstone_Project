 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurvivalAttack : MonoBehaviour
{
    float speed = 25f;
    public KeyCode key;
    Animator animator;
    public GameObject batoObject;
    public Transform point;
  //  public bool allowFire;

     List<GameObject> batoList;




    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
     //   allowFire = true;
        batoList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
           GameObject objBato = (GameObject)Instantiate(batoObject);
           objBato.SetActive(false);
           batoList.Add(objBato);
        }
    }

    void Update()
    {
        // if (Input.GetKeyDown(key) && allowFire)
        if (Input.GetKeyDown(key))
        {

         //   StartCoroutine(Fire());
         Fire();
        }

    }

   // IEnumerator Fire()
   private void Fire()
    {
       // allowFire = false;

        for (int i = 0; i < batoList.Count; i++)
        {
            if(batoList[i].activeInHierarchy)
            {
                batoList[i].transform.position = transform.position;
                 batoList[i].transform.rotation = transform.rotation;
                 batoList[i].SetActive(true);
                 Rigidbody tempRigidBodyBato = batoList[i].GetComponent<Rigidbody>();
                 tempRigidBodyBato.AddForce(tempRigidBodyBato.transform.forward, ForceMode.Impulse);

            }
        }
        // animator.SetTrigger("attack");
       /* yield return new WaitForSeconds(0.5f);
        GameObject bato = Instantiate(batoObject, point.position, transform.rotation);
        bato.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);

        allowFire = true;
        Destroy(bato, 1f);*/
     
     
     /*   GameObject batoObject = ObjectPooled.instance.GetPooledObject();

        if(batoObject != null)
        {
           
           
            batoObject.transform.position = point.position;
             batoObject.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
            batoObject.SetActive(true);
           

        }*/
       
        
    }

}
