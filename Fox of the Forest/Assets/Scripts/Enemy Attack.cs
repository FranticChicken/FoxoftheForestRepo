using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    float lastAttackTime;
    float attackCoolDown = 2f;
    public PlayerHealth playerHealthScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time - lastAttackTime < attackCoolDown) return;

        if (collision.CompareTag("Player"))
        {
            playerHealthScript.playerHealth -= 1;
            lastAttackTime = Time.time;


        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
