using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private AudioSource whenHit;

    public Slider slider;
    public float health;
    public AudioClip hitSound;
    

    private void Start()
    {
        whenHit = GetComponent<AudioSource>();
    }

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.minValue = Health;
    }

    public void setHealth (int health)
    {
        slider.value = health;
    }

     void Update()
    {
        slider.value = health;
      
    }

    private void onTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.CompareTag("Enemy"))
        {
            health = health - 10f;
            Debug.Log("HIT!");
            playHitSound();
        }

            if (health <= 0)
            {
                Die();
            }
        

    }

    void playHitSound()
    {
        whenHit.clip = hitSound;
        whenHit.Play();
    }

    void Die()
    {
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}