using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPosChanger : MonoBehaviour
{
    public float camDistance = 1;
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
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, target.position.y, pos.z);
        transform.LookAt(target);
        cam.transform.position = Vector3.Lerp(transform.position, (transform.position + transform.forward * camDistance + new Vector3(0, 10, 0)), 5f) ;
    }
}
