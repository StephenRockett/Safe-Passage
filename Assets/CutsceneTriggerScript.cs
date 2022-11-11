using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTriggerScript : MonoBehaviour
{
    public GameObject player, ScriptTurnOff, vpCamera, blackScreen;


    public GameObject vpTut1, vpTut2, vpFall, vpIntro, vpEnd, vpDoct;
    public GameObject GOvpTut1, GOvpTut2, GOvpFall, GOvpIntro, GOvpEnd, GOvpDoct;

    public bool cutWasPlaying, cutIsPlaying;
    float cutPlaying;
    void Start()
    {
        cutPlaying = 0;
        blackScreen.SetActive(false);
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
        if (TutColl.transform.tag == "vpIntroColl")
        {
            print("vpIntroColl");
            cutPlaying = 15f;
            vpIntro.SetActive(true);
            GOvpIntro.SetActive(false);
        }
        if (TutColl.transform.tag == "vpDoctColl")
        {
            print("vpDoctFall");
            cutPlaying = 5f;
            vpDoct.SetActive(true);
            GOvpDoct.SetActive(false);
        }


        if (TutColl.transform.tag == "vpEndColl")
        {
            if (GOvpDoct.activeInHierarchy == false)
            {
                print("vpEndColl");
                cutPlaying = 30f;
                vpEnd.SetActive(true);
                GOvpEnd.SetActive(false);
                blackScreen.SetActive(true);
            }
            
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
            vpIntro.SetActive(false);
            vpEnd.SetActive(false);
            vpDoct.SetActive(false);
        }




    }
}
