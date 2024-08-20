using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class J_Boss : MonoBehaviour
{
    public GameObject Jbullet;
    public Transform player; // Player 게임 오브젝트의 Transform을 참조
    public float followDelay;
    public float smoothTime = 0.3f;
    public GameObject blackout;
    public Button restartButton;
    public int numberOfBullets = 8; // 발사할 총알의 개수
    public float bulletSpread = 360; // 총알의 발사 범위 (360도 원형)

    private Queue<float> playerPositions = new Queue<float>();
    private float velocity = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootJbulletRoutine());
        StartCoroutine(FollowPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = player.position.x;

        // Player의 따라갈 위치를 계산 (따라갈 시점: followDelay 후)
        float delayedXPosition = GetDelayedXPosition(followDelay);
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.SmoothDamp(currentPosition.x, delayedXPosition, ref velocity, smoothTime);
        transform.position = currentPosition;
    }


    float GetDelayedXPosition(float delay)
    {
        // Player의 x 위치를 가져옴
        float playerX = player.position.x;

        // delay 시간 전의 Player의 x 위치를 계산
        float delayedX = playerX;
        if (Time.time - Time.deltaTime - delay > 0)
        {
            delayedX = player.position.x - ( delay);
        }

        return delayedX;
    }

    IEnumerator ShootJbulletRoutine() {
        if (!restartButton.gameObject.activeSelf && !blackout.gameObject.activeSelf)
        {  
            shootJbullet();
            yield return new WaitForSeconds(1f);
            StartCoroutine(ShootJbulletRoutine());
        }
        else { yield break; }

    }



    IEnumerator FollowPlayer()
    {
        if (playerPositions.Count == Mathf.RoundToInt(followDelay / Time.deltaTime))
        {
            // 큐에서 가장 오래된 Player의 x 위치로 Boss의 x 위치 업데이트
            float delayedXPosition = playerPositions.Dequeue();
            transform.position = new Vector3(delayedXPosition, transform.position.y,0);
        }

        // 다음 프레임까지 대기
        yield return null;
        StartCoroutine(FollowPlayer());
    }

    void shootJbullet() {
        float angleStep = bulletSpread / numberOfBullets;
        float angle = 0f;

        List<GameObject> bullets = new List<GameObject>();

        for (int i = 0; i < numberOfBullets; i++)
        {
            float bulletDirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector3 bulletMoveDirection = new Vector3(bulletDirX, bulletDirY, 0f);
            GameObject bullet = Instantiate(Jbullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // 방향 벡터를 정규화하여 정확한 방향으로 발사
            rb.velocity = bulletMoveDirection.normalized * 500f;

            bullets.Add(bullet);

            angle += angleStep;
        }

        // 총알들끼리 충돌 무시 설정
        for (int i = 0; i < bullets.Count; i++)
        {
            Collider2D bulletCollider = bullets[i].GetComponent<Collider2D>();

            for (int j = i + 1; j < bullets.Count; j++)
            {
                Collider2D otherBulletCollider = bullets[j].GetComponent<Collider2D>();
                if (bulletCollider != null && otherBulletCollider != null)
                {
                    Physics2D.IgnoreCollision(bulletCollider, otherBulletCollider);
                }
            }
        }

        Debug.Log("Boss가 원형으로 총알 발사 중");
    }

}

