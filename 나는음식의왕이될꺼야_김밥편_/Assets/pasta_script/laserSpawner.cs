using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laserSpawner : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject giantlaser;
    public GameObject Panel;
    public GameObject babBullet;
    public GameObject PBoss;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2; // �Ѿ� ������
    public GameObject[] laser;
    public Transform[] spawnPoints; // 8���� ��ġ�� ������ �迭
    public float spawnInterval = 1f; // �Ѿ��� �����Ǵ� ����
    public float speed = 10f;
    public Button restartButton;
    public GameObject blackout;
    public AudioSource laserout;
    public AudioSource laserout2;
    public AudioSource boom;
    public AudioSource Timer;
    public AudioSource GiantLaserSound;

    private bool active = true;
    private Coroutine spawnCoroutine;



    Rigidbody2D rb;
    
    private int previousIndex = -1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnCoroutine = StartCoroutine(SpawnBullets());
        babBullet.SetActive(true);



    }

   void Update()
    {
        if (healthSlider.value <= 0.3f)
        {
            PBoss.SetActive(false);
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine); // Coroutine ��ü�� �����Ͽ� ����
                spawnCoroutine = null; // Coroutine ������ �ʱ�ȭ
                Debug.Log("healthSlider�� 0.3 �����Դϴ�! �ڷ�ƾ ������.");
                Invoke("GiantLaser",4f);
                Invoke("createPanel", 10f);
            }
        }
    }

    void GiantLaser() {
        
        giantlaser.SetActive(true);
        GiantLaserSound.Play();
        Timer.Play();

       
           }

    void createPanel() {
        giantlaser.SetActive(false);
        Panel.SetActive(true);
    }



    IEnumerator SpawnBullets()
    {
        while (true)
        {
            if (!restartButton.gameObject.activeSelf && !blackout.gameObject.activeSelf && active == true)
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

        int randomIndex;
        if (healthSlider.value < 0.3)
        {
            StopCoroutine(SpawnBullets());
            Debug.Log("healthSlider�� 0.3 �����Դϴ�! �ڷ�ƾ ������.");
        }

        if (healthSlider.value < 0.8 ) {
            randomIndex = GetRandomIndexExcludingPrevious2();
            Debug.Log("2������ �Դϴ�");
        }
        else { randomIndex = GetRandomIndexExcludingPrevious1(); Debug.Log("1������ �Դϴ�"); }
        previousIndex = randomIndex;
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject bullet;
        Rigidbody2D rb;

        if (randomIndex >= 0 && randomIndex < 9)
        {
            bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            bullet = Instantiate(bulletPrefab2, spawnPoint.position, spawnPoint.rotation);
        }

        rb = bullet.GetComponent<Rigidbody2D>();


        //Rigidbody2D rb2 = laserr.GetComponent<Rigidbody2D>();



        if (randomIndex == 0 || randomIndex == 1 || randomIndex == 2)
            {
                ActivateLaser(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(0, -1).normalized * speed, randomIndex));

            }
            else if (randomIndex == 3 )
            {
                ActivateLaser(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(5, -1).normalized * speed, randomIndex));

            }
             else if ( randomIndex == 4)
             {
            ActivateLaser(randomIndex);
            StartCoroutine(Delay(rb, new Vector2(5, -5).normalized * speed, randomIndex));

               }
        // ������ ��쿡 ���� �ӵ� ���� �߰� ����
        else if (randomIndex == 5 )
            {
                ActivateLaser(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(-5, -5).normalized * speed, randomIndex));
            }

            else if (randomIndex == 6)
             {
            ActivateLaser(randomIndex);
            StartCoroutine(Delay(rb, new Vector2(-5, -1).normalized * speed, randomIndex));
              }

        else if (randomIndex == 7)
            {
                ActivateLaser(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(5, -1).normalized * speed, randomIndex));
            }

            else if (randomIndex == 8)
            {
                ActivateLaser(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(-5, -1).normalized * speed, randomIndex));
            }

            else if (randomIndex == 9) //2
            {
                ActivateLaser2(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(0, -1).normalized * speed, randomIndex));
            }

            else if (randomIndex == 10) //3
            {
                ActivateLaser2(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(5, -3).normalized * speed, randomIndex));
            }

            else if (randomIndex == 11) //6
            {
                ActivateLaser2(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(-5, -3).normalized * speed, randomIndex));
            }

            else if (randomIndex == 12) //8
            {
                ActivateLaser2(randomIndex);
                StartCoroutine(Delay(rb, new Vector2(-5, -1).normalized * speed, randomIndex));
            }

        

       
    }

    int GetRandomIndexExcludingPrevious1()
    {
        int newIndex;
        do
        {
            newIndex = Random.Range(0, 9);
        } while (newIndex == previousIndex);
        return newIndex;
    }

    int GetRandomIndexExcludingPrevious2()
    {
        int newIndex;
        do
        {
            newIndex = Random.Range(7, spawnPoints.Length);
        } while (newIndex == previousIndex);
        return newIndex;
    }


    void ActivateLaser(int index)
    {
        if (index >= 0 && index < laser.Length)
        {
            laser[index].SetActive(true);
            laserout.Play();
        }
        else
        {
            Debug.LogWarning($"Index {index} is out of bounds for lasers array");
        }
    }

    void ActivateLaser2(int index)
    {
        if (index >= 0 && index < laser.Length)
        {
            laser[index].SetActive(true);
            laserout2.Play();
        }
        else
        {
            Debug.LogWarning($"Index {index} is out of bounds for lasers array");
        }
    }

    IEnumerator Delay(Rigidbody2D rb, Vector2 velocity, int index)
    {
        yield return new WaitForSeconds(1.5f); 
        if (index >= 0 && index < laser.Length)
        {
            laser[index].SetActive(false);
        }
        boom.Play();
        rb.velocity = velocity;
    }
}


