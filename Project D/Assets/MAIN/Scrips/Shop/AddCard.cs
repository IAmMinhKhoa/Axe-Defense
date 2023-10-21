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

    public List<GameObject> cardMeleeButtons, cardMageButtons, cardArcherButtons;

    [SerializeField]
    private Transform meleeContent, mageContent, archerContent;

    [SerializeField]
    private GameObject meleeCardPrefeb, mageCardPrefeb, archerCardPrefeb;

    public List<SO_CharacterInforMantion> meleeSOList;
    public List<SO_CharacterInforMantionRANGER> archerSOList;
    public List<SO_CharacterInforMantionRANGER> mageSOList;

    private void Awake()
    {
        Instance = this;
        cardMeleeButtons = new List<GameObject>();
        cardMageButtons = new List<GameObject>();
        cardArcherButtons = new List<GameObject>();

        meleeSOList = new List<SO_CharacterInforMantion>(Resources.LoadAll<SO_CharacterInforMantion>("SO_Axie/Melee"));
        mageSOList = new List<SO_CharacterInforMantionRANGER>(Resources.LoadAll<SO_CharacterInforMantionRANGER>("SO_Axie/Mage"));
        archerSOList = new List<SO_CharacterInforMantionRANGER>(Resources.LoadAll<SO_CharacterInforMantionRANGER>("SO_Axie/Archer"));
    }

    private void Start()
    {
        Debug.Log(TabController.instance.currentTab);
        AddCardByTab();
    }

    private void AddCardByTab()
    {
        for (int i = 0; i < meleeSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(meleeCardPrefeb);
            cardButton.name = "Melee_Card " + i;
            cardButton.transform.SetParent(meleeContent, false);
            cardButton.GetComponent<AddValue_Melee>().axieSO = meleeSOList[i];
            cardMeleeButtons.Add(cardButton);
        }

        for (int i = 0; i < mageSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(mageCardPrefeb);
            cardButton.name = "Mage_Card " + i;
            cardButton.transform.SetParent(mageContent, false);
            cardButton.GetComponent<AddValue_ArcherOrMelee>().axieRANGERSO = mageSOList[i];
            cardMageButtons.Add(cardButton);
        }
        for (int i = 0; i < archerSOList.Count; i++)
        {
            GameObject cardButton = Instantiate(archerCardPrefeb);
            cardButton.name = "Archer_Card " + i;
            cardButton.transform.SetParent(archerContent, false);
            cardButton.GetComponent<AddValue_ArcherOrMelee>().axieRANGERSO = archerSOList[i];
            cardArcherButtons.Add(cardButton);
        }
    }
}
