using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaformStickPlayer : MonoBehaviour
{

    bool inTrigger = false;

    GameObject player;
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        // gets player and parent of platform
        parent = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //if is moving an player on the platform
        if(inTrigger && parent.GetComponent<MovingPlatformController>().active)
        {
            // set the player position to above the platform
            player.transform.position = player.transform.position + transform.localPosition + new Vector3(0,1,0);
            Debug.Log(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
