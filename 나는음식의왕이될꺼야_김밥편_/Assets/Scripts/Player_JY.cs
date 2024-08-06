using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_JY : MonoBehaviour
{
    public AudioSource diesound;
    public int speed;
    public GameObject bullets;
    public bool active = true;
    public Button restartButton;
    public Image[] lifes;
    private int i = 0;

    Rigidbody2D rigid;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        rigid = GetComponent<Rigidbody2D>();
        active = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            move();

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
            {
                shoot();
            }
        }

    }

    void move()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, v, 0);
        transform.position = move * Time.deltaTime * speed + transform.position;
    }

    void shoot()
    {
        Instantiate(bullets, transform.position, transform.rotation);
        Debug.Log("발사되고 있음");
    }


    public void Restart()
    {
        Debug.Log("재시작");

        SceneManager.LoadScene("JY2");

        active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jbullet")
        {
            if (i < lifes.Length)
            {
                Destroy(lifes[i]);
                diesound.Play();
                i++;
            }
            else{
                diesound.Play();
                active = false;
                gameObject.SetActive(false);
                restartButton.gameObject.SetActive(true);
            }
        }
    }


}
