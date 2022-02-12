using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SecretCounter : MonoBehaviour
{
    
    public TextMeshProUGUI SecretCounterNumber;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        Player = GameObject.Find("PlayerParent");
    }

    /*void AddToCounter()
    {
        SecretCount =+ 1;
    }*/

    private void Update()
    {
       if(SecretCountDataHolder.SecretCount ==1 )
       {
           SecretCounterNumber.text = "1";
       }

       if(SecretCountDataHolder.SecretCount ==2 )
       {
           SecretCounterNumber.text = "2";
       }

       if(SecretCountDataHolder.SecretCount ==3 )
       {
           SecretCounterNumber.text = "3";
       }
    }
    
}
