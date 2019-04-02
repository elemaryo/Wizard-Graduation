using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float timer;
    public float startTimer;

    public GameObject projectile;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (timer <= 0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timer = startTimer;
        }
        else{
            timer = Time.deltaTime;
        }
    }
}
