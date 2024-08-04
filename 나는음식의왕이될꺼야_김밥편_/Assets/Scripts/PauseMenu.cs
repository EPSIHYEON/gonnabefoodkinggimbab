using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    private static PauseMenu instance;

    void Awake()
    {
        // 싱글턴 패턴을 사용하여 인스턴스를 유지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 인스턴스가 있으면 현재 객체를 파괴
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        // 패널 활성화-비활성화
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);

        // 게임 일시 정지
        if (pauseMenuPanel.activeSelf)
        {
            Time.timeScale = 0f; // 게임 일시 정지
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
        }
    }

    public void OnSettingsButtonCliked()
    {
        Debug.Log("Settings Button Clicked");
       // 설정 메뉴로 이동하거나 설정을 여는 코드
    }

    public void OnMainMenuButtonCliked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("시작화면");
    }

    public void OnQuitButtonCliked()
    {
       Application.Quit();
    }
}
