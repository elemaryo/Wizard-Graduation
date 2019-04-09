using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    private GameObject health;
    private GameObject score;

    Player player;
    //bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currentHealth = startingHealth;
        score = GameObject.FindGameObjectWithTag("Score");
        health = GameObject.FindGameObjectWithTag("Healthslider");
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
    }

    public void takeDamage (int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        healthSlider.value = currentHealth;
    }

    private void Death()
    {
        //restart game?
        //Add death cutscene here
        SceneManager.LoadScene(9);
        Destroy(gameObject);
        Destroy(health);
        Destroy(score);

        //playerMovement.enabled = false;

    }


}
