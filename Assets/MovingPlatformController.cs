using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    GameObject pointA;
    GameObject pointB;
    public GameObject ScriptTurnOff;
    public float timer;
    bool activeIsTrue, activeWasTrue;

    public GameObject platform, player;

    public float speed = 1f;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.Find("pointA").gameObject;
        pointB = transform.Find("pointB").gameObject;
        platform = transform.Find("platform").gameObject;

        platform.transform.position = pointA.transform.position;
        timer = 0;
        active = false;
        activeIsTrue = false;
        activeWasTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (active)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointB.transform.position, step);
            activeIsTrue = true;

        }
        else if (!active)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointA.transform.position, step);
            activeIsTrue = false;
        }
        else
        {
            platform.transform.position = pointA.transform.position;
            
        }

        if ((activeWasTrue && !activeIsTrue)|| (!activeWasTrue && activeIsTrue) && timer == 0)
        {
            timer = 1;
        }

        if (timer > 0)
        {
            player.transform.parent = platform.transform;
            ScriptTurnOff.SetActive(false);
            timer -= 1 * Time.deltaTime;
        }
        else if (timer <= 0)
        {
            ScriptTurnOff.SetActive(true);
            Transform player = platform.transform.Find("Player");
            //player.parent = null;
            timer = 0;
        }

        if (activeIsTrue)
        {
            activeWasTrue = true;
        }
        else
        {
            activeWasTrue = false;
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
