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
    Vector3 lastValidPosition;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        rigid = GetComponent<Rigidbody2D>();
        active = true;
        lastValidPosition = transform.position;
    }

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
        Vector3 newPosition = move * Time.deltaTime * speed + transform.position;

        // 이동 시도 전에 마지막으로 유효했던 위치 저장
        lastValidPosition = transform.position;
        transform.position = newPosition;
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
        // "INBorder" 태그와 충돌했을 때
        if (collision.gameObject.tag == "INBorder" && collision.gameObject.layer == LayerMask.NameToLayer("BorderIn"))
        {
            Debug.Log("경계에 부딪힘: 되돌아갑니다.");
            transform.position = lastValidPosition; // 플레이어를 마지막 유효 위치로 되돌림
        }

        // 예: 다른 충돌 처리
        if (collision.gameObject.tag == "jbullet")
        {
            if (i < lifes.Length)
            {
                Destroy(lifes[i]);
                diesound.Play();
                i++;
            }
            else
            {
                diesound.Play();
                active = false;
                gameObject.SetActive(false);
                restartButton.gameObject.SetActive(true);
            }
        }
    }
}

