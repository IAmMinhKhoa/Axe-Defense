using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DEFAULT_VALUE
{
    public static float COEFICIENT_ATTACK_DEFAULT = 1f; //DEFAULT 
    public static float COEFICIENT_ATTACK_MAGE_MELEE=1.2f; //MAGE COUNTER MELEE
    public static float COEFICIENT_ATTACK_MELEE_ARCHER = 1.3f; //MELEE COUNTER ARCHER
    public static float COEFICIENT_ATTACK_ARCHER_MAGE = 1.4f; //ARCHER COUNTER MAGE

    private static Dictionary<string, float> attackCoefficients =new Dictionary<string, float>();


    static DEFAULT_VALUE()
    {
        attackCoefficients.Add("CharacterMage - CharacterMelee", COEFICIENT_ATTACK_MAGE_MELEE);
        attackCoefficients.Add("CharacterMelee - CharacterArcher", COEFICIENT_ATTACK_MELEE_ARCHER);
        attackCoefficients.Add("CharacterArcher - CharacterMage", COEFICIENT_ATTACK_ARCHER_MAGE);
    }
    public static float GetAttackCoefficient(string playerTag,string enemyTag)
    {
        string key = playerTag + " - " + enemyTag;
        if (attackCoefficients.ContainsKey(key))
        {
            return attackCoefficients[key];
        }
        else
        {
            return 1f; // Giá tr? m?c ??nh n?u không tìm th?y key phù h?p
            
        }
    }
}
