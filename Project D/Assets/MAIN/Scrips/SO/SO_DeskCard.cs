using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(menuName = "New Deck")]
public class SO_DeskCard : ScriptableObject
{
    public List<SO_CharacterInforMantion> ListCardAxie = new List<SO_CharacterInforMantion>();
    public List<SO_Active_Skill> ListCardSkill = new List<SO_Active_Skill>();
    public int CoutCardOnDeck
    {
        get { return ListCardAxie.Count + ListCardSkill.Count; }
    }



}
