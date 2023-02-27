using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMultiplayer : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float speed = 5f;
    [SerializeField] private baseSurvivalVariant variant;

    Rigidbody _rb;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 _input;

    private Rigidbody rb;
    private new Renderer renderer;
    PhotonView view;

    [SerializeField] public basePlayer basePlayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

        if (variant.isOnline)
        {
            view = GetComponent<PhotonView>();
        }
    }


    private void Update()
    {
        GatherInput();
        Look();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        if (!variant.isOnline)
        {

            switch (basePlayer)
            {
                case basePlayer.Player1:
                    _input = new Vector3(Input.GetAxisRaw("Horizontal 1"), 0, Input.GetAxisRaw("Vertical 1"));
                    if (Input.GetAxisRaw("Horizontal 1") == 0 && Input.GetAxisRaw("Vertical 1") == 0)
                    {
                        animator.SetBool("Walk", false);
                    }
                    else
                        animator.SetBool("Walk", true);
                    break;

                case basePlayer.Player2:

                    _input = new Vector3(Input.GetAxisRaw("Horizontal 2"), 0, Input.GetAxisRaw("Vertical 2"));
                    if (Input.GetAxisRaw("Horizontal 2") == 0 && Input.GetAxisRaw("Vertical 2") == 0)
                    {
                        animator.SetBool("Walk", false);
                    }
                    else
                        animator.SetBool("Walk", true);
                    break;

            }
        }
        else
        {
            if (view.IsMine)
            {
                _input = new Vector3(Input.GetAxisRaw("Horizontal 1"), 0, Input.GetAxisRaw("Vertical 1"));
                if (Input.GetAxisRaw("Horizontal 1") == 0 && Input.GetAxisRaw("Vertical 1") == 0)
                {
                    animator.SetBool("Walk", false);
                }
                else
                    animator.SetBool("Walk", true);
            }

        }
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