using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    private Transform player;
    private GameObject[] enemies;
    private GameObject wizard;
    private GameObject book;
    private GameObject healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wizard = GameObject.FindGameObjectWithTag("Player");
        book = GameObject.FindGameObjectWithTag("Spellbook");
        healthSlider = GameObject.FindGameObjectWithTag("HealthSlider");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            if (Vector3.Distance(transform.position, player.position) < 1.1)
            {
                DontDestroyOnLoad(book);
                DontDestroyOnLoad(wizard);
                DontDestroyOnLoad(healthSlider);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
