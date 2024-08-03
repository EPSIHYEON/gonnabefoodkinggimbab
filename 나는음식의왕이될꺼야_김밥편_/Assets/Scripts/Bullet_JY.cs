using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_JY : MonoBehaviour
{
    Rigidbody2D rigitbullet;

    void Start()
    {
        rigidbullet = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        straight();
    }
    
    void straight() {
        rigidbullet.velocity = transform.up * 10;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}