using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBattle : MonoBehaviour
{
    private int hp;
    private GameObject wizard;
    private GameObject book;
    private GameObject health;
    private GameObject score;
    public Slider BossSlider;
    // Start is called before the first frame update
    void Start()
    {
        wizard = GameObject.FindGameObjectWithTag("Player");
        book = GameObject.FindGameObjectWithTag("Spellbook");
        health = GameObject.FindGameObjectWithTag("Healthslider");
        score = GameObject.FindGameObjectWithTag("Score");
        hp = gameObject.GetComponent<EnemyInfo>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        hp = gameObject.GetComponent<EnemyInfo>().GetHealth();
        BossSlider.value = hp;
        if (hp == 1)
        {
            Destroy(book);
            Destroy(wizard);
            Destroy(health);
            Destroy(score);
            SceneManager.LoadScene(0);
        }
    }
}
