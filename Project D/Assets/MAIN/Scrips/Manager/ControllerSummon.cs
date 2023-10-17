using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerSummon : MonoBehaviour
{
    public static ControllerSummon instance;

    [SerializeField] protected TextMeshProUGUI textCountMana;
    [SerializeField] protected TextMeshProUGUI textAddManaByTime;
    [SerializeField] protected TextMeshProUGUI textCountDeckCard;


    public int BounsMana;
    public int DefaultMana;
    public int ManaMax;
    public int TimeBoundMana;

    public int MaxCardSummon = 10;
    protected int tempCountCardSummon;

    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
       
        PlayerPrefs.SetInt("Mana_InGame", DefaultMana);
        InvokeRepeating("RepeatAddMana", 1, TimeBoundMana);//first: function, second: time firt to run that function, third: time every second to recall that function
        textAddManaByTime.text = "+" + BounsMana.ToString()+" Mana/"+TimeBoundMana.ToString()+"s";

        tempCountCardSummon = MaxCardSummon;
        SetTextCountCardOnDeck(MaxCardSummon);
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

    public void SubtractionCountOfDeckSummon() //subtraction count of deck card
    {
        tempCountCardSummon--;
        if (tempCountCardSummon < 0)
        {
            GAMEPLAYmanager.instance.stateGame = GAMEPLAYmanager.StateGame.Lose;
        }
        SetTextCountCardOnDeck(tempCountCardSummon);
    }

    protected void SetTextCountCardOnDeck(int CurrentValueCount)
    {
        textCountDeckCard.text=CurrentValueCount.ToString()+"/"+MaxCardSummon +" Card";
        if (CurrentValueCount <= 10 && CurrentValueCount>5)
        {
            textCountDeckCard.color = Color.yellow;
        }else if(CurrentValueCount <= 5)
        {
            textCountDeckCard.color = Color.red;
        }
    }
}
