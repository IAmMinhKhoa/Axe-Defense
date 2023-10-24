using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_AddCard : MonoBehaviour
{
    public List<GameObject> meleeCards, mageCards, archerCards, skillCards;

    [SerializeField]
    private Transform inventoryContent;

    [SerializeField]
    private GameObject meleeCardPrefab, mageCardPrefab, archerCardPrefab, skillCardPrefab;

    public List<SO_CharacterInforMantion> meleeSOList;
    public List<SO_CharacterInforMantion> archerSOList;
    public List<SO_CharacterInforMantion> mageSOList;
    public List<SO_Active_Skill> skillSOList;

    SO_CharacterInforMantion[] loadedMelee;
    SO_CharacterInforMantion[] loadedArchers;
    SO_CharacterInforMantion[] loadedMages;
    SO_Active_Skill[] loadedSkills;

    private void Awake()
    {
        meleeCards = new List<GameObject>();
        mageCards = new List<GameObject>();
        archerCards = new List<GameObject>();
        skillCards = new List<GameObject>();

    }

    private void OnEnable()
    {
        loadedMelee = Resources.LoadAll<SO_CharacterInforMantion>("ShopCard/Melee");
        loadedArchers = Resources.LoadAll<SO_CharacterInforMantion>("ShopCard/Archer");
        loadedMages = Resources.LoadAll<SO_CharacterInforMantion>("ShopCard/Mage");
        loadedSkills = Resources.LoadAll<SO_Active_Skill>("ShopCard/Skill");
    }

    private void Start()
    {
        //meleeSOList = CardManager.instance.meleeSOList;
        //mageSOList = CardManager.instance.mageSOList;
        //archerSOList = CardManager.instance.archerSOList;
        //skillSOList = CardManager.instance.skillSOList;

        meleeSOList = new List<SO_CharacterInforMantion>(loadedMelee);
        mageSOList = new List<SO_CharacterInforMantion>(loadedMages);
        archerSOList = new List<SO_CharacterInforMantion>(loadedArchers);
        skillSOList = new List<SO_Active_Skill>(loadedSkills);

        AddCardByTab();
    }

    private void AddCardByTab()
    {
        //Add Melee Card
        for (int i = 0; i < meleeSOList.Count; i++)
        {
            if (meleeSOList[i].ACTIVE)
            {
                GameObject cardButton = Instantiate(meleeCardPrefab);
                cardButton.name = "Melee_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = meleeSOList[i];
                meleeCards.Add(cardButton);
            }
        }

        //Add Archer Card
        for (int i = 0; i < mageSOList.Count; i++)
        {
            if (mageSOList[i].ACTIVE)
            {
                GameObject cardButton = Instantiate(mageCardPrefab);
                cardButton.name = "Mage_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = mageSOList[i];
                mageCards.Add(cardButton);
            }
        }

        //Add Mage Card
        for (int i = 0; i < archerSOList.Count; i++)
        {
            if (archerSOList[i].ACTIVE)
            {
                GameObject cardButton = Instantiate(archerCardPrefab);
                cardButton.name = "Archer_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = archerSOList[i];
                archerCards.Add(cardButton);
            }
        }

        //Add Skill Card
        for (int i = 0; i < skillSOList.Count; i++)
        {
            if (skillSOList[i].ACTIVE)
            {
                GameObject cardButton = Instantiate(skillCardPrefab);
                cardButton.name = "Skill_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueSkill>().skillSO = skillSOList[i];
                skillCards.Add(cardButton);
            }
        }
    }
}
