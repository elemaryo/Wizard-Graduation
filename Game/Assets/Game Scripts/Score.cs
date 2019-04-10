using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //score increments on every frame here 
        text.text = "Score: " + score++;
    }

    public int GetScore()
    {
        return score;
    }
}
