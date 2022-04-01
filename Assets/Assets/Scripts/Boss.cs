using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject bossHealthBarContainer;
    public HealthBar bossHealthBar;
    public GameObject BossEnemy;

    public GameObject BossDialogue;

    public GameObject loadingScreen;
    public string LevelName;

    [SerializeField] public Transform bearSpawnPos;
    [SerializeField] public Transform bearPrefab;

    //Sets the render for the enemy and sets the current health the the maximum on start
    void Start()
    {
        GameObject enemyRend = GameObject.FindWithTag("Enemy");
        currentHealth = maxHealth;
        bossHealthBar.SetMaxHealth(maxHealth);
        BossEnemy.GetComponent<EnemyAiSHOOT>().enabled = true;
        bossHealthBarContainer.SetActive(true);
        Destroy(BossDialogue);
    }

    //Removes the enemies health if they come in contact with a card.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Card")
        {
            TakeDamage(20);
            Debug.Log("test");
        }

        if (collision.gameObject.tag == "QuickCard")
        {
            TakeDamage(3);
            Debug.Log("test");
        }
    }

    //the variable which removes health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bossHealthBar.SetHealth(currentHealth);
        if(currentHealth < 300)
        {
            BossEnemy.GetComponent<EnemyAiSHOOT>().enabled = false;
            BossEnemy.GetComponent<EnemyAiMELEE>().enabled = true;
        }
    }

    //checks if the health is 0 to spawn a bear and delete the gameobject finishing off by loading the last scene
    void Update()
    {
        if (currentHealth < 1)
        {
            loadingScreen.SetActive(true);
            FindObjectOfType<LoadingScreen>().LoadScene(LevelName);
            Instantiate(bearPrefab, bearSpawnPos.position, Quaternion.LookRotation(Vector3.up));
            Destroy(bossHealthBarContainer);
            Destroy(gameObject);
            currentHealth = 2;
        }
    }
}
