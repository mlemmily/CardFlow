using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BossDialogue : MonoBehaviour
{
    public bool Talking = false;
    public bool isInRange = false;
    public GameObject DialogueBox;

    public GameObject Player;
    public GameObject Boss;
    public GameObject InteractPrompt;

    public bool interactKey;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerParent");
    }

    //Checks if the player is in range and is currently not talking and starts it if so, if not the dialogue wont start
    void Update()
    {
        if (interactKey == true && Talking == false && isInRange)
        {
            Talking = true;
            Instantiate(DialogueBox);
            interactKey = false;
        }

        if(Player.GetComponent<ThirdPersonController>().InteractOnOff)
        {
            interactKey = true;
        }
    }

    //checks if the player is in range
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            isInRange = true;
    }

    //checks if the player is out of range
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isInRange = false;
    }


    public void SetTalkingFalse()
    {
        StartCoroutine(EndTalking());
        //Talking = false;
    }

    IEnumerator EndTalking()
    {
        Boss.SetActive(true);
        InteractPrompt.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        Talking = false;
    }


    public void InteractKeyTrue()
    {
        interactKey = true;
                Debug.Log("InteractKeyFalse");
    }

    public void InteractKeyFalse()
    {
        interactKey = false;
        Debug.Log("InteractKeyTruee");
    }
}
