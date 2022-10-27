using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPosChanger : MonoBehaviour
{
    // set camera distance from point
    public float camDistance = 1;

    // set player as gameobject
    public Transform playerTarget;

    // get camera
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        // get positions
        Vector3 pos = transform.position;

        // set y pos to the player y
        transform.position = new Vector3(pos.x, playerTarget.position.y, pos.z);

        // look at player
        transform.LookAt(playerTarget);

        // set future camera position
        Vector3 futurePos = (transform.position + transform.forward * camDistance + new Vector3(0, 10, 0));

        // apply position
        cam.transform.position = Vector3.Lerp(transform.position, futurePos, 5f) ;
    }
}
