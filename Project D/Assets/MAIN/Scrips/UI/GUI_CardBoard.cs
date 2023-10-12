using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI_CardBoard : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public GameObject G_Prefab_Character;


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


    
}
