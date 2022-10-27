using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player settings
    public float speed =12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float mass = 1f;

    // velocity of player
    Vector3 velocity;

    // player controller
    public CharacterController controller;

    // gamebobject for ground check
    public Transform groundCheck;

    // ground distance
    public float groundDistance = 1f;

    // sets the layer that the ground is on
    public LayerMask groundMask;

    bool isGrounded;

    // rotation point of world
    public Transform centerTarget;

    void FixedUpdate()
    {
        // makes a sphere at ground check pos andcheck if ground layer is in it
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // gets player movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        // does math to calculate player pos
        Vector3 move = transform.right * x + transform.forward * z;

        // moves the player via controller
        controller.Move(move * speed * Time.deltaTime);

        // jump script and velocity
        JumpAndGravity();

    }

    private void Update()
    {
        //changes where the player is looking
        ChangeDirection();
    }

    void JumpAndGravity()
    {
        // if the player wants to jump and is on ground
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpHeight;
        }
        // if the player is not grounded
        else if (!isGrounded)
        {
            velocity.y += gravity * mass * Time.deltaTime;
        }
        // make sure the player is not moving or building up velocity
        else
        {
            velocity.y = 0;
        }

        // makes the jump fall or jump
        controller.Move(velocity * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // look at target (middle of world)
        transform.LookAt(centerTarget);
    }
}
