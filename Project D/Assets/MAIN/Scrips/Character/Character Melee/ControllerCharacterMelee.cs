using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerCharacterMelee : ControllerChacracrer
{

    [SerializeField] protected SO_CharacterInforMantion SO_Information;
    [SerializeField] protected float damage = 10;

    private void Start()
    {
        Init();
    }

    void Update()
    {
        WaitingToStartCharacter();

        if (stateCharacter == StateCharacter.Start)
        {
            isMoving = !CT_Collision.IsTouchingLayer();
            if (isMoving && CT_Health.GetIsAttacking() != true)//if not touch object && is being attack
            {
                bool RightDirection = (typeMove == TypeMove.goRight) ? true : false;
                CT_Moving.Move(RightDirection);
                animatorChar.SetBool("Run", true);
               
            }
            else if (isMoving != true)
            {
                L_Collider = CT_Collision.Return_L_CollderTouching();
                Attack();
            }
        }
    }

    protected override void SetUpAttack()
    {
        Health healthEnemy = null;
        string enemyTag = L_Collider[0].gameObject.tag;

        if (enemyTag == "CharacterMage")
        {
            healthEnemy = L_Collider[0].GetComponent<Health_Ranged>();
        }
        else if (enemyTag == "CharacterArcher")
        {
            healthEnemy = L_Collider[0].GetComponent<Health_Ranged>();
        }
        else if (enemyTag == "CharacterMelee")
        {
            healthEnemy = L_Collider[0].GetComponent<Health_Melee>();
        }
        else if (enemyTag == "Tower")
        {
            healthEnemy = L_Collider[0].GetComponent<Health_Tower>();
        }

        if (healthEnemy != null)
        {
            string myTag = this.gameObject.tag;
            
            float coefficient = DEFAULT_VALUE.GetAttackCoefficient(myTag, enemyTag);
            healthEnemy.TakeDamage(damage * coefficient);
            EffectManager.instance.SpawmVFX("Effect Hit Melee", L_Collider[0].transform.position, ObjectPoolManager.Pooltyle.ParticleSystem);
        }
    }

    protected override void Init()
    {
        base.Init();
        //Load data(HP,Ranger ATK, Speed, CD) from SO to Player
        CT_Health.SetHealth(SO_Information.HP);
        CT_Collision.SetRanger(SO_Information.RangedAttack);
        CT_Moving.SetSpeed(SO_Information.SpeedMove);
        attackCooldown = SO_Information.CoolDown;        
    }

    
}
