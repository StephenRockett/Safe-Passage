using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerHolder;


    public float jumpTimer;
    public bool crouch, Grounded;

    void Start()
    {
        crouch = false;
        Grounded = true;
    }

    void Update()
    {
        movement();
        //playerInteraction();
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerHolder.transform.Translate(5 * Time.deltaTime, 0, 0);

            //forward
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerHolder.transform.Translate(-5 * Time.deltaTime, 0, 0);

            //back
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            jumpTimer = 0.1f;
                Grounded = false;
                print("not grounded");
        }
        if (jumpTimer > 0)
        {
            playerHolder.transform.Translate(0, 100 * jumpTimer * Time.deltaTime, 0);

            jumpTimer -= 0.2f * Time.deltaTime;
        }
        else
        {
            jumpTimer = 0;
        }


        if (Input.GetKeyDown(KeyCode.S) && crouch == false)
        {
            crouch = true;
            //crouch
        }
        else if (Input.GetKeyDown(KeyCode.S) && crouch == true)
        {
            crouch = false;
            //uncrouch
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //interact
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //pickup phone
        }
    }

    void OnCollisionEnter()
    {

        if (gameObject.tag == "Ground")
        {
            Grounded = true;
            print("grounded");

        }

    }
}
