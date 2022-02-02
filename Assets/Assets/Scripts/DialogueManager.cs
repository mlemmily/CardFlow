using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject uiParent;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;

    public bool FirstSentence = true;

    //grabs the sentences for use
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Grabs all of the information for the text and creates a sequence using those sentences.
    public void StartDialogue(Dialogue dialogue)
    {
        if (FirstSentence == true)
        {
            nameText.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            FirstSentence = false;
            DisplayNextSentence();
        }
    }

    // Starts to go through all the esntences until there is no sentences left
    public void DisplayNextSentence()
    {
        if (FirstSentence == false)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                FirstSentence = true;
                return;
            }
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
    }

    // deletes the dialogue from the game and disables the talking variable for talking in another script
    void EndDialogue()
    {
        Debug.Log("End of Convo");
        FindObjectOfType<InstantiateDialogue>().SetTalkingFalse();
        Destroy(uiParent);
    }
}
