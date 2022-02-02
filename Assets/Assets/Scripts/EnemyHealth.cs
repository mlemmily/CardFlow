using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] public Transform bearSpawnPos;
    [SerializeField] public Transform bearPrefab;

    //Sets the render for the enemy and sets the current health the the maximum on start
    void Start()
    {
        GameObject enemyRend = GameObject.FindWithTag("Enemy");
        currentHealth = maxHealth;
    }

    //Removes the enemies health if they come in contact with a card.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Card")
        {
            TakeDamage(20);
            Debug.Log("test");
        }
    }

    //the variable which removes health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    //checks if the health is 0 to spawn a bear and delete the gameobject
    void Update()
    {
        if(currentHealth < 1)
        {
            Instantiate(bearPrefab, bearSpawnPos.position, Quaternion.LookRotation(Vector3.up));
            Destroy(gameObject);
            currentHealth = 2;
        }
    }
}