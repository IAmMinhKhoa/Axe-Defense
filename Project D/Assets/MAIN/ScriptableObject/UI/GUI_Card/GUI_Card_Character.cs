using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Card_Character : GUI_Card
{
    #region Entity-UI-Card-Character
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textDamage;
    public Image IMG_Avatar;
    #endregion

    #region Component
    [SerializeField] protected SO_CharacterInforMantion SO_Infor;
    #endregion

    protected override void LoadDatatoCard()
    {
        string Name = SO_Infor.nameChar.ToString();
        string Cost = SO_Infor.CostSummon.ToString();
        string HP = SO_Infor.HP.ToString();
        string Damage = SO_Infor.Damge.ToString();
        Sprite Img = SO_Infor.Avatar;
        GameObject Prefab_Char = SO_Infor.Prefab_Character;

        textCostSummon.text = Cost;
        textName.text = Name;
        textHP.text = HP;
        textDamage.text = Damage;
        IMG_Avatar.sprite = Img;

        G_Prefab_InCard = Prefab_Char;
    }
    public override int GetCostSummon() { return SO_Infor.CostSummon; }
}
