using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerCharacterMelee : ControllerChacracrer
{

    [SerializeField] protected SO_CharacterInforMantion SO_Information;
    [SerializeField] protected int damge = 10;

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
                Debug.Log("move");
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
        Health healthEnemy = L_Collider[0].GetComponent<Health>();
        healthEnemy.TakeDamage(damge);
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
