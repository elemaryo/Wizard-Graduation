using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text text;
    private GameObject score;
    private int highScore;
    private int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        text = text.GetComponent<Text>();
        score = GameObject.FindGameObjectWithTag("Score");
        finalScore = score.GetComponent<Score>().GetScore();
        Destroy(score);
        text.text = "Your Score: " + finalScore;
        if ((finalScore < highScore) || (highScore == 0))
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
        }
    }
}
