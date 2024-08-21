using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public GameObject pauseMenuPanel;
    public GameObject SettingsPanel;
    public GameObject music1;
    public AudioSource[] music2;
    private bool isPanelActive;

    private void Awake()
    {
        // 싱글턴 패턴을 사용하여 인스턴스를 유지
        if (Instance ==  null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);  // 이미 존재하는 인스턴스가 있으면 현재 객체를 파괴
        }
    }



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        // 패널 활성화-비활성화
        isPanelActive = !isPanelActive;
        pauseMenuPanel.SetActive(isPanelActive);

        // 게임 일시 정지
        Time.timeScale = isPanelActive ? 0f : 1f;
    }
    public void OnSettingsButtonClicked()
    {
        Time.timeScale = 0f;
        Debug.Log("Settings Button Clicked");

        // PauseMenu를 비활성화하고 SettingsPanel을 활성화
        pauseMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);

        // 게임 일시 정지
       
    }

    public void OnConfirmSettingsButtonClicked()
    {
        Debug.Log("Confirm Settings Button Clicked");

        // SettingsPanel을 비활성화
        SettingsPanel.SetActive(false);

        // 게임을 재개
        Time.timeScale = 1f;
    }

    public void OnMainMenuButtonCliked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("시작화면");
        pauseMenuPanel.SetActive(false);
    }

    public void OnQuitButtonCliked()
    {
       Application.Quit();
       pauseMenuPanel.SetActive(false);
    }
}
