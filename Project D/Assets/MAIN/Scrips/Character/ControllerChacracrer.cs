using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.CullingGroup;

public class ControllerChacracrer : MonoBehaviour
{
    #region MainController
    protected ControllerCollision CT_Collision;
    protected ControllerMoving CT_Moving;
    protected Health CT_Health;
    protected ControllerShader CT_Shader;
    #endregion

    #region List
    protected Collider2D[] L_Collider; //list collider object with later
    #endregion

    #region Component
    public Animator animatorChar;
    #endregion

    #region Event
    public event EventHandler E_CharacterDie;
    public event EventHandler E_CharacterStateStart;
    public event EventHandler E_CharacterHit;
    #endregion

    #region Variable
    [SerializeField] protected float attackCooldown = 2f;
    protected bool isMoving; //(update) => ( Alway check have any object front this object)
    protected bool isFreeze=false;
    protected bool canAttack = true;
    [SerializeField] protected float WaitingToStart = 4.5f;
    protected float _TimeToStart;
    #endregion

    #region Enum Type SomeThing
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
    #endregion



    protected void Attack()
    {
        if (!canAttack)
            return;
        StartCoroutine(WaitCoroutine());
        animatorChar.SetTrigger("Attack");
        animatorChar.SetBool("Run", false);

        //Each type of character will have a different attack method
        SetUpAttack();
    }


    protected  virtual void SetUpAttack(){}

    IEnumerator WaitCoroutine()//Waiting Cooldown
    {
        canAttack = false;
        yield return null;
        animatorChar.ResetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    protected virtual  void Init() {    //Run when start object
        CT_Moving = GetComponent<ControllerMoving>();
        CT_Collision = GetComponent<ControllerCollision>();
        CT_Health = GetComponent<Health>();
        CT_Shader = GetComponent<ControllerShader>();

        E_CharacterHit += ControllerChacracrer_E_CharacterHit;
        E_CharacterDie += ControllerChacracrer_E_CharacterDie;

        _TimeToStart = WaitingToStart;
    }

    private void ControllerChacracrer_E_CharacterDie(object sender, EventArgs e)
    {
        canAttack = false;
        animatorChar.SetTrigger("Die");

    }

    private void ControllerChacracrer_E_CharacterHit(object sender, EventArgs e)
    {
        animatorChar.SetTrigger("Hit");
    }

    protected void WaitingToStartCharacter() { //State machine for state game
        switch (stateCharacter)
        {
            case StateCharacter.Waiting:
                _TimeToStart -= Time.deltaTime;
                CT_Shader.SetShader("_valueDis",_TimeToStart, WaitingToStart);
                if (_TimeToStart < 0f)
                {
                    stateCharacter = StateCharacter.Start;
                    E_CharacterStateStart?.Invoke(this, EventArgs.Empty);                                                                                                       
                }
                break;
        }
    }

    public void OnCharacterDie()    //Catch event when character DIE
    {
        E_CharacterDie?.Invoke(this, EventArgs.Empty);
    }
    public void OnCharacterHIT()    //Catch event when character by HIT
    {
        E_CharacterHit?.Invoke(this, EventArgs.Empty);
    }
    public void SetFreeze(bool temp)
    {
        isFreeze = temp;
    }
}
