using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locoEnemy : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dead");
        }
        if (other.tag == gameObject.tag)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Dead");
        }
    }



}
