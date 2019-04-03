using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.0f;
    public Sprite wizIdle;
    public Sprite wizAttack;
    private bool attack;
    private Transform chest;

    public GameObject projectile;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        chest = GameObject.FindGameObjectWithTag("Chest").transform;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        wizIdle = Resources.Load<Sprite>("Sprites/WizA");
        wizAttack = Resources.Load<Sprite>("Sprites/WizAtt2");
        anim = GetComponent<Animator>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = wizIdle; // set the sprite to sprite1
    }

    void Update()
    {
        //Arrow Key Movement
        var objpos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += objpos * speed * Time.deltaTime;

        //Face Hat towards Mouse (pointy side away from mouse)
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        float newX = mousePos.x - objectPos.x;
        float newY = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(newX, newY) * Mathf.Rad2Deg;
        angle -= 90; //correction for angle, sprite was sideways
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetKeyDown(KeyCode.Space)) // mouse click Input.GetMouseButtonDown(0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
            //spriteRenderer.sprite = wizAttack; // attack
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            attack = false;
            DoIdle();
            //spriteRenderer.sprite = wizIdle;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, chest.position) < 1.5)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
            }
        }

    }

    private void DoAttack(){
        if (attack){
            anim.SetTrigger("attack");
        }
    }

    private void DoIdle(){
        if(!attack){
            anim.ResetTrigger("attack");
        }
    }
}
