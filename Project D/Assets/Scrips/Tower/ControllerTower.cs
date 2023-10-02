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

    #region GameObject
    [SerializeField] protected Animator[] L_A_InTower;
    #endregion
   
    protected void Init()
    {
        E_TowerHit += ControllerTower_E_TowerHit;
        E_TowerDie += ControllerTower_E_TowerDie;
    }
    private void ControllerTower_E_TowerDie(object sender, EventArgs e)
    {
        foreach (Animator A_each_InTower in L_A_InTower)
        {
            A_each_InTower.SetTrigger("Die");
        }
        
    }

    private void ControllerTower_E_TowerHit(object sender, EventArgs e)
    {

        foreach (Animator A_each_InTower in L_A_InTower)
        {
            A_each_InTower.SetTrigger("Hit");
        }
    }
    public void OnTowerHit()
    {
       
        E_TowerHit?.Invoke(this, EventArgs.Empty);
    }
    public void OnTowerDie()
    {
        E_TowerDie?.Invoke(this, EventArgs.Empty);
    }
    
}
