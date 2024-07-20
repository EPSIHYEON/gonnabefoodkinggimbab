using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
   
    public AudioSource backmusic;
    public AudioSource btnSource;

    
    public void SetVolume(float volume)
    {
        if (volume == 0)
        {
            backmusic.volume = 0f;  // ���Ұŵ� ���� ������ ����
        }
        else
        {
            backmusic.volume = volume;  // �����̴� ���� ���� ����� ���� ����
        }

    }


    public void SetButtonVolume(float volume) {
        btnSource.volume = volume;
    }

    public void OnStx() {
        btnSource.Play();
    }
}

