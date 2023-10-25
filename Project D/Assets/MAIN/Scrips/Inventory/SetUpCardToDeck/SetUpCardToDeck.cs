using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCardToDeck : MonoBehaviour
{
    public Transform contentPickCard;
    public Transform contentInventory;
    public SO_DeskCard SO_DeckCard;
    public bool isPickCard=false;
    

    private void Start()
    {
       // add = GetComponent<AddValueAxie>();
    }
    public  void eventClickCard()
    {
        if (!isPickCard && Inventory_AddCard.instance.CountCardOnDeck<4)
        {
            isPickCard = true;
            transform.SetParent(this.contentPickCard, false);

           
            if (checkCardAxieOrNot())//if day la card axie
            {
                SO_DeckCard.ListCardAxie.Add(GetComponent<AddValueAxie>().axieSO);
            }
            else
            {
                SO_DeckCard.ListCardSkill.Add(GetComponent<AddValueSkill>().skillSO);
            }
        }
        else if(isPickCard && Inventory_AddCard.instance.CountCardOnDeck!=1)
        {
            isPickCard = false;
            transform.SetParent(this.contentInventory, false);

            if (checkCardAxieOrNot())//if day la card axie
            {
                DeleteSOAxieCard(GetComponent<AddValueAxie>().axieSO);
            }
            else
            {
                DeleteSOSkillCard(GetComponent<AddValueSkill>().skillSO);
            }
        }
    
    }
    protected bool checkCardAxieOrNot()
    {
        if (this.GetComponent<AddValueAxie>())
        {
            return true;
        }
        else
        {
            return false;   
        }
    }

    protected void DeleteSOAxieCard(SO_CharacterInforMantion SO_CharacterInforMantion)
    {
        List<SO_CharacterInforMantion> toRemove = new List<SO_CharacterInforMantion>();

        foreach (SO_CharacterInforMantion SO in SO_DeckCard.ListCardAxie)
        {
            if (SO == SO_CharacterInforMantion)
            {
                toRemove.Add(SO);
            }
        }

        foreach (SO_CharacterInforMantion SO in toRemove)
        {
            SO_DeckCard.ListCardAxie.Remove(SO);
        }
    }

    protected void DeleteSOSkillCard(SO_Active_Skill SO_active_skill)
    {
        List<SO_Active_Skill> toRemove = new List<SO_Active_Skill>();

        foreach (SO_Active_Skill SO in SO_DeckCard.ListCardSkill)
        {
            if (SO == SO_active_skill)
            {
                toRemove.Add(SO);
            }
        }

        foreach (SO_Active_Skill SO in toRemove)
        {
            SO_DeckCard.ListCardSkill.Remove(SO);
        }
    }
}
