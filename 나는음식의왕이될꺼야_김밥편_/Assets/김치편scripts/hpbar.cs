using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class hpbar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject blackout;
    public GameObject player;
    public GameObject ±èÄ¡Boss;
    public GameObject kbullet;
    public AudioSource laser;
    
   
    private Animator hpbarAnimator;

    void Start()
    {
        hpbarAnimator = GameObject.Find("hpbar").GetComponent<Animator>();
        currentHealth = maxHealth;
        UpdateHealthUI();
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
        hpbarAnimator.SetTrigger("hpmove");

        if (healthSlider.value == 0) {
            BossDie();
        }

    }

    void BossDie()
    {
        
        player.SetActive(false);
        ±èÄ¡Boss.SetActive(false);
       
        blackout.SetActive(true);
        Invoke("SetScene", 3f);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.tag == "playerbullet")
        {
            Debug.Log("Collided with playerbullet");

            Destroy(collision.gameObject);
            TakeDamage(10);


        }

        
    }

    void SetScene()
    {
        SceneManager.LoadScene("±èÄ¡3");
    }
}
