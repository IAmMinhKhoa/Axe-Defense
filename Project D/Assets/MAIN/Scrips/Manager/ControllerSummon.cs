using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerSummon : MonoBehaviour
{
    public TextMeshProUGUI textCountMana;
    public int BounsMana=1;
    private void Awake()
    {
        PlayerPrefs.SetInt("Mana_InGame", 20);
    }
    private void Start()
    {
        InvokeRepeating("DelayedSum", 1, 1);//first: function, second: time firt to run that function, third: time every second to recall that function
    }
    private void Update()
    {
        textCountMana.text = PlayerPrefs.GetInt("Mana_InGame").ToString();
    }


    private void DelayedSum()
    {
        int nowMana = PlayerPrefs.GetInt("Mana_InGame");
        PlayerPrefs.SetInt("Mana_InGame", nowMana+BounsMana);
    }
}
