using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject buttonTarget;

    //sets moving platform to false
    bool MP = false;


    bool inTrigger = false;
    void Start()
    {
        if(buttonTarget.tag == "MovingPlatform")
        {
            MP = true;
            //Debug.Log("MP is true");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && MP && Input.GetKeyDown(KeyCode.E))
        {
            buttonTarget.GetComponent<MovingPlatformController>().Move();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }

}
