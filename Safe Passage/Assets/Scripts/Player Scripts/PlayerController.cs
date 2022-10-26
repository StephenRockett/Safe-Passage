//brackey tutorial script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed =12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float mass = 1f;

    Vector3 velocity;

    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    bool isGrounded;

    bool lookToggle;

    public Transform target;

    public GameObject test;

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        

        if(isGrounded && velocity.y < 0.1)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        

        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight);
        }

        velocity.y += gravity * mass * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        testing();
    }

    void Rotate(float dir)
    {
        if(dir > 0)
        {
            transform.Find("model").gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Update()
    {
        ChangeDirection();
    }

    void ChangeDirection()
    {
        transform.LookAt(target);
    }

    void testing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            test.GetComponent<MovingPlatformController>().Move();
        }
    }
}
