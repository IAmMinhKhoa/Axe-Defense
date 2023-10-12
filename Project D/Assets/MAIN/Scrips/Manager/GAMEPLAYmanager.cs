using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEPLAYmanager : MonoBehaviour
{
    public GameObject TowerPlayer, TowerEnemy;

    public GameObject BRWin;
    public GameObject BRLose;
    private void Update()
    {
        if (TowerPlayer == null)
        {
            BRLose.SetActive(true);
        }else if(TowerEnemy == null)
        {
            BRWin.SetActive(true);
        }
    }
}
