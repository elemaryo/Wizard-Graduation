using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    private Animator anim;
    private int open = -1;
    private Transform player;
    private Transform chest;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chest = GameObject.FindGameObjectWithTag("Chest").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(chest.position, player.position) < 1.5)
            {
                open = open*-1;
                if (open > 0){
                    OpenChestUI();
                }
                else if (open < 0){
                    CloseChestUI();
                }
            }
            else
            {
                open = -1;
                CloseChestUI();
            }
        }
        else if (Vector3.Distance(chest.position, player.position) > 1.5)
        {
            open = -1;
            CloseChestUI();
        }  
    }

    private void OpenChestUI(){
        anim.SetBool("chest", true);
    }

    private void CloseChestUI(){
        anim.SetBool("chest", false);
    }
}
