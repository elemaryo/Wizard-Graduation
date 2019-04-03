using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.0f;
    public Sprite wizIdle;
    public Sprite wizAttack;

    private SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        wizIdle = Resources.Load<Sprite>("Sprites/WizA");
        wizAttack = Resources.Load<Sprite>("Sprites/WizAtt2");
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
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        angle -= 90; //correction for angle, sprite was sideways
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetKeyDown(KeyCode.Space)) // mouse click Input.GetMouseButtonDown(0)
        {
            spriteRenderer.sprite = wizAttack; // attack
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spriteRenderer.sprite = wizIdle;
        }

    }
}
