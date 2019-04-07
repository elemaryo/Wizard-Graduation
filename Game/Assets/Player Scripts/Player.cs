using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.0f;
    private bool attack;

    public GameObject projectile;

    [SerializeField]
    public GameObject[] spellPrefab;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
            Instantiate(spellPrefab[0], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 1)
        {
            Instantiate(spellPrefab[1], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 2)
        {
            Instantiate(spellPrefab[2], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 3)
        {
            Instantiate(spellPrefab[3], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 4)
        {
            Instantiate(spellPrefab[4], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
        else if (spellIndex == 5)
        {
            Instantiate(spellPrefab[5], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }
    }

    private void CastSpell()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(spellPrefab[0], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(spellPrefab[1], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spellPrefab[2], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(spellPrefab[3], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(spellPrefab[4], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(spellPrefab[5], transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attack = true;
            DoAttack();
        }

        else
        {
            attack = false;
            DoIdle();
        }

    }
}
