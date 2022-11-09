using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaformStickPlayer : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.parent = null;
        }
    }
}
