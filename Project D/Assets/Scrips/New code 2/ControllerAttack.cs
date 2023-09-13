using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ControllerAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    private float attackTimer;
    private bool canAttack = true;
   
    [Header("IF NULL IS MELEE OR CHARACTER HAS SKILL IS MAGE")]

    public GameObject PrefabSkill;
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
            if (PrefabSkill==null)//melee
            {
                ControllerChacracrer EnemyController = enemyCollider.GetComponent<ControllerChacracrer>();
                EnemyController.EventBeingAttack();
            }else if(PrefabSkill!=null)//not melee
            {
                GameObject BallSkill= Instantiate(PrefabSkill,this.transform);
              
                BallSkill.GetComponent<Skill>().target = enemyCollider.gameObject.transform;
            }
     
            canAttack = false;
        }
    }

   
}
