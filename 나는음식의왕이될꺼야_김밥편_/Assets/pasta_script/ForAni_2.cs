using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAni_2 : MonoBehaviour
{
    public float expandSpeed;  // �������� Ȯ��Ǵ� �ӵ�
    public float maxLength; // �������� �ִ� ����
    private Vector3 initialScale;   // �������� �ʱ� ũ��
    private Vector3 initialPosition; // �������� �ʱ� ��ġ

    void Start()
    {
        // �ʱ� ũ��� ��ġ�� ����
        initialScale = transform.localScale;
        initialPosition = transform.position;
    }

    void Update()
    {
        // �������� �������θ� Ȯ��ǵ��� ������ ����
        if (transform.localScale.y < maxLength)
        {
            float newScaleY = transform.localScale.y + expandSpeed * Time.deltaTime;
            if (newScaleY > maxLength)
            {
                newScaleY = maxLength;
            }
            transform.localScale = new Vector3(transform.localScale.x, newScaleY, transform.localScale.z);

            // �������� �ϴ� ��ġ�� ������Ű�� ���� Y�� ��ġ�� ����
            
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        }
    }

}

