using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerChacracrer : MonoBehaviour
{
    protected ControllerCollision CT_Collision;
    protected ControllerMoving CT_Moving;
    protected ControllerAttack CT_Attack;
    protected Healt CT_Health;
    public Animator animatorChar;

    protected bool isMoving;




    protected event EventHandler BeingAttack;
    private void Start()
    {
        CT_Moving= GetComponent<ControllerMoving>();    
        CT_Collision=GetComponent<ControllerCollision>();
        CT_Attack = GetComponent<ControllerAttack>();
        CT_Health = GetComponent<Healt>();
        BeingAttack += ControllerChacracrer_BeingAttack;
    }

    private void ControllerChacracrer_BeingAttack(object sender, EventArgs e)
    {
        CT_Health.TakeDamage(20);
    }

    private void Update()
    {
        isMoving = !CT_Collision.IsTouchingLayer();
        if (isMoving && CT_Health.isAttacking !=true)//if not touch object && is being attack
        {
            bool isMovingRight = gameObject.CompareTag("Player");
            CT_Moving.Move(isMovingRight,animatorChar);

        }
        else if(isMoving!=true)
        {
            Collider2D[] L_Collider=CT_Collision.Return_L_CollderTouching();
            CT_Attack.Attack(L_Collider[0], animatorChar);
            
        }
        
    }


    public void EventBeingAttack()
    {
        BeingAttack?.Invoke(this, EventArgs.Empty);
    }
}
