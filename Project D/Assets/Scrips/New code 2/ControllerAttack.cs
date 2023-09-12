using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    private float attackTimer;
    private bool canAttack = true;

    private void Start()
    {
        attackTimer = attackCooldown;
    }

    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                canAttack = true;
                attackTimer = attackCooldown;
            }
        }
    }

    public void Attack(Collider2D enemyCollider,Animator animator)
    {
        if (canAttack)
        {
            animator.SetBool("Run",false);
            animator.SetTrigger("Attack");
                Healt enemyHealth = enemyCollider.GetComponent<Healt>();
                if (enemyHealth != null)
                {
                Debug.Log("atk");
                enemyHealth.TakeDamage(20);
                }
            canAttack = false;
        }
    }

   
}
