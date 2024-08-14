using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletspawner : MonoBehaviour
{
  
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform[] spawnPoints; // 8개의 위치를 저장할 배열
    public float spawnInterval = 1f; // 총알이 생성되는 간격
    public float speed = 10f;
    public Button restartButton;
    public GameObject blackout;
    public AudioSource BackgroundSound;
    Rigidbody2D rb;
    void Start()
    {
        BackgroundSound.Play();
        rb = GetComponent<Rigidbody2D>();


        StartCoroutine(SpawnBullets());

      
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            if (!restartButton.gameObject.activeSelf && !blackout.gameObject.activeSelf)
            {
                SpawnBulletAtRandomPosition();
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                BackgroundSound.Pause();
                yield break; // 코루틴을 즉시 종료합니다.
            }
        }
    }

    void SpawnBulletAtRandomPosition()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            if (randomIndex == 0 || randomIndex == 1 || randomIndex == 2)
            {
                rb.velocity = new Vector2(0, -1).normalized * speed;
            }
            else if (randomIndex == 3 || randomIndex == 4)
            {
                rb.velocity = new Vector2(5, -3).normalized * speed;
            }
            // 나머지 경우에 대한 속도 설정 추가 가능
            else if (randomIndex == 5 || randomIndex == 6)
            {
                rb.velocity = new Vector2(-5, -3).normalized * speed;
            }
        }
    }

}

    
