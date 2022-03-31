using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOff : MonoBehaviour
{
    public GameObject SpawnObject;
    public GameObject HideObject;
    
    //On collision with the player an object will be activated and one will be disabled
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnObject.SetActive(true);
            HideObject.SetActive(false);
        }
    }
}
