using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 20;
    public float RotateSpeed = 100;
    private Animator playerAnimator;
    private float verticalValue;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        verticalValue = Input.GetAxis("Vertical");

        Move();
    }

    private void Move()
    {

        // Walk Code
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetBool("Walk", true);
            transform.position += transform.forward * walkSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            playerAnimator.SetBool("Run", true);
            transform.position += transform.forward * runSpeed * Time.deltaTime;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            playerAnimator.SetBool("Run", false);
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("Walk", false);
        }


        // Walk Back Code
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            playerAnimator.SetBool("Back", true);
            transform.position -= transform.forward * walkSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("Back", false);
        }


        // Rotation Code
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }

        // Jump Code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Jump");
        }
    }
}
