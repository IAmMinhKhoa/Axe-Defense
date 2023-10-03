using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Melee")]
public class SO_CharacterInforMantion : ScriptableObject
{
    protected string nameChar;
    protected Image Avatar;
    public int HP;
    public float RangedAttack;
    public int SpeedMove;
    public int Damge; //set truc tiep khi instance skill
    public int CoolDown;
}
