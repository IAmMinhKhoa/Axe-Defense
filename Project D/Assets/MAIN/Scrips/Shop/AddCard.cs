using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    public static AddCard Instance { get; private set; }

    public List<Button> meleeCardButtons, mageCardButtons, archerCardButtons;

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
        meleeCardButtons = new List<Button>();
        mageCardButtons = new List<Button>();
        archerCardButtons = new List<Button>();

        mageSOList = new List<SO_CharacterInforMantionRANGER>();
        meleeSOList = new List<SO_CharacterInforMantion>();
        archerSOList = new List<SO_CharacterInforMantionRANGER>();

        SO_CharacterInforMantion[] meleeSOArray = Resources.LoadAll<SO_CharacterInforMantion>("SO_Axie/Melee");
        meleeSOList.AddRange(meleeSOArray);

        SO_CharacterInforMantionRANGER[] archerSOArray = Resources.LoadAll<SO_CharacterInforMantionRANGER>("SO_Axie/Archer");
        archerSOList.AddRange(archerSOArray);

        SO_CharacterInforMantionRANGER[] mageSOArray = Resources.LoadAll<SO_CharacterInforMantionRANGER>("SO_Axie/Mage");
        mageSOList.AddRange(mageSOArray);
    }

    private void Start()
    {
        TabController.instance.OnAddCardMelee += AddCard_OnAddCardMelee;
    }

    private void AddCard_OnAddCardMelee(object sender, EventArgs e)
    {
        Debug.Log("Melee Tab");
        int meleeCount = meleeSOList.Count;
        Debug.Log(meleeCount);

        //for (int i = 0; i < meleeCount; i++)
        //{
        //    GameObject cardButton = Instantiate(meleeCardPrefeb);
        //    cardButton.name = "Melee_Card " + i;
        //    cardButton.transform.SetParent(meleeContent, false);
        //    meleeCardButtons.Add(cardButton.GetComponent<Button>());
        //}
    }

    private void AddCard_OnAddMeleeCard(object sender, EventArgs e)
    {
        
    }

    private void AddCard_OnAddArcherCard(object sender, EventArgs e)
    {
        
    }


    //private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    //{
    //    if (MiniGameManager.Instance.IsGamePlaying())
    //    {
    //        LevelButtonManager levelButtonManager = LevelButtonManager.Instance;
    //        int gameLevel = (int)levelButtonManager.gameLevel;

    //        if (gameLevel == 0)
    //        {
    //            // Mở khóa level Easy
    //            for (int i = 0; i < numberCardEasy; i++)
    //            {
    //                GameObject cardButton = Instantiate(Button);
    //                cardButton.name = "" + i;
    //                cardButton.transform.SetParent(puzzleField, false);
    //                cardButtons.Add(cardButton.GetComponent<Button>());
    //            }
    //        }
    //        else if (gameLevel == 1)
    //        {
    //            // Mở khóa level Medium
    //            for (int i = 0; i < numberCardMedium; i++)
    //            {
    //                GameObject cardButton = Instantiate(Button);
    //                cardButton.name = "" + i;
    //                cardButton.transform.SetParent(puzzleField, false);
    //                cardButtons.Add(cardButton.GetComponent<Button>());
    //            }
    //        }
    //        else if (gameLevel == 2)
    //        {
    //            // Mở khóa level Hard
    //            for (int i = 0; i < numberCardHard; i++)
    //            {
    //                GameObject cardButton = Instantiate(Button);
    //                cardButton.name = "" + i;
    //                cardButton.transform.SetParent(puzzleField, false);
    //                cardButtons.Add(cardButton.GetComponent<Button>());
    //            }
    //        }
    //    }
    //}

    //public void DestroyCardButtons()
    //{
    //    foreach (Button cardButton in cardButtons)
    //    {
    //        Destroy(cardButton.gameObject);
    //    }

    //    cardButtons.Clear();
    //}
}
