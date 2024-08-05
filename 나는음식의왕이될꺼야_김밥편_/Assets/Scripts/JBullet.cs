using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBullet : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {

            Destroy(gameObject); // 

        }

    }

}

