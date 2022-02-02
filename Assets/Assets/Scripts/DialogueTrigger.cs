using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public float time = 0.8f;
    public float timer = Time.time;

    /*void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }*/

    //gets the users input based on a timer to disallow spam and start the dialogue
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            // On spacebar press, send dog
            if (Input.GetMouseButton(0))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                timer = 0;
            }
        }
    }
}
