using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerSummon : MonoBehaviour
{
    public static ControllerSummon instance;


    #region Entity-UI
    [Header("Entity-UI")]
    [SerializeField] protected TextMeshProUGUI textCountMana;
    [SerializeField] protected TextMeshProUGUI textAddManaByTime;
    [SerializeField] protected TextMeshProUGUI textCountDeckCard;
    #endregion
    [Space(20)]


    #region Variable
    [Header("Entity-UI")]
    public int BounsMana;
    public int DefaultMana;
    public int ManaMax;
    public int TimeBoundMana;
    #endregion
    [Space(20)]


    #region GameObject
    [Header("Entity-UI")]
    [HideInInspector]
    public GameObject BrCanDrop;
    public GameObject BrNotCanDrop;
    #endregion
    [Space(20)]

    #region LIMIT_CARD_SUMMON (Set up befor game play)
    [Header("LIMIT_CARD_SUMMON (Set up befor game play)")]
    public bool UNCLOCK_FUNCTION_LIMIT_CARD;
    public int MaxCardSummon = 10;
    protected int tempCountCardSummon;
    #endregion
    [Space(20)]


    #region List
    [Header("Entity-UI")]
    [SerializeField] protected List<GameObject> L_Card_Character = new List<GameObject>();
    #endregion





    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
       
        PlayerPrefs.SetInt("Mana_InGame", DefaultMana);
        InvokeRepeating("RepeatAddMana", 1, TimeBoundMana);//first: function, second: time firt to run that function, third: time every second to recall that function
        textAddManaByTime.text = "+" + BounsMana.ToString()+" Mana/"+TimeBoundMana.ToString()+"s";

        if (UNCLOCK_FUNCTION_LIMIT_CARD)
        {
            InIt_Function_Limit_Card();
        }
        else
        {
            textCountDeckCard.enabled=false;
        }

        TurnOffBR();
        LoadCard();
    }
    private void Update()
    {
        textCountMana.text = PlayerPrefs.GetInt("Mana_InGame").ToString() +"/"+ManaMax;
    }

    public void AddAndSaveMana(int value)
    {
        int nowMana = PlayerPrefs.GetInt("Mana_InGame");
        int temp = nowMana + value;
        if (temp >= ManaMax)
        {
            temp = ManaMax;
        }
        PlayerPrefs.SetInt("Mana_InGame", temp);
    }
    private void RepeatAddMana()
    {
        AddAndSaveMana(BounsMana);
    }


    #region FUNCTION_LIMIT_CARD

    protected void InIt_Function_Limit_Card()
    {
        tempCountCardSummon = MaxCardSummon;
        SetTextCountCardOnDeck(MaxCardSummon);
    }
    public void SubtractionCountOfDeckSummon() //subtraction count of deck card
    {
        if (UNCLOCK_FUNCTION_LIMIT_CARD)
        {
            tempCountCardSummon--;
            if (tempCountCardSummon < 0)
            {
                GAMEPLAYmanager.instance.stateGame = GAMEPLAYmanager.StateGame.Lose;
            }
            SetTextCountCardOnDeck(tempCountCardSummon);
        }
        
    }

    protected void SetTextCountCardOnDeck(int CurrentValueCount)
    {
        textCountDeckCard.text = CurrentValueCount.ToString() + "/" + MaxCardSummon + " Card";
        if (CurrentValueCount <= 10 && CurrentValueCount > 5)
        {
            textCountDeckCard.color = Color.yellow;
        }
        else if (CurrentValueCount <= 5)
        {
            textCountDeckCard.color = Color.red;
        }
    }
    #endregion


    public void TurnOffBR()
    {
        BrCanDrop.SetActive(false);
        BrNotCanDrop.SetActive(false);
    }
    
    protected void LoadCard()
    {
        for (int i = 0; i < 4; i++)
        {
            CreatRandomCard();
        }
    }

    public void CreatRandomCard()
    {
        System.Random random = new System.Random();
        int Random_Card = random.Next(0, L_Card_Character.Count);
        GameObject Card = Instantiate(L_Card_Character[Random_Card]);
        Card.transform.SetParent(this.transform, false);
    }

}
