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
    public int BounsMana;
    protected int DefaultMana;
    public int ManaMax;
    public int TimeBoundMana;

    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
        DefaultMana = GAMEPLAYmanager.instance.DefaultMana;
        PlayerPrefs.SetInt("Mana_InGame", DefaultMana);
        InvokeRepeating("RepeatAddMana", 1, TimeBoundMana);//first: function, second: time firt to run that function, third: time every second to recall that function
        textAddManaByTime.text = "+" + BounsMana.ToString()+"/"+TimeBoundMana.ToString()+"s";
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
}
