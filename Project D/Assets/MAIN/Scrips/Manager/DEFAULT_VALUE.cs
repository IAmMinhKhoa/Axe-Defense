using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DEFAULT_VALUE
{
    public static float COEFICIENT_ATTACK_DEFAULT = 1f;
    public static float COEFICIENT_ATTACK_MAGE=1.2f;
    public static float COEFICIENT_ATTACK_MELEE = 1.3f;
    public static float COEFICIENT_ATTACK_ARCHER = 1.4f;

    public static float GetAttackCoefficient(string playerTag,string enemyTag)
    {
        if (enemyTag == playerTag)
        {
            return DEFAULT_VALUE.COEFICIENT_ATTACK_DEFAULT;
        }
        else
        {
            switch (enemyTag)
            {
                case "CharacterMage":
                    return DEFAULT_VALUE.COEFICIENT_ATTACK_MAGE;
                case "CharacterMelee":
                    return DEFAULT_VALUE.COEFICIENT_ATTACK_MELEE;
                case "Tower":
                    return DEFAULT_VALUE.COEFICIENT_ATTACK_DEFAULT;
                default:
                    return 1f; // Giá tr? m?c ??nh n?u không tìm th?y tag phù h?p
            }
        }
    }
}
