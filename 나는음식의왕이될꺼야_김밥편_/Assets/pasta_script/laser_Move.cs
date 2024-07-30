using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laser_Move : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 참조
    public Vector3 fixedEndPosition; // 레이저의 고정된 끝의 위치
    public float laserWidth = 1f; // 레이저의 두께
    public LineRenderer lineRenderer; // 레이저의 LineRenderer 컴포넌트
    public Color lineColor = new Color(1f, 1f, 1f, 0.5f); // 흰색, 불투명도 0.5




    void Start()
    {
        // LineRenderer 컴포넌트를 가져오거나 추가합니다.
        lineRenderer = GetComponent<LineRenderer>();
       

        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer가 Beam에 추가되지 않았습니다.");
            return;
        }
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // LineRenderer의 속성을 설정합니다.
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.positionCount = 2; // 두 점으로 선을 그립니다.
    }

    void Update()
    {
        if (lineRenderer != null)
        {
            // Beam의 시작점과 끝점을 업데이트합니다.
            lineRenderer.SetPosition(0, fixedEndPosition);
            lineRenderer.SetPosition(1, player.position);
        }
    }

}
