using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobility : MonoBehaviour
{
    public int speed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().IncreaseSpeed(speed);
        Destroy(gameObject);
    }
}
