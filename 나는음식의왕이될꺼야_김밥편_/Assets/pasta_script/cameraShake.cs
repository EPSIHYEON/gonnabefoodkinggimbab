using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Transform cameraTransform;  // 카메라의 Transform을 참조
    public float shakeDuration = 8f; // 흔들림 지속 시간 (8초로 설정)
    public float shakeMagnitude = 0.2f; // 흔들림 세기
    public float dampingSpeed = 0.1f;  // 감쇠 속도 (낮은 값으로 설정)

    private Vector3 initialPosition;  // 카메라의 초기 위치
    private float currentShakeDuration = 0f;  // 현재 남아있는 흔들림 시간

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
            // 카메라의 위치를 랜덤으로 움직임
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            // 흔들림 시간 감소
            currentShakeDuration -= Time.deltaTime;

            // 감쇠 적용
            shakeMagnitude *= (1 - dampingSpeed * Time.deltaTime);
        }
        else
        {
            // 흔들림이 끝나면 카메라 위치를 원래대로 복구
            currentShakeDuration = 0f;
            cameraTransform.localPosition = initialPosition;
            shakeMagnitude = 0.2f; // 흔들림이 끝난 후에도 shakeMagnitude를 초기화
        }
    }
}
