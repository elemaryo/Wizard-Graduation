using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        pos = transform.position;
        if((pos.x == target.x) && (pos.y == target.y)){
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D hit){
        if(hit.CompareTag("Player")){
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
