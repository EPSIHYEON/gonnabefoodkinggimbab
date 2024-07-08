using System.Collections;
using UnityEngine;

public class B_Bullet : MonoBehaviour
{
    public GameObject bulletObjA;
    public int bulletCount = 100; // 발사할 총알 수

    void Start()
    {
        StartCoroutine(FireCircleRoutine());
    }

    IEnumerator FireCircleRoutine()
    {
        while (true)
        {
            FireCircle();
            yield return new WaitForSeconds(1f);
        }
    }

    void FireCircle()
    {
        Debug.Log("원 모양으로 발사");

        float angleStep = 360f / bulletCount; // 각도 간격

        for (int i = 0; i < bulletCount; i++)
        {
            // 각도를 라디안으로 변환
            float angleInRadians = (angleStep * i) * Mathf.Deg2Rad;

            GameObject bulletInstance = Instantiate(bulletObjA, transform.position, Quaternion.identity);
            Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D>();

            // 라디안으로 변환된 각도를 사용하여 방향 벡터 계산
            rigid.AddForce(new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)).normalized * 5, ForceMode2D.Impulse);
        }
    }
}
