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
        
            backmusic.volume = volume;  // 슬라이더 값에 따라 오디오 볼륨 설정
        

    }


    public void SetButtonVolume(float volume) {
        btnSource.volume = volume;
    }

    public void OnStx() {
        btnSource.Play();
    }
}

