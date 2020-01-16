using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : EnemyBehaviour
{


    void Start()
    {
        curHealth = health;
        target = GameObject.FindGameObjectWithTag("Player");
        enemyTrans = this.gameObject.transform;
    }

    void Update()
    {
        
    }
}
