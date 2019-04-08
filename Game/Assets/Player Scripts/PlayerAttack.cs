using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float speed = 6.0f;
    private Transform enemy;
    private Transform collision;
    private Vector2 target;
    public Vector2 enPos;
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        enPos = new Vector2(enemy.position.x, enemy.position.y);
        //target = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        pos = transform.position;

        if ((pos.x == enPos.x) && (pos.y == enPos.y))
        {
            DestroyProjectile();
        }
        collision = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (Vector3.Distance(transform.position, collision.position) < 1.5)
        {
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}