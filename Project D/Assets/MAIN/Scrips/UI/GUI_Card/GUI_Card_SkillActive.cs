using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Card_SkillActive : GUI_Card
{
    #region Entity-UI-Card-Skill
    public TextMeshProUGUI textDescription;
    public Image IMG_Avatar;
    #endregion

    #region Component
    public SO_Active_Skill SO_Infor;
    #endregion

    public override void LoadDatatoCard()
    {
        string Cost = SO_Infor.CostSummon.ToString();
        string Scrip = SO_Infor.InforSkill.ToString();
        Sprite Img = SO_Infor.Avatar;
        GameObject Prefab_Char = SO_Infor.G_Skill;

        textCostSummon.text = Cost;
        textDescription.text = Scrip;
        IMG_Avatar.sprite = Img;
        G_Prefab_InCard = Prefab_Char;
    }
    public override int GetCostSummon() { return SO_Infor.CostSummon; }
}
