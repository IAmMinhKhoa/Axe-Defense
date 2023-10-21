using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    public static AddCard Instance { get; private set; }

    public List<GameObject> meleeCards, mageCards, archerCards, skillCards;

    [SerializeField]
    private Transform meleeContent, mageContent, archerContent, skillContent;

    [SerializeField]
    private GameObject meleeCardPrefab, mageCardPrefab, archerCardPrefab, skillCardPrefab;

    public List<SO_CharacterInforMantion> meleeSOList;
    public List<SO_CharacterInforMantionRANGER> archerSOList;
    public List<SO_CharacterInforMantionRANGER> mageSOList;
    public List<SO_Active_Skill> skillSOList;

    private void Awake()
    {
        Instance = this;
        meleeCards = new List<GameObject>();
        mageCards = new List<GameObject>();
        archerCards = new List<GameObject>();
        skillCards = new List<GameObject>();

        meleeSOList = new List<SO_CharacterInforMantion>(Resources.LoadAll<SO_CharacterInforMantion>("SO_Shop/Melee"));
        mageSOList = new List<SO_CharacterInforMantionRANGER>(Resources.LoadAll<SO_CharacterInforMantionRANGER>("SO_Shop/Mage"));
        archerSOList = new List<SO_CharacterInforMantionRANGER>(Resources.LoadAll<SO_CharacterInforMantionRANGER>("SO_Shop/Archer"));
        skillSOList = new List<SO_Active_Skill>(Resources.LoadAll<SO_Active_Skill>("SO_Shop/Skill"));
    }

    private void Start()
    {
        AddCardByTab();
    }

    private void AddCardByTab()
    {
        //Add Melee Card
        for (int i = 0; i < meleeSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(meleeCardPrefab);
            cardButton.name = "Melee_Card " + i;
            cardButton.transform.SetParent(meleeContent, false);
            cardButton.GetComponent<AddValue_Melee>().axieSO = meleeSOList[i];
            meleeCards.Add(cardButton);
        }

        //Add Archer Card
        for (int i = 0; i < mageSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(mageCardPrefab);
            cardButton.name = "Mage_Card " + i;
            cardButton.transform.SetParent(mageContent, false);
            cardButton.GetComponent<AddValue_ArcherOrMelee>().axieRANGERSO = mageSOList[i];
            mageCards.Add(cardButton);
        }

        //Add Mage Card
        for (int i = 0; i < archerSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(archerCardPrefab);
            cardButton.name = "Archer_Card " + i;
            cardButton.transform.SetParent(archerContent, false);
            cardButton.GetComponent<AddValue_ArcherOrMelee>().axieRANGERSO = archerSOList[i];
            archerCards.Add(cardButton);
        }

        //Add Skill Card
        for (int i = 0; i < skillSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(skillCardPrefab);
            cardButton.name = "Skill_Card " + i;
            cardButton.transform.SetParent(skillContent, false);
            cardButton.GetComponent<AddValue_Skill>().skillSO = skillSOList[i];
            skillCards.Add(cardButton);
        }
    }
}
