using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBullet : MonoBehaviour
{
    public float speed = 100.0f;
    public float lifetime = 3.0f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = lifetime;
    }

    void Update()
    {
        // Bullet moves forward!
        transform.position += transform.forward * speed * Time.deltaTime;

        // Destroy bullet after timer == 0
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }
}
