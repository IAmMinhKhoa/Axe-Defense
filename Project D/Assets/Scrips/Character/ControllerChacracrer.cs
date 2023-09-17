using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerChacracrer : MonoBehaviour
{
    protected ControllerCollision CT_Collision;
    protected ControllerMoving CT_Moving;
    protected Healt CT_Health;
    
    protected Collider2D[] L_Collider;
    
    protected float attackCooldown = 2f;
    protected bool isMoving;
    protected bool canAttack = true;

    public Animator animatorChar;
    public enum TypeMove{
        goLeft,
        goRight
    }
    public TypeMove typeMove=TypeMove.goRight;

    private void Start()
    {
        CT_Moving= GetComponent<ControllerMoving>();
        CT_Collision = GetComponent<ControllerCollision>();
        CT_Health = GetComponent<Healt>();
      
    }


    protected void Attack()
    {
        if (!canAttack)
            return;
        StartCoroutine(WaitCoroutine());
        animatorChar.SetTrigger("Attack");
        animatorChar.SetBool("Run", false);
        SetUpAttack();
    }


    protected  virtual void SetUpAttack(){}

    IEnumerator WaitCoroutine()
    {
        canAttack = false;
        yield return null;
        animatorChar.ResetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    


}
