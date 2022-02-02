using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject[] enemies;  
    public Vector3 spawnValues;  
    public float spawnWait;  
    public float spawnMostWait;  
    public float spawnLeastWait;  
    public int startWait;  
    public bool stop;  
  
    int randEnemy;  


    //starts a wait timer
    void Start() {  
        StartCoroutine(waitSpawner());  
    }  
  
    //sets a random spawn time from a set range
    void Update() {  
        spawnWait = Random.Range(spawnMostWait, spawnMostWait);  
    }  
  
    //spawns enemies
    IEnumerator waitSpawner() {  
        yield  
        return new WaitForSeconds(startWait);  
  
        while (!stop) {  
            randEnemy = Random.Range(0, 2);  
  
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1f, Random.Range(-spawnValues.z, spawnValues.z));  
  
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);  
  
            yield  
            return new WaitForSeconds(spawnWait);  
        }  
    }  
}
