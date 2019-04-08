using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    Player player;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage (int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    private void Death()
    {
        //restart game?
        isDead = true;

        //playerMovement.enabled = false;

    }


}
