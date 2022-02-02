using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;


    //sets the rigid body when the object gets active
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    //on start of the bullet projectiles script it will set the speed and start the destroy coroutine
    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
        StartCoroutine(DestroyAfterTime());
    }
    //destroys the bullet on collision with a trigger
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    //After 2 seconds the object will be deleted if not destroyed from colliding
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
