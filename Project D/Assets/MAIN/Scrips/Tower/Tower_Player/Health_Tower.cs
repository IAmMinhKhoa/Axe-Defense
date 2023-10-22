using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Tower : Health
{
    protected ControllerTower controllerTower;
    private void Start()
    {
        controllerTower = GetComponent<ControllerTower>();
        SetHealth(maxHealt); 
    }
    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
       
    }
    protected override void EventDie()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GAMEPLAYmanager.instance.stateGame = GAMEPLAYmanager.StateGame.Win;
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GAMEPLAYmanager.instance.stateGame = GAMEPLAYmanager.StateGame.Lose;
        }
        controllerTower.OnTowerDie();
    }
    protected override void EventHit()
    {    
        controllerTower.OnTowerHit();
    }
}
