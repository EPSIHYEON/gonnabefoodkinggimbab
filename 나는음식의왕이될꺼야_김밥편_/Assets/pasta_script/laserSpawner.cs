using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laserSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public GameObject laser;
    public Transform[] spawnPoints; // 8���� ��ġ�� ������ �迭
    public float spawnInterval = 1f; // �Ѿ��� �����Ǵ� ����
    public float speed = 10f;
    public Button restartButton;
    public GameObject blackout;
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
            if (!restartButton.gameObject.activeSelf && !blackout.gameObject.activeSelf)
            {
                SpawnBulletAtRandomPosition();
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                yield break; // �ڷ�ƾ�� ��� �����մϴ�.
            }
        }
    }

    void SpawnBulletAtRandomPosition()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        //GameObject laserr = Instantiate(laser, spawnPoint.position, spawnPoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb2 = laserr.GetComponent<Rigidbody2D>();

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
