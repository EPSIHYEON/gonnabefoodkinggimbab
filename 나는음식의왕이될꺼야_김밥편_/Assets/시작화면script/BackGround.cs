using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;  // ��������Ʈ�� �̵� �ӵ�
    public Transform sprite;  // �̵��� ��������Ʈ�� Transform

    float viewWidth;  // ȭ���� �ʺ�
    float spriteWidth;  // ��������Ʈ�� �ʺ�

    private void Awake()
    {
        // ī�޶��� orthographicSize�� ȭ�� ������ ����� ȭ�� �ʺ� ���
        viewWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        // ��������Ʈ�� �ʺ� ���
        spriteWidth = sprite.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // ��������Ʈ�� ���������� �̵�
        Vector3 curPos = sprite.position;
        Vector3 nextPos = Vector3.right * speed * Time.deltaTime;
        sprite.position = curPos + nextPos;

        // ��������Ʈ�� ���� �� �κ��� ȭ�� �ȿ� �����ߴ��� Ȯ��
        if (sprite.position.x - spriteWidth / 2 > viewWidth / 2)
        {
            // ��������Ʈ�� ȭ�� ���� ������ �ٽ� �̵�
            sprite.position = new Vector3(-viewWidth / 2 + spriteWidth / 2, sprite.position.y, sprite.position.z);
        }
    }
}
