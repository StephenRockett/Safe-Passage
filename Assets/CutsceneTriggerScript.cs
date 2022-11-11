using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTriggerScript : MonoBehaviour
{
    public GameObject player, ScriptTurnOff, vpCamera;


    public GameObject vpTut1, vpTut2, vpFall;
    public GameObject GOvpTut1, GOvpTut2, GOvpFall;

    public bool cutWasPlaying, cutIsPlaying;
    float cutPlaying;
    void Start()
    {
        cutPlaying = 0;
    }

    void OnTriggerEnter(Collider TutColl)
    {
        if (TutColl.transform.tag == "vpTut1Coll")
        {
            print("vpTut1Coll");
            cutPlaying = 9.9f;
            vpTut1.SetActive(true);
            GOvpTut1.SetActive(false);
        }
        if (TutColl.transform.tag == "vpTut2Coll")
        {
            print("vpTut2Coll");
            cutPlaying = 7.9f;
            vpTut2.SetActive(true);
            GOvpTut2.SetActive(false);
        }
        if (TutColl.transform.tag == "vpFallColl")
        {
            print("vpTutFall");
            cutPlaying = 2.5f;
            vpFall.SetActive(true);
        }
    }

    void Update()
    {


        if (cutPlaying > 0)
        {
            ScriptTurnOff.SetActive(false);
            vpCamera.SetActive(true);
            cutPlaying -= 1 * Time.deltaTime;
        }
        else if (cutPlaying <= 0)
        {
            ScriptTurnOff.SetActive(true);
            cutPlaying = 0;
            vpCamera.SetActive(false);

            vpTut1.SetActive(false);
            vpTut2.SetActive(false);
            vpFall.SetActive(false);
        }




    }
}
