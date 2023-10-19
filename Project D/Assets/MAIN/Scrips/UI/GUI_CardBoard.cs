using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_CardBoard : MonoBehaviour
{
    #region Entity-UI-Card
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textCostSummon;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textDamage;
    public Image IMG_Avatar;
    protected GameObject G_Prefab_Character;
    #endregion

    #region Component
    [SerializeField] protected SO_CharacterInforMantion SO_Infor;
    #endregion

    #region Event
    public event EventHandler E_Summon_Prefab;
    #endregion

    #region Variable
    protected Vector3 P_Summon;
    #endregion


    private void Start()
    {
        E_Summon_Prefab += GUI_CardBoard_E_Summon_Prefab;
        LoadDatatoCard();
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

    
    public void SetDataToCard(string name, string cost,  string HP, string damage,Sprite img, GameObject prefab_Summon)
    {
        textCostSummon.text = cost;
        textName.text = name;
        textHP.text = HP;   
        textDamage.text = damage;   
        IMG_Avatar.sprite=img;

        G_Prefab_Character = prefab_Summon;
    }

    protected void LoadDatatoCard()
    {
            string Name = SO_Infor.nameChar.ToString();
            string Cost = SO_Infor.CostSummon.ToString();
            string HP = SO_Infor.HP.ToString();
            string Damage = SO_Infor.Damge.ToString();
            Sprite Img = SO_Infor.Avatar;
            GameObject Prefab_Char = SO_Infor.Prefab_Character;

        SetDataToCard(Name, Cost, HP, Damage, Img, Prefab_Char);
    }

}
