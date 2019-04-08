using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int attackDamage = 10;

    private Transform player;
    private Transform collision;
    private Vector3 target;
    private Vector3 pos;
    PlayerHealth pHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pHealth = player.GetComponent<PlayerHealth>();
        target = new Vector3(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        pos = transform.position;
        if ((pos.x == target.x) && (pos.y == target.y))
        {
            DestroyProjectile();
            pHealth.takeDamage(attackDamage);
        }
        collision = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector3.Distance(transform.position, collision.position) < 1.5)
        {
            DestroyProjectile();
            pHealth.takeDamage(attackDamage);
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.GetComponent<Collider2D>().tag == "Player")
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}