using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiplayer : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] private float speed;
    //[SerializeField] private float turnSpeed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;

  

    private Rigidbody rb;
    private  new Renderer renderer;

    private float inputHorizontal;
    private float inputVertical;

    private void Start()
    {

        
        rb = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();

      
      
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical);
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
