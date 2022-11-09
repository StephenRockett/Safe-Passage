using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lookAt.GetComponent<YPosChanger>().CameraPos);
        //transform.position = lookAt.GetComponent<YPosChanger>().CameraPos;
    }
}
