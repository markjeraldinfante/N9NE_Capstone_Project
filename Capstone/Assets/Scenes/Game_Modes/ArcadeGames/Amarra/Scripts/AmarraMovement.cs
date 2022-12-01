using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmarraMovement : MonoBehaviour
{
    public float movesSpeed = 600f;
    float movement = 0f;
    [SerializeField] bool isfacingRight;


    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -movesSpeed);

        if (movement > 0 && !isfacingRight)
        {
            isfacingRight = !isfacingRight;
            transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        else if (movement < 0 && isfacingRight)
        {

            isfacingRight = !isfacingRight;
            transform.localScale = new Vector3(-0.05f, 0.05f, 0.05f);
        }
        else if (movement == 0)
        {

        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
