using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Melee")]
public class SO_CharacterInforMantion : ScriptableObject
{
    
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
    public int Damge; //set truc tiep khi instance skill
    public int CostSummon;
    public GameObject Prefab_Character;

    public float RangedAttack;
    public int SpeedMove;
    public int CoolDown;
    

}
