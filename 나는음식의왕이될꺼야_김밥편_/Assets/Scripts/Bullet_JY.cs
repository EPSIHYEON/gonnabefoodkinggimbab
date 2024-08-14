using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_JY : MonoBehaviour
{
    Rigidbody2D rigidbullet;

     void Start()
    {
        rigidbullet = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        straight();
    }
    
    void straight() {
        rigidbullet.velocity = transform.up * 500;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}