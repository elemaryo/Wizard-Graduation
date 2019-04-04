using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp--;
        if (hp == 0){
            KillEnemy();
        }   
    }

    void KillEnemy(){
        Destroy(gameObject);
    }
}
