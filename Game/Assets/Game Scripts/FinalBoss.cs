using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public Animator anim;
    public CamShake cameraShake;
    public Dialogue dialogue;
    private bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enter()
    {
        StartCoroutine(Entrance());
    }

    IEnumerator Entrance()
    {
        if (state)
        {
            anim.SetBool("bossEnter", true);
            yield return new WaitForSeconds(1.1f);
            StartCoroutine(cameraShake.Shake(0.2f, 0.4f));
            yield return new WaitForSeconds(0.5f);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            state = false;
        }
    }

    public bool GetState()
    {
        return state;
    }
}
