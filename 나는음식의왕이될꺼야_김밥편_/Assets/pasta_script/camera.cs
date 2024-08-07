using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class camera : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // 목표 종횡비 (16:9)

    void Start()
    {
        SetCameraAspect();
    }

    void SetCameraAspect()
    {
        // 현재 화면의 종횡비 계산
        float windowAspect = (float)Screen.width / (float)Screen.height;
        // 목표 종횡비와 비교하여 비율 차이 계산
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        // 종횡비에 따라 뷰포트 조정
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

    }
}
