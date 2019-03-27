using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void PlayGame(){
        Application.LoadLevel(1);
    }

    public void Exit(){
        Application.Quit();
    }
}
