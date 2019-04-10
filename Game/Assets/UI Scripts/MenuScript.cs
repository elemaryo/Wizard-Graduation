using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Text text;
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit(){
        Application.Quit();
    }

    public void DisplayHighScore(){
        text = text.GetComponent<Text>();
        text.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}
