using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card Skill", menuName = "Card Skill")]
public class SO_Active_Skill : ScriptableObject
{

    public bool ACTIVE;
    public string InforSkill;
    public int CostSummon;
    public int PriceBuy;
    public Sprite Avatar;
    public GameObject G_Skill;

    
}
