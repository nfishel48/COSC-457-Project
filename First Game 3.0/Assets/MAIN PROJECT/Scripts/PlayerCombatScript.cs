using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    /*
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    */

    public Animator animator_attack;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private float timestamp;
    private float coolDownSeconds;


    void Start()
    {
        coolDownSeconds = 10;
        timestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();

        }else if (Input.GetKeyDown(KeyCode.E))
        {
            if (timestamp <= Time.time)
            {
                AttackHeavy();
                timestamp = Time.time + coolDownSeconds;
            }
            
        }
        else
        {

        }
    }



    void AttackHeavy()
    {
        animator_attack.SetTrigger("Attack2");

        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenemy)
        {
            Debug.Log("Hit on " + enemy.name);
            enemy.GetComponent<EnemyDamageTaker>().TakeDamage(50);
            //enemy.GetComponent<Enemy>.TakeDamage();
        }
    }


    void Attack()
    {
        animator_attack.SetTrigger("Attack1");

        Collider2D[] hitenemy =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenemy)
        {
            Debug.Log("Hit on " + enemy.name);
            enemy.GetComponent<EnemyDamageTaker>().TakeDamage(20);
            //enemy.GetComponent<Enemy>.TakeDamage();
        }
            
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) { return;  }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
