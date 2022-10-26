using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPosChanger : MonoBehaviour
{
    // set cam distance
    public float camDistance = 1;
    public float camHeight = 5;
    public Transform target;

    public GameObject cam;
    Vector3 CameraPos = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get pos
        Vector3 pos = transform.position;
        // set object at same hieght as player
        transform.position = new Vector3(pos.x, target.position.y, pos.z);
        // make the object face the player
        transform.LookAt(target);

        // set the camera position 
        Vector3 camPos = (target.transform.position + transform.forward * camDistance + new Vector3(0, camHeight, 0));
        cam.transform.position = Vector3.Lerp(transform.position, camPos, 5f) ;
    }
}
