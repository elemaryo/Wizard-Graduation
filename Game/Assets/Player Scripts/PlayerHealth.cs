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

    Player player;
    //bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currentHealth = startingHealth;
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

    private void Death()
    {
        //restart game?
        //Add death cutscene here
        SceneManager.LoadScene("Home");
        Destroy(gameObject);

        //playerMovement.enabled = false;

    }


}
