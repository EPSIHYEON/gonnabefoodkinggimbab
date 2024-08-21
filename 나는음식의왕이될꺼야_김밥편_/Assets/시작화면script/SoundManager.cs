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
        
            backmusic.volume = volume;  // �����̴� ���� ���� ����� ���� ����
        

    }


    public void SetButtonVolume(float volume) {
        btnSource.volume = volume;
    }

    public void OnStx() {
        btnSource.Play();
    }
}

