using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAni : MonoBehaviour
{
    public Transform childTransform;  // 자식 오브젝트의 Transform
    public float targetScaleY = 3.0f; // 목표 y축 스케일
    public float duration = 1.0f;     // 애니메이션 지속 시간
    private Vector3 initialPosition;
    private Vector3 initialScale;     // 초기 스케일
    private float timeElapsed;
   // public Animator animator;
   
    void Start()
    {
       // animator.SetTrigger("lase");
        initialScale = childTransform.localScale;
        // 자식 오브젝트의 y축 반대쪽 끝을 부모의 중심에 맞추기 위해 위치를 조정합니다.
        childTransform.localPosition = new Vector3(0, -initialScale.y / 2, 0);
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            // 목표 스케일까지 선형 보간
            float newScaleY = Mathf.Lerp(initialScale.y, targetScaleY, timeElapsed / duration);
            // 스케일 변경
            childTransform.localScale = new Vector3(initialScale.x, newScaleY, initialScale.z);
            // 자식 오브젝트의 위치를 조정하여 한쪽 끝이 부모의 중심에 맞춰지도록 합니다.
            childTransform.localPosition = new Vector3(0, (newScaleY / 2), 0);
            timeElapsed += Time.deltaTime;
        }
    }


}
