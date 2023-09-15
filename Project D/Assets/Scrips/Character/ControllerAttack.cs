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

   // [Header("IF NULL IS MELEE OR CHARACTER HAS SKILL IS MAGE")]

    public SO_Skil So_Skill;
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
            Debug.Log("danh ne");
            animator.SetBool("Run",false);
            animator.SetTrigger("Attack");
            
            if (So_Skill.Type.ToString() =="Mage" )
            {
                GameObject BallSkill = Instantiate(So_Skill.PrefabSkill, this.transform);
                Skill Skill = BallSkill.GetComponent<Skill>();
                Skill.SetTargetForSkill(enemyCollider.gameObject.transform);
                Skill.SetDamgeSKill(So_Skill.Damge);
            }
            else if (So_Skill.Type.ToString() == "Melee")
            {
                Healt healthEnemy= enemyCollider.GetComponent<Healt>();
                healthEnemy.TakeDamage(So_Skill.Damge, "Effect Hit Melee");
            }

            canAttack = false;
        }
    }

   
}
