using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspawner : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform[] spawnPoints; // 8���� ��ġ�� ������ �迭
    public float spawnInterval = 1f; // �Ѿ��� �����Ǵ� ����
    public float speed = 10f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            SpawnBulletAtRandomPosition();
            yield return new WaitForSeconds(spawnInterval);
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
            // ������ ��쿡 ���� �ӵ� ���� �߰� ����
            else if (randomIndex == 5 || randomIndex == 6)
            {
                rb.velocity = new Vector2(-5, -3).normalized * speed;
            }
        }
    }

}

    
