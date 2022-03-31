using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject controlsMenu;
    public bool menuKey = false;
    public bool Paused = false;
    public GameObject Player;

    //Checks if the player has pressed the menu button and enables the UI.
    // if the player presses it again, it will close the UI
    void Update()
    {
        if (menuKey == true && Paused == false)
        {
            Pause();
            Paused = true;
            menuKey = false;
            return;
        }

        if (menuKey == true && Paused == true)
        {
            Resume();
            Paused = false;
            menuKey = false;
            return;
        }

        if (Player.GetComponent<ThirdPersonController>().MenuOnOff)
        {
            menuKey = true;
            return;
        }
    }

    //Pauses the game by setting the game speed to 0
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    //Resumes the game and disables the UI on resume.
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    //Sends the player to the main menu
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneID);
    }
}
