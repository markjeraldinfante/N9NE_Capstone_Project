using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiplayer : MonoBehaviour
{
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 _input;

    private Rigidbody rb;
    private new Renderer renderer;

    private float inputHorizontal;
    private float inputVertical;
    // Start is called before the first frame update
    private void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // rb = GetComponentInParent<Rigidbody>();
        // renderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //  inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        //inputVertical = Input.GetAxisRaw(inputNameVertical);
        GatherInput();
        Look();
    }
    private void FixedUpdate()
    {
        Move();
        // rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw(inputNameHorizontal), 0, Input.GetAxisRaw(inputNameVertical));
        if (Input.GetAxisRaw(inputNameHorizontal) == 0 && Input.GetAxisRaw(inputNameVertical) == 0)
        {
            animator.SetBool("Walk", false);
        }
        else
            animator.SetBool("Walk", true);

    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * speed * Time.deltaTime);
    }

}

#region Helper
public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
#endregion