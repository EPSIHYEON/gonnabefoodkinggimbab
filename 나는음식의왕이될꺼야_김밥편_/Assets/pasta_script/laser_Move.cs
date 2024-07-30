using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laser_Move : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� ����
    public Vector3 fixedEndPosition; // �������� ������ ���� ��ġ
    public float laserWidth = 1f; // �������� �β�
    public LineRenderer lineRenderer; // �������� LineRenderer ������Ʈ
    public Color lineColor = new Color(1f, 1f, 1f, 0.5f); // ���, ������ 0.5




    void Start()
    {
        // LineRenderer ������Ʈ�� �������ų� �߰��մϴ�.
        lineRenderer = GetComponent<LineRenderer>();
       

        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer�� Beam�� �߰����� �ʾҽ��ϴ�.");
            return;
        }
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // LineRenderer�� �Ӽ��� �����մϴ�.
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.positionCount = 2; // �� ������ ���� �׸��ϴ�.
    }

    void Update()
    {
        if (lineRenderer != null)
        {
            // Beam�� �������� ������ ������Ʈ�մϴ�.
            lineRenderer.SetPosition(0, fixedEndPosition);
            lineRenderer.SetPosition(1, player.position);
        }
    }

}
