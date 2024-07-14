using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 김치Boss : MonoBehaviour
{
    public GameObject Kbullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootKbulletRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator ShootKbulletRoutine() {
        
            shootKbullet();

            yield return new WaitForSeconds(1f);
        StartCoroutine(ShootKbulletRoutine());

    }


    void shootKbullet() {
        GameObject bullet = Instantiate(Kbullet, transform.position + Vector3.down * 1, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * 10;
        Debug.Log("Boos하고있음");
    }
}
