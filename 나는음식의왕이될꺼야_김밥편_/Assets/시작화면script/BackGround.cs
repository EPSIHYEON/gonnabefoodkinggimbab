using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;  // 스프라이트의 이동 속도
    public Transform sprite;  // 이동할 스프라이트의 Transform

    float viewWidth;  // 화면의 너비
    float spriteWidth;  // 스프라이트의 너비

    private void Awake()
    {
        // 카메라의 orthographicSize와 화면 비율을 사용해 화면 너비 계산
        viewWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        // 스프라이트의 너비 계산
        spriteWidth = sprite.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // 스프라이트를 오른쪽으로 이동
        Vector3 curPos = sprite.position;
        Vector3 nextPos = Vector3.right * speed * Time.deltaTime;
        sprite.position = curPos + nextPos;

        // 스프라이트의 왼쪽 끝 부분이 화면 안에 도달했는지 확인
        if (sprite.position.x - spriteWidth / 2 > viewWidth / 2)
        {
            // 스프라이트를 화면 왼쪽 끝으로 다시 이동
            sprite.position = new Vector3(-viewWidth / 2 + spriteWidth / 2, sprite.position.y, sprite.position.z);
        }
    }
}
