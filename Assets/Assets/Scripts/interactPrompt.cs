using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPrompt : MonoBehaviour
{
    public GameObject interactPromptOnOff;

    //shows interact prompt when in range of an NPC
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            interactPromptOnOff.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            interactPromptOnOff.SetActive(false);
        }
    }
}
