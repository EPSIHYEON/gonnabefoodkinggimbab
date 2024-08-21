using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour
{
    public static PauseMenu2 Instance;
    public GameObject pauseMenuPanel;
    public GameObject SettingsPanel;
    public GameObject music1;
    public AudioSource[] music2;
    private bool isPanelActive;

  


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
