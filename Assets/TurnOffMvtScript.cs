using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMvtScript : MonoBehaviour
{
    public GameObject ScriptTurnOff;
    public GameObject Player;
    public Collider BarrierColl;
    float timer;

    void Start()
    {
        timer = 0;
    }
    void OnTriggerEnter(Collider BarrierColl)
    {
        print("coll enter");
        if (BarrierColl.transform.tag == "DeathBarrier")
        {
            print("barrier coll enter");
            this.GetComponent<PlayerController>().enabled = false;
            Player.transform.position = new Vector3(34, 48.6f, 29);
            timer = 1;
        }
    }

    void Update()
    {
        
        if (timer < 0)
        {
            timer = 0;
            this.GetComponent<PlayerController>().enabled = true;
        }
        if (timer == 0)
        {
            this.GetComponent<PlayerController>().enabled = true;
        }

        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
            this.GetComponent<PlayerController>().enabled = false;
        }
        if (ScriptTurnOff.activeInHierarchy==false)
        {
            this.GetComponent<PlayerController>().enabled = false;
        }
    }
}
