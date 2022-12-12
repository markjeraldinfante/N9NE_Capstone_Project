using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiplayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;

    private Rigidbody rb;
    private new Renderer renderer;

    private float inputHorizontal;
    private float inputVertical;
    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
   private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);
    }
}
