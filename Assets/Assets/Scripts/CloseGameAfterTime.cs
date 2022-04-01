using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CloseGameAfterSeconds());
    }

    IEnumerator CloseGameAfterSeconds()
{
    {
        yield return new WaitForSeconds(5.5f);
        Application.Quit();
    }
}
}
