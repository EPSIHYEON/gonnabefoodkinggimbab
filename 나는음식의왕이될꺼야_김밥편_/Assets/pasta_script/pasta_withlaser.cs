using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pasta_withlaser : MonoBehaviour
{
    public Slider healthSlider;
    public AudioSource laserSound;

    // Start is called before the first frame update


    void Start()
    {
        // ó�� healthSlider�� value�� 0.2�� ����
        healthSlider.value = 0.2f;

        Invoke("StartLate", 0.5f);


        
    }

    void StartLate()
    {
        StartCoroutine(HealthBarDown1());
    }


    IEnumerator HealthBarDown()
    {
        while (healthSlider.value > 0)  // healthSlider�� 0�� �� ������ �ݺ�
        {
            laserSound.Play();
            healthSlider.value -= 0.02f;  // healthSlider ���� ���ҽ�Ŵ

            if (healthSlider.value < 0)
            {
                healthSlider.value = 0;  // healthSlider�� 0 ���Ϸ� �������� ���� ����
            }

            yield return new WaitForSeconds(1f);  // 0.05�� ���
        }
    }


    IEnumerator HealthBarDown1()
    {
        while (healthSlider.value > 0)
        {
            float targetValue = healthSlider.value - 0.025f;  // ��ǥ ���� ����
            if (targetValue < 0) targetValue = 0;  // ��ǥ ���� 0 ���Ϸ� �������� �ʵ��� ����

            float duration = 0.5f;  // ���ҿ� �ɸ� �ð� (��)
            float elapsed = 0f;  // ��� �ð� �ʱ�ȭ

            float startValue = healthSlider.value;  // ���� �� ����

            laserSound.Play();

            // �����̴� ���� ���������� ���ҽ�Ŵ
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;  // ��� �ð� ������Ʈ
                healthSlider.value = Mathf.Lerp(startValue, targetValue, elapsed / duration);  // �� ������ ����
                yield return null;  // �������� ��ٸ�
            }

            healthSlider.value = targetValue;  // ���������� ��Ȯ�� ��ǥ ���� ����

           
            yield return new WaitForSeconds(0.05f);
        }

        // �ڷ�ƾ ���� (�����̴� ���� 0�� �Ǹ� ����)
        yield break;
    }
}
    
