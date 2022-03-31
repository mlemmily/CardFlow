using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy owning GameObject if any collider with a specific tag is trespassing
public class DestroyProjectileOnContact : MonoBehaviour
{

    //Starts a countdown when projectiles are spawned to remove cluster of projectiles which can impact performance
    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    //destroys the projectiles on contact with objects
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    //destroys the projectiles on contact with objects
    void OnCollisionEnter(Collider collision)
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
