using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public string LevelName;
    void Start()
    {
        
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
            SceneManager.LoadScene(LevelName); 
        }
    }
}
