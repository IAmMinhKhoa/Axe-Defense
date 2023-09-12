using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerChacracrer : MonoBehaviour
{
    protected ControllerCollision CT_Collision;
    protected ControllerMoving CT_Moving;
    protected ControllerAttack CT_Attack;
    [SerializeField] protected Animator animatorChar;
    private void Start()
    {
        CT_Moving= GetComponent<ControllerMoving>();    
        CT_Collision=GetComponent<ControllerCollision>();
        CT_Attack = GetComponent<ControllerAttack>();
    }
    private void Update()
    {
        bool isMoving = !CT_Collision.IsTouchingLayer();
        if (isMoving)//if not touch object
        {
            bool isMovingRight = gameObject.CompareTag("Player");
            CT_Moving.Move(isMovingRight,animatorChar);
            Debug.Log("moving");

        }
        else
        {
            Collider2D[] L_Collider=CT_Collision.Return_L_CollderTouching();
            CT_Attack.Attack(L_Collider[0], animatorChar);
            
        }
    }
}
