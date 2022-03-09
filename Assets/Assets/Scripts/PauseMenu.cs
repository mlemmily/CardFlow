using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject controlsMenu;
    public bool menuKey = false;
    public bool Paused = false;
    public GameObject Player;

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

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        controlsMenu.SetActive(false);
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneID);
    }
}
