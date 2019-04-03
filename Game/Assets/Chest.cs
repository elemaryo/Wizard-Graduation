using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private bool open;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, player.position) < 1.5)
            {
                open = true;
                OpenChest();
            }
            else
            {
                open = false;
                CloseChest();
            }
        }
        else
        {
            open = false;
            CloseChest();
        }
    }

    private void OpenChest(){
        if (open){
            anim.SetTrigger("open");
        }
    }

    private void CloseChest(){
        if (!open){
            anim.ResetTrigger("open");
        }
    }
}
