using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    GameObject pointA;
    GameObject pointB;

    GameObject platform;

    public float speed = 1f;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.Find("pointA").gameObject;
        pointB = transform.Find("pointB").gameObject;
        platform = transform.Find("platform").gameObject;

        platform.transform.position = pointA.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (active)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointB.transform.position, step);
        }else if (!active)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointA.transform.position, step);
        }
        else
        {
            platform.transform.position = pointA.transform.position;
        }
    }

    void PAtoPB()
    {
        active = true;
    }

    void PBtoPA()
    {
        active = false;
    }

    public void Move()
    {
        if (active)
        {
            PBtoPA();
        }
        else
        {
            PAtoPB();
        }
    }
}
