using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI_Card : MonoBehaviour
{
    protected GameObject G_Prefab_InCard;
    public TextMeshProUGUI textCostSummon;
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
        Instantiate(G_Prefab_InCard, P_Summon, Quaternion.identity);
    }

    public void SetEvent_SummonPrefab(Vector3 Position)
    {
        P_Summon = Position;
        E_Summon_Prefab?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void LoadDatatoCard() { }


    public virtual int GetCostSummon() { return 0; }
}
