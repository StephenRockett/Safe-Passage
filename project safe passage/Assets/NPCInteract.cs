using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteract : MonoBehaviour
{

    public List<string> lines = new List<string>();
    public TextMeshPro textBox;

    public string firstLine = "";

    bool inTrigger = false;

    int lineNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        lines.Insert(0, firstLine);
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            lineNumber++;

            if(lineNumber > lines.Count - 1)
            {
                lineNumber = 0;
            }
        }

        textBox.text = lines[lineNumber];
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
