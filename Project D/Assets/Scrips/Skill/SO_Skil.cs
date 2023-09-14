using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Game/Skill")]
public class SO_Skil : ScriptableObject
{
    public enum TypeWeapon
    {
        Melee,
        Mage
    }

    public TypeWeapon Type;
    public GameObject PrefabSkill; //cho phep null
    public string NameSkill;
    public int MaxSpeed;
    public int Damge;

}
