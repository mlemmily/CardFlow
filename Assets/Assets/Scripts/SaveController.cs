using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{

    //Saves a string of characters for the main menu continue game button to be read and accessed
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            string activeScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("LevelSaved", activeScene);

            Debug.Log(activeScene);

            gameObject.SetActive(false);
        }
    }
}
