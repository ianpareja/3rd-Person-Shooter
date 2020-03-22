using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int startingHealth = 10;

    [SerializeField]
    private AudioSource deathSound;

    private int currentHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void OnEnable()
    {
        currentHealth = startingHealth;
        
        if(currentHealth > numOfHearts){
            currentHealth = numOfHearts;
        }
    }


    public void TakeDamage(int damageAmount)
    {

        HeartCount();
        currentHealth  -= damageAmount;


        if (currentHealth <= 0)
            Die();
    }


    private void HeartCount()
    {
        for (int i = 0; i < hearts.Length; i++) 
            {
            if(i < currentHealth - 1){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    private void Die()
    {
        deathSound.Play();
        gameObject.SetActive(false);
    }

}
