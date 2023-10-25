using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class Inventory_AddCard : MonoBehaviour
{
    public static Inventory_AddCard instance;

  

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


    public Transform contentPickCard;
    public Transform contentInventory;
    public SO_DeskCard SO_DeckCard;
    public TextMeshProUGUI TextCountCardInDeck;
    public int CountCardOnDeck;


    private void OnEnable()
    {
      

        loadedMelee = Resources.LoadAll<SO_CharacterInforMantion>("ShopCard/Melee");
        loadedArchers = Resources.LoadAll<SO_CharacterInforMantion>("ShopCard/Archer");
        loadedMages = Resources.LoadAll<SO_CharacterInforMantion>("ShopCard/Mage");
        loadedSkills = Resources.LoadAll<SO_Active_Skill>("ShopCard/Skill");

        InItCardOnDeckToContentPickCard();
        AddCardByTab();
    }

    private void Start()
    {
        //meleeSOList = CardManager.instance.meleeSOList;
        //mageSOList = CardManager.instance.mageSOList;
        //archerSOList = CardManager.instance.archerSOList;
        //skillSOList = CardManager.instance.skillSOList;

        instance = this;

        meleeSOList = new List<SO_CharacterInforMantion>(loadedMelee);
        mageSOList = new List<SO_CharacterInforMantion>(loadedMages);
        archerSOList = new List<SO_CharacterInforMantion>(loadedArchers);
        skillSOList = new List<SO_Active_Skill>(loadedSkills);

        AddCardByTab();


      
    }
    private void Update()
    {
        CountCardOnDeck = contentPickCard.childCount;
        TextCountCardInDeck.text = CountCardOnDeck.ToString();
       
    }

    private void AddCardByTab()
    {
        foreach (Transform child in inventoryContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }



        //Add Melee Card
        for (int i = 0; i < meleeSOList.Count; i++)
        {
            if (meleeSOList[i].ACTIVE && !SOAxieInDeck(meleeSOList[i]))
            {
                GameObject cardButton = Instantiate(meleeCardPrefab);
                cardButton.name = "Melee_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = meleeSOList[i];
               


                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;
            }
        }

        //Add Archer Card
        for (int i = 0; i < mageSOList.Count; i++)
        {
            if (mageSOList[i].ACTIVE && !SOAxieInDeck(mageSOList[i]))
            {
                GameObject cardButton = Instantiate(mageCardPrefab);
                cardButton.name = "Mage_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = mageSOList[i];
                


                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;
            }
        }

        //Add Mage Card
        for (int i = 0; i < archerSOList.Count; i++)
        {
            if (archerSOList[i].ACTIVE && !SOAxieInDeck(archerSOList[i]))
            {
                GameObject cardButton = Instantiate(archerCardPrefab);
                cardButton.name = "Archer_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = archerSOList[i];
                

                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;
            }
        }

        //Add Skill Card
        for (int i = 0; i < skillSOList.Count; i++)
        {
            if (skillSOList[i].ACTIVE && !SOSkillInDeck(skillSOList[i]))
            {
                GameObject cardButton = Instantiate(skillCardPrefab);
                cardButton.name = "Skill_Card " + i;
                cardButton.transform.SetParent(inventoryContent, false);
                cardButton.GetComponent<AddValueSkill>().skillSO = skillSOList[i];
                

                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;
            }
        }
    }

    protected void InItCardOnDeckToContentPickCard()
    {
        foreach (Transform child in contentPickCard.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    



        foreach (SO_CharacterInforMantion SO in SO_DeckCard.ListCardAxie)
        {
            if (SO.typeCharacter.ToString()=="Mage")
            {
                GameObject cardButton = Instantiate(mageCardPrefab);
                
                cardButton.transform.SetParent(contentPickCard, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = SO;
               

                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;

                SetUpCard.isPickCard = true;
            }else if(SO.typeCharacter.ToString() == "Archer")
            {
  
                GameObject cardButton = Instantiate(archerCardPrefab);
                
                cardButton.transform.SetParent(contentPickCard, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = SO;
               
                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;

                SetUpCard.isPickCard = true;
            }
            else if(SO.typeCharacter.ToString() == "Melee"){
                GameObject cardButton = Instantiate(meleeCardPrefab);
                
                cardButton.transform.SetParent(contentPickCard, false);
                cardButton.GetComponent<AddValueAxie>().axieSO = SO;
                

                SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
                SetUpCard.contentInventory = contentInventory;
                SetUpCard.contentPickCard = contentPickCard;
                SetUpCard.SO_DeckCard = SO_DeckCard;

                SetUpCard.isPickCard = true;
            }
        }

        foreach (SO_Active_Skill SOSkill in SO_DeckCard.ListCardSkill)
        {
            GameObject cardButton = Instantiate(skillCardPrefab);
      
            cardButton.transform.SetParent(contentPickCard, false);
            cardButton.GetComponent<AddValueSkill>().skillSO = SOSkill;
            

            SetUpCardToDeck SetUpCard = cardButton.GetComponent<SetUpCardToDeck>();
            SetUpCard.contentInventory = contentInventory;
            SetUpCard.contentPickCard = contentPickCard;
            SetUpCard.SO_DeckCard = SO_DeckCard;

            SetUpCard.isPickCard = true;
        }
    }
   


    protected bool SOAxieInDeck(SO_CharacterInforMantion SO_Index)
    {
        foreach (SO_CharacterInforMantion SO in SO_DeckCard.ListCardAxie)
        {
            if (SO == SO_Index)
            {
                return true;
            }
        }
        return false;
    }

    protected bool SOSkillInDeck(SO_Active_Skill SO_Index)
    {
        foreach (SO_Active_Skill SO in SO_DeckCard.ListCardSkill)
        {
            if (SO == SO_Index)
            {
                return true;
            }
        }
        return false;
    }
}
