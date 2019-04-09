using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private bool attack;

    public GameObject projectile;
    public SpellBook book;
    //[SerializeField]
    private GameObject[] spells;

    private Animator anim;


    void Start()
    {
        spells = new GameObject[6];
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = book.GetComponent<SpellBook>().GetSpell(i);
        }
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = book.GetComponent<SpellBook>().GetSpell(i);
        }
        //Arrow Key Movement
        var objpos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += objpos * speed * Time.deltaTime;

        //Face Hat towards Mouse (pointy side away from mouse)
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;

        //Mouse follow
        FaceMouse();

        //Cast spells method
        CastSpell();

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - objectPos.x;
        mousePosition.y = mousePosition.y - objectPos.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        angle -= 90; //correction for angle, sprite was sideways
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x = transform.position.x, mousePosition.y = transform.position.y);
        transform.up = -direction;
    }

    public void DoAttack()
    {
        if (attack)
        {
            anim.SetTrigger("attack");
        }
    }

    public void DoIdle()
    {
        if (!attack)
        {
            anim.ResetTrigger("attack");
        }
    }

    public void ClickSpell(int spellIndex)
    {
        if (spellIndex == 0)
        {
            Instantiate(spells[0], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 1)
        {
            Instantiate(spells[1], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 2)
        {
            Instantiate(spells[2], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 3)
        {
            Instantiate(spells[3], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 4)
        {
            Instantiate(spells[4], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 5)
        {
            Instantiate(spells[5], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
    }

    private void CastSpell()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(spells[0], transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(spells[1], transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spells[2], transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(spells[3], transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(spells[4], transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(spells[5], transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        else
        {
            attack = false;
            DoIdle();
        }

    }

    public void IncreaseSpeed(int s)
    {
        speed+=s;
    }
}
