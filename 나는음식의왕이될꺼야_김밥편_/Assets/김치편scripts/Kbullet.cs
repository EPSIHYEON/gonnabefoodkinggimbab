using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kbullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {

            Destroy(gameObject); // 

        }

    }
}
