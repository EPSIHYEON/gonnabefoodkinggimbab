using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingpanel : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf)
        {
            // �� ������Ʈ�� Ȱ��ȭ�Ǹ� ���� �Ͻ� ����
            Time.timeScale = 0f;
        }
        else
        {
            // �� ������Ʈ�� ��Ȱ��ȭ�Ǹ� ���� �簳
            Time.timeScale = 1f;
        }
    }
}
