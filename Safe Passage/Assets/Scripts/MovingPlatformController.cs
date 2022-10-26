using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;

    GameObject platform;

    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        platform = gameObject.transform.Find("platform").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.Lerp(platform.transform.position, point1.transform.position, 1f * Time.deltaTime);

    }

    public void Move()
    {
        moving = true;
        platform.transform.position = Vector3.Lerp(platform.transform.position, point2.transform.position, 1f * Time.deltaTime);
        Debug.Log(platform.transform.position);
    }

}
