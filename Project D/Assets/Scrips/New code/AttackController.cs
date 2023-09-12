using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator animatorChar;
    public float attackCooldown = 2f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    private bool canAttack = true;
    private float attackTimer;

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

    public void Attack()
    {
        if (canAttack)
        {
            animatorChar.SetTrigger("Attack");
            animatorChar.SetBool("Run", false);

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemyCollider in hitEnemies)
            {
                Healt enemyHealth = enemyCollider.GetComponent<Healt>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(20);
                }
            }

            canAttack = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
