using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.CullingGroup;

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

    public event EventHandler E_CharacterDie;
    public event EventHandler E_CharacterStateStart;



    public float dissolveValue = 1f; // Giá tr? dissolve ban ??u

    public Material material;

    int _valueDis = Shader.PropertyToID("_valueDis");

    public enum TypeMove{
        goLeft,
        goRight
    }
    public TypeMove typeMove=TypeMove.goRight;

    public enum TypeCharacter
    {
        Melee,
        Mage
    }
    [SerializeField]
    public static TypeCharacter typeCharacter;


    public enum StateCharacter
    {
        Waiting,
        Start
    }
    public StateCharacter stateCharacter;

    protected float WaitingToStart = 4.5f;
        
  


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

    protected virtual  void Init() {
        CT_Moving = GetComponent<ControllerMoving>();
        CT_Collision = GetComponent<ControllerCollision>();
        CT_Health = GetComponent<Healt>();

      
        
     
        Debug.Log(material);
    }

    protected void WaitingToStartCharacter() {
        switch (stateCharacter)
        {
            case StateCharacter.Waiting:
                WaitingToStart -= Time.deltaTime;
                material.SetFloat("_valueDis",((WaitingToStart-1)/4.5f));
                if (WaitingToStart < 0f)
                {
                    stateCharacter = StateCharacter.Start;
                    E_CharacterStateStart?.Invoke(this, EventArgs.Empty);                                                                                                       
                }
                break;
           
        }
    }

    public void OnCharacterDie()
    {
        E_CharacterDie?.Invoke(this, EventArgs.Empty);
    }
}
