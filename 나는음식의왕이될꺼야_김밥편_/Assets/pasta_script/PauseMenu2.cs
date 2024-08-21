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
        // �г� Ȱ��ȭ-��Ȱ��ȭ
        isPanelActive = !isPanelActive;
        pauseMenuPanel.SetActive(isPanelActive);

        // ���� �Ͻ� ����
        Time.timeScale = isPanelActive ? 0f : 1f;
    }
    public void OnSettingsButtonClicked()
    {
        Time.timeScale = 0f;
        Debug.Log("Settings Button Clicked");

        // PauseMenu�� ��Ȱ��ȭ�ϰ� SettingsPanel�� Ȱ��ȭ
        pauseMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);

        // ���� �Ͻ� ����

    }

    public void OnConfirmSettingsButtonClicked()
    {
        Debug.Log("Confirm Settings Button Clicked");

        // SettingsPanel�� ��Ȱ��ȭ
        SettingsPanel.SetActive(false);

        // ������ �簳
        Time.timeScale = 1f;
    }

    public void OnMainMenuButtonCliked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("����ȭ��");
        pauseMenuPanel.SetActive(false);
    }

    public void OnQuitButtonCliked()
    {
        Application.Quit();
        pauseMenuPanel.SetActive(false);
    }
}
