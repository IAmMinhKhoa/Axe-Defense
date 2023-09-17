using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacterRanged : ControllerChacracrer
{
    public SO_Skil So_Skill;
    [SerializeField] protected Transform PositionSpawnSkill;
    void Update()
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

    protected override void SetUpAttack()
    {
        

        GameObject BallSkill = Instantiate(So_Skill.PrefabSkill, PositionSpawnSkill.position,Quaternion.identity);
        Skill Skill = BallSkill.GetComponent<Skill>();
        Skill.SetTargetForSkill(L_Collider[0].gameObject.transform);
        Skill.SetDamgeSKill(So_Skill.Damge);
    }
}
