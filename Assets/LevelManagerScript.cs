using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public void LoadScene(string SafePassage)
    {
        SceneManager.LoadScene(SafePassage);
    }

}
