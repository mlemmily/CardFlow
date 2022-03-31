using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject enemyHealthBarContainer;
    public HealthBar enemyHealthBar;

    [SerializeField] public Transform bearSpawnPos;
    [SerializeField] public Transform bearPrefab;

    //Sets the render for the enemy and sets the current health the the maximum on start
    void Start()
    {
        GameObject enemyRend = GameObject.FindWithTag("Enemy");
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
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
        enemyHealthBar.SetHealth(currentHealth);
    }

    //checks if the health is 0 to spawn a bear and delete the gameobject
    void Update()
    {
        if(currentHealth < 1)
        {
            Instantiate(bearPrefab, bearSpawnPos.position, Quaternion.LookRotation(Vector3.up));
            Destroy(enemyHealthBarContainer);
            Destroy(gameObject);
            currentHealth = 2;
        }
    }
}