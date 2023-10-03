using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacterRanged : ControllerChacracrer
{
    [SerializeField] protected SO_CharacterInforMantionRANGER SO_Information;


    [SerializeField] protected GameObject WeaponParent;
    protected List<GameObject> L_ChildWeapon =new List<GameObject>();

    private void Start()
    {
        Init();

        E_CharacterDie += ControllerCharacterRanged_E_CharacterDie;
        E_CharacterStateStart += ControllerCharacterRanged_E_CharacterStateStart;
    }

    private void ControllerCharacterRanged_E_CharacterStateStart(object sender, System.EventArgs e)
    {
        //After TimeWaitingStart -> Appear Weapon
        if (L_ChildWeapon != null)
        {
            foreach (GameObject child in L_ChildWeapon)
            {
                SetActiveObject(child, true);
            }
        }
    }

    private void ControllerCharacterRanged_E_CharacterDie(object sender, System.EventArgs e)
    {

        //After DIE -> Disappear Weapon
        if (L_ChildWeapon != null)
        {
            foreach (GameObject child in L_ChildWeapon)
            {
                SetActiveObject(child,false);
            }
        }
        
    }

    void Update()
    {
        WaitingToStartCharacter();

        if (stateCharacter == StateCharacter.Start)
        {
            isMoving = !CT_Collision.IsTouchingLayer();
            if (isMoving && CT_Health.GetIsAttacking() != true)//if not touch object && is not being attack
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
        GameObject BallSkill = Instantiate(SO_Information.PrefabSkill, WeaponParent.transform.position,Quaternion.identity);
        Skill Skill = BallSkill.GetComponent<Skill>();

        Skill.SetTargetForSkill(L_Collider[0].gameObject.transform);//Get first object in list object "enemy layer"
        Skill.SetDamgeSKill(SO_Information.Damge);
    }

    protected override void Init() 
    {
        base.Init();
        //Load data(HP,Ranger ATK, Speed, CD) from SO to Player
        CT_Health.SetHealth(SO_Information.HP);
        CT_Collision.SetRanger(SO_Information.RangedAttack);
        CT_Moving.SetSpeed(SO_Information.SpeedMove);
        attackCooldown = SO_Information.CoolDown;

        //Load get IMG weapon to list  -> turn on, off
        LoadListWeapon();
    }

    protected void SetActiveObject(GameObject obj,bool active)
    {
        if(obj != null)
            obj.SetActive(active);
    }
 
    protected void LoadListWeapon()
    {
        foreach (Transform child in WeaponParent.transform)
        {
            child.gameObject.SetActive(false);  
            L_ChildWeapon.Add(child.gameObject);
        }
    }

}
