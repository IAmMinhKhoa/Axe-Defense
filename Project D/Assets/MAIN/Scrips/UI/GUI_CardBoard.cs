using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_CardBoard : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textCostSummon;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textDamage;
    public Image IMG_Avatar;
    protected GameObject G_Prefab_Character;


    public event EventHandler E_Summon_Prefab;


    protected Vector3 P_Summon;
    

    private void Start()
    {
        E_Summon_Prefab += GUI_CardBoard_E_Summon_Prefab;
    }

    private void GUI_CardBoard_E_Summon_Prefab(object sender, EventArgs e)
    {
        Instantiate(G_Prefab_Character, P_Summon, Quaternion.identity);
    }

    public void SetEvent_SummonPrefab(Vector3 Position)
    {
        P_Summon = Position;
        E_Summon_Prefab?.Invoke(this, EventArgs.Empty); 
    }

    public void SetPrefabSummon(GameObject obj)
    {
        G_Prefab_Character = obj;
    }
    
    public void SetDataToCard(string name, string cost,  string HP, string damage,Sprite img, GameObject prefab_Summon)
    {
        textCostSummon.text = cost;
        textName.text = name;
        textHP.text = HP;   
        textDamage.text = damage;   
        IMG_Avatar.sprite=img;

        G_Prefab_Character = prefab_Summon;
    }

}