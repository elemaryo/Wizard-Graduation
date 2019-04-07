using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTreasure : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private Vector3 alertPos;
    public Dialogue dialogue;
    public CamShake cameraShake;
    public GameObject alert;
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        alertPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        alertPos.y = alertPos.y + 0.75f;
        StartCoroutine(Initiate());
    }

    IEnumerator Initiate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("fake", true);
            yield return new WaitForSeconds(0.1f);
            GameObject t = Instantiate(alert, alertPos, Quaternion.identity);
            yield return new WaitForSeconds(0.7f);
            Destroy(t);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(cameraShake.Shake(1f, 0.4f));
            yield return new WaitForSeconds(1.3f);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Destroy(gameObject);
        }
    }
}
