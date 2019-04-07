using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int hp;
    private GameObject[] attacks;
    private Transform attack;
    // Start is called before the first frame update
    void Start()
    {
        attacks = GameObject.FindGameObjectsWithTag("PlayerAttack");
    }

    // Update is called once per frame
    void Update()
    {
        attacks = GameObject.FindGameObjectsWithTag("PlayerAttack");
        for (int i = 0; i < attacks.Length; i++){
            attack = attacks[i].transform;
            if (Vector3.Distance(transform.position, attack.position) < 1.5)
            {
                hp--;
                if (hp == 0){
                    KillEnemy();
                }
            }   
        }
    }

    void KillEnemy(){
        Destroy(gameObject);
    }
}
