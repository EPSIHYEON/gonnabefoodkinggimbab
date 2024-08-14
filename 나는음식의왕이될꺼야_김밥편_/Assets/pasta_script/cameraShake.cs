using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Transform cameraTransform;  // ī�޶��� Transform�� ����
    public float shakeDuration = 8f; // ��鸲 ���� �ð� (8�ʷ� ����)
    public float shakeMagnitude = 0.2f; // ��鸲 ����
    public float dampingSpeed = 0.1f;  // ���� �ӵ� (���� ������ ����)

    private Vector3 initialPosition;  // ī�޶��� �ʱ� ��ġ
    private float currentShakeDuration = 0f;  // ���� �����ִ� ��鸲 �ð�

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
    }

    void OnEnable()
    {
        initialPosition = cameraTransform.localPosition;
    }

    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            // ī�޶��� ��ġ�� �������� ������
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            // ��鸲 �ð� ����
            currentShakeDuration -= Time.deltaTime;

            // ���� ����
            shakeMagnitude *= (1 - dampingSpeed * Time.deltaTime);
        }
        else
        {
            // ��鸲�� ������ ī�޶� ��ġ�� ������� ����
            currentShakeDuration = 0f;
            cameraTransform.localPosition = initialPosition;
            shakeMagnitude = 0.2f; // ��鸲�� ���� �Ŀ��� shakeMagnitude�� �ʱ�ȭ
        }
    }
}
