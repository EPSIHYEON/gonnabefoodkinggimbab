using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pasta_shoot : MonoBehaviour
{
    public GameObject Pbullet;
    public AudioSource FlareGun;
    public Slider healhSlider;
   // Player 게임 오브젝트의 Transform을 참조
   
    public GameObject blackout;
    public Button restartButton;

    void Start()
    {

        Invoke("StartLate", 2f);
    }

     void Update()
    {
        if (healhSlider.value <= 0.3) {
            StopCoroutine(ShootPbulletRoutine());
        }
    }

    void StartLate() {
        StartCoroutine(ShootPbulletRoutine());
    }

    IEnumerator ShootPbulletRoutine()
    {
        if (!restartButton.gameObject.activeSelf && !blackout.gameObject.activeSelf)
        {
            shootPbullet();

            yield return new WaitForSeconds(5f);
            StartCoroutine(ShootPbulletRoutine());
        }
        else { yield break; }

    }


    void shootPbullet()
    {
        GameObject bullet = Instantiate(Pbullet, transform.position + Vector3.down * 1, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        FlareGun.Play();

        rb.velocity = Vector2.down * 30;
        Debug.Log("Boos하고있음");
    }
}
