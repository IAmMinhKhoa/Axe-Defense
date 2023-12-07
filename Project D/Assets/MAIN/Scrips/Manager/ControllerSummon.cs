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
   // [SerializeField] protected List<GameObject> L_Card_Character = new List<GameObject>();



    [SerializeField] protected SO_DeskCard SO_CardOnDeck;
    [SerializeField] protected List<InforCard> L_Card_Default = new List<InforCard>();
    #endregion


    string encryptedValue;

    private void Awake()
    {
        instance = this;
        SetMana(DefaultMana);
    }
    private void Start()
    {
       
        //PlayerPrefs.SetInt("Mana_InGame", DefaultMana);
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
      
        textCountMana.text = GetMana()+ "/" + ManaMax;
        //Debug.Log(PlayerPrefs.GetInt("Mana_InGame"));
        //Debug.Log(GetMana());
    }

    //con 1 cho chua fix
    public void AddAndSaveMana(int value)
    {
        int nowMana = GetMana();
       // int temp = nowMana + value;
        /*if (temp >= ManaMax  )
        {
            temp = GetMana();
            
        }*/

        //DefaultMana = temp;
        //SetMana(temp);
        //Debug.Log(nowMana+"/"+temp + "/"+GetMana());
    }
    private void RepeatAddMana()
    {
        //AddAndSaveMana(BounsMana);
        SetMana(BounsMana + GetMana());
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
            if (tempCountCardSummon <= 0)
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
        //CoutCardOnDeck=7
        //randomc-card : 0 1 2 3 4 5 6                  

        int Random_Card = random.Next(0, SO_CardOnDeck.CoutCardOnDeck);
   
        if (Random_Card< SO_CardOnDeck.ListCardAxie.Count)  
        {
            foreach (InforCard inforCard in L_Card_Default)
            {
                if (inforCard.name_Type == SO_CardOnDeck.ListCardAxie[Random_Card].typeCharacter.ToString())
                {
                    GameObject Card = Instantiate(inforCard.card);

                    GUI_Card_Character gui_card = Card.GetComponent<GUI_Card_Character>();
                    gui_card.SO_Infor = SO_CardOnDeck.ListCardAxie[Random_Card];
                    gui_card.LoadDatatoCard();

                    Card.transform.SetParent(this.transform, false);
                }
            }
        }
        else
        {
            int index_In_ListCardSkill = SO_CardOnDeck.CoutCardOnDeck-Random_Card-1;
            foreach (InforCard inforCard in L_Card_Default)
            {
                if (inforCard.name_Type == "Skill")
                {
                    GameObject Card = Instantiate(inforCard.card);

                    GUI_Card_SkillActive gui_card = Card.GetComponent<GUI_Card_SkillActive>();
                    gui_card.SO_Infor = SO_CardOnDeck.ListCardSkill[index_In_ListCardSkill];
                    gui_card.LoadDatatoCard();

                    Card.transform.SetParent(this.transform, false);
                }
            }
        }
    }

    public void SetMana(int NewValue)
    {
        //update new coin
        DefaultMana = NewValue;
        encryptedValue = SecurityManager.Instance.Encrypt(DefaultMana.ToString());
        //  Debug.Log(encryptedValue);

    }


    public int GetMana()
    {
        //  Debug.Log(encryptedValue);
        string temp = SecurityManager.Instance.Decrypt(encryptedValue);
        int afterDecry = int.Parse(temp);
        if (afterDecry != DefaultMana)
        {
            Debug.Log("?????????????? CHEAT GI DO BRO");
            DefaultMana = afterDecry;
        }
        return afterDecry;
    }
}


[System.Serializable]
public class InforCard
{
    public string name_Type;
    public GameObject card;
}
