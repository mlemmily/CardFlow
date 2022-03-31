using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public float time = 0.8f;
    public float timer = Time.time;

    public GameObject Player;

    public bool interactKey;

    /*void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }*/

    //grabs the player on start

    private void Start()
    {
        Player = GameObject.Find("PlayerParent");
    }

    //gets the users input based on a timer to disallow spam and start the dialogue
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            // On spacebar press, send dog
            if (Player.GetComponent<ThirdPersonController>().InteractOnOff)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                timer = 0;
                interactKey = false;
            }
        }

        if (Player.GetComponent<ThirdPersonController>().InteractOnOff)
        {
            interactKey = true;
        }
    }
}
