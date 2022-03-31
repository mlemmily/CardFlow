using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int checkpointRestarts;

    public HealthBar healthBar;

    public bool EnableKillBoxDamage = false;

    private GameObject Menu;

    public float SecretCountPlayer;

    public GameObject SecretBox;

    //sets the players health to max on start
    void Start()
    {
        currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
    }
    void Awake()
    {
        SecretBox = GameObject.Find("SecretBox");
    }

    //if the player touches an enemy they take damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        } 
    }

    //sets the player to take damage with any trigger tagged as specified and sets the killbox if in contact
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }

        if (other.gameObject.tag == "KillBox")
        {
            EnableKillBoxDamage = true;
        }

        //ADDS ONTO SECRET COUNTER
        if (other.gameObject.tag == "SecretBox")
        {
            SecretCountDataHolder.SecretCount += 1;
            Debug.Log("works?");
        }
    }

    //disables the killbox on leave
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "KillBox")
        {
            EnableKillBoxDamage = false;
        }      
    }

    //The logic for taking damage and checking if the player has lost all their life more than twice
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);

        if(currentHealth < 2)
        {
            checkpointRestarts++;
            currentHealth = maxHealth;
        }
    }

    //restarts the level if the player dies 3 times
    public void Update()
    {
        if(checkpointRestarts == 3)
        {
            Application.LoadLevel (Application.loadedLevel);
        }

        if(EnableKillBoxDamage == true)
        {
            StartCoroutine(KillBoxDamage());
        }
    }

    //makes the player take a small amount of damage per second until they die
    IEnumerator KillBoxDamage()
    {
        TakeDamage(1);
        EnableKillBoxDamage = false;
        yield return new WaitForSeconds(0.0225f);
        EnableKillBoxDamage = true;
    }
}
