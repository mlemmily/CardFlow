using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LoadScene;

    //closes the game 
    public void Exit()
    {
        Application.Quit();
    }

    //starts the first level
    public void StartLevel()
    {
      SceneManager.LoadScene(LoadScene);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("LevelSaved"))
        {
            string levelToLoad = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
