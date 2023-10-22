using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public List<SO_CharacterInforMantion> meleeSOList;

    public List<SO_CharacterInforMantionRANGER> archerSOList;

    public List<SO_CharacterInforMantionRANGER> mageSOList;

    public List<SO_Active_Skill> skillSOList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }
}
