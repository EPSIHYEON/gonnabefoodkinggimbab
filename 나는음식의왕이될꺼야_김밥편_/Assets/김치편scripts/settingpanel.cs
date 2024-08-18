using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingpanel : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf)
        {
            // 이 오브젝트가 활성화되면 게임 일시 정지
            Time.timeScale = 0f;
        }
        else
        {
            // 이 오브젝트가 비활성화되면 게임 재개
            Time.timeScale = 1f;
        }
    }
}
