using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public string LevelName;
    public GameObject CameraUI;
    public GameObject LoadingScreenUI;
    public GameObject DelOLDLoadingScreenUI;

    //Deletes the old loading screen on start to fix a bug where the loading screen wont delete and causes the game to break.
    void Start()
    {
        DelOLDLoadingScreenUI = GameObject.Find("LoadingScreen");
        Destroy(DelOLDLoadingScreenUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when a player collides with the trigger it will load the level set inside unity editor
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraUI.SetActive(false);
            LoadingScreenUI.SetActive(true);
            FindObjectOfType<LoadingScreen>().LoadScene(LevelName);
        }
    }
}
