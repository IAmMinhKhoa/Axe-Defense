using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerCharacterMelee : ControllerChacracrer
{
    public int damge = 10;

    private void Start()
    {
        base.Init();
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
        Healt healthEnemy = L_Collider[0].GetComponent<Healt>();
        healthEnemy.TakeDamage(damge,typeCharacter);
    }
}
