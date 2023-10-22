using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Melee")]
public class SO_CharacterInforMantion : ScriptableObject
{

    public bool ACTIVE;
    public  enum TypeChar{
        Melee,
        Mage,
        Archer
    }
    [Header("VARIABLE DEFAULT")]
    [Space(20)]
    public  TypeChar typeCharacter;
    public string nameChar;
    public Sprite Avatar;
    public int HP;
    public int Damge; 
    public int CostSummon;
    public GameObject Prefab_Character;

    [Space(20)]
    public float RangedAttack;
    public float SpeedMove;
    public int CoolDown;

    [Space(20)]
    public int PriceBuy;
}
