using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class hpbar_JY : MonoBehaviour
{
    public int maxHealth = 350;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject blackout;
    public GameObject player;
    public GameObject JBoss;
    public GameObject Jbullet;
    public AudioSource laser;
    public AudioSource BackgroundMusic;
    
   
    private Animator hpbarAnimator;

    void Start()
    {
        hpbarAnimator = GameObject.Find("hpbar").GetComponent<Animator>();
        currentHealth = maxHealth;
        UpdateHealthUI();
        BackgroundMusic.Play();
    }
    void Update()
    {
       
    }

    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        laser.Play();
        currentHealth -= damageAmount;
        UpdateHealthUI();
        hpbarAnimator.SetTrigger("new_hp");

        if (healthSlider.value == 0) {
            BossDie();
        }

    }

    void BossDie()
    {
        // 배경화면 페이드아웃 되면서 중지
        StartCoroutine(FadeOutMusic(1f));

        player.SetActive(false);
        JBoss.SetActive(false);
       
        blackout.SetActive(true);
        Invoke("SetScene", 3f);

    }

    IEnumerator FadeOutMusic(float fadeDuration)
    {
        float StartVolume = BackgroundMusic.volume;

        while (BackgroundMusic.volume > 0)
        {
            BackgroundMusic.volume -= StartVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
        
        BackgroundMusic.Stop();
        BackgroundMusic.volume = StartVolume;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.tag == "playerbullet")
        {
            Debug.Log("Collided with playerbullet");

            Destroy(collision.gameObject);
            TakeDamage(100 / 35);


        }

        
    }

    void SetScene()
    {
        SceneManager.LoadScene("JY3");
    }
}
