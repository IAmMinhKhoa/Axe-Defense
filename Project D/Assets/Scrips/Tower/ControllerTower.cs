using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTower : MonoBehaviour
{
    #region Event
    public event EventHandler E_TowerDie;
    public event EventHandler E_TowerHit;
    #endregion




    public void OnTowerDie()
    {
        E_TowerDie?.Invoke(this, EventArgs.Empty);
    }
    public void OnTowerHit()
    {
        E_TowerHit?.Invoke(this, EventArgs.Empty);
    }
}

