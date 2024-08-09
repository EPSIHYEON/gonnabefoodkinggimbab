using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAni_2 : MonoBehaviour
{
    public float expandSpeed;  // 레이저가 확장되는 속도
    public float maxLength; // 레이저의 최대 길이
    private Vector3 initialScale;   // 레이저의 초기 크기
    private Vector3 initialPosition; // 레이저의 초기 위치

    void Start()
    {
        // 초기 크기와 위치를 저장
        initialScale = transform.localScale;
        initialPosition = transform.position;
    }

    void Update()
    {
        // 레이저가 위쪽으로만 확장되도록 스케일 조정
        if (transform.localScale.y < maxLength)
        {
            float newScaleY = transform.localScale.y + expandSpeed * Time.deltaTime;
            if (newScaleY > maxLength)
            {
                newScaleY = maxLength;
            }
            transform.localScale = new Vector3(transform.localScale.x, newScaleY, transform.localScale.z);

            // 레이저의 하단 위치를 고정시키기 위해 Y축 위치를 조정
            
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        }
    }

}

