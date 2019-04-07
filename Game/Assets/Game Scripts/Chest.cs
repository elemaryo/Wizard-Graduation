using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private int open = -1;
    private Transform player;
    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Vector3.Distance(transform.position, player.position) < 1.5)
                {
                    open = open*-1;
                    if (open > 0){
                        OpenChest();
                    }
                    else if (open < 0){
                        CloseChest();
                    }
                }
                else
                {
                    open = -1;
                    CloseChest();
                }
            }
            else if (Vector3.Distance(transform.position, player.position) > 1.5)
            {
                open = -1;
                CloseChest();
            }
        }
    }

    private void OpenChest(){
        anim.SetTrigger("open");
    }

    private void CloseChest(){
        anim.ResetTrigger("open");
    }
}
