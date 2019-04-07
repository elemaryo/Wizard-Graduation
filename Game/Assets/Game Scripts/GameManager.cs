using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;

    //private int level = 0;
    
    void Awake()
    {
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetUpScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadRoom(int lev)
    {
        boardScript = GetComponent<BoardManager>();
        boardScript.SetUpScene(lev);
    }
}
