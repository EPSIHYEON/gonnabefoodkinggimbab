using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class J_Boss : MonoBehaviour
{
    public GameObject JBullet;
    public Transform player;
    public float followDelay;
    public float smoothTime = 0.3f;
    public GameObject blackout;
    public Button restartButton;
    private Queue<float> playerPositions = new Queue<float>();
    private float velocity = 0.0f;

    void Start()
    {
        StartCoroutine(ShootJbulletRoutine());
        StartCoroutine(FollowPlayer());
    }

    void Update()
    {
        float targetX = player.position.x;

        float delayedXPosition = GetDelayedXPosition(followDelay);
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.SmoothDamp(currentPosition.x, delayedXPosition, ref velocity, smoothTime);
        transform.position = currentPosition;
    }


    float GetDelayedXPosition(float delay)
    {
        float playerX = player.position.x;

        float delayedX = playerX;
        if (Time.time - Time.deltaTime - delay > 0)
        {
            delayedX = player.position.x - (delay);
        }

        return delayedX;
    }


    IEnumerator ShootJbulletRoutine() {
        if (!restartButton.gameObject.activeSelf && !blackout.gameObject.activeSelf)
        {
            ShootJbullet();

            yield return new WaitForSeconds(1f);
            StartCoroutine(ShootJbulletRoutine());
        }
        else { yield break; }
    }


    IEnumerator FollowPlayer()
    {
        if (playerPositions.Count == Mathf.RoundToInt(followDelay / Time.deltaTime))
        {
            float delayedXPosition = playerPositions.Dequeue();
            transform.position = new Vector3(delayedXPosition, transform.position.y, 0);
        }

        yield return null;
        StartCoroutine(FollowPlayer());
    }

    void ShootJbullet() {
        GameObject bullet = Instantiate(JBullet, transform.position + Vector3.down * 1, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * 10;
    }
}