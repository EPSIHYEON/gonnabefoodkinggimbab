using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSoundMan : MonoBehaviour
{
    

        public AudioSource backmusic;
        public AudioSource backmusic_2;
        public AudioSource backmusic_3;
    public AudioSource backmusic_4;
    public AudioSource btnSource;
        public AudioSource EffectSound;
        public AudioSource scriptSound;



    public void SetVolume(float volume)
        {

            backmusic.volume = volume;
        backmusic_2.volume = volume;
        backmusic_3.volume = volume;
        backmusic_4.volume = volume;// 슬라이더 값에 따라 오디오 볼륨 설정


    }


        public void SetButtonVolume(float volume)
        {
            btnSource.volume = volume;
            EffectSound.volume = volume;
            scriptSound.volume = volume;
        }

        public void OnStx()
        {
            btnSource.Play();
        }
    
}
