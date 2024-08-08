using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAni : MonoBehaviour
{
    public Transform childTransform;  // �ڽ� ������Ʈ�� Transform
    public float targetScaleY = 3.0f; // ��ǥ y�� ������
    public float duration = 1.0f;     // �ִϸ��̼� ���� �ð�
    private Vector3 initialPosition;
    private Vector3 initialScale;     // �ʱ� ������
    private float timeElapsed;
   // public Animator animator;
   
    void Start()
    {
       // animator.SetTrigger("lase");
        initialScale = childTransform.localScale;
        // �ڽ� ������Ʈ�� y�� �ݴ��� ���� �θ��� �߽ɿ� ���߱� ���� ��ġ�� �����մϴ�.
        childTransform.localPosition = new Vector3(0, -initialScale.y / 2, 0);
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            // ��ǥ �����ϱ��� ���� ����
            float newScaleY = Mathf.Lerp(initialScale.y, targetScaleY, timeElapsed / duration);
            // ������ ����
            childTransform.localScale = new Vector3(initialScale.x, newScaleY, initialScale.z);
            // �ڽ� ������Ʈ�� ��ġ�� �����Ͽ� ���� ���� �θ��� �߽ɿ� ���������� �մϴ�.
            childTransform.localPosition = new Vector3(0, (newScaleY / 2), 0);
            timeElapsed += Time.deltaTime;
        }
    }


}
