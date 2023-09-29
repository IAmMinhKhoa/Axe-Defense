using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Tower : Health
{
    protected ControllerTower controllerTower;
    private void Start()
    {
        controllerTower = GetComponent<ControllerTower>();

    }
    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
    }
    protected override void EventDie()
    {
        controllerTower.OnTowerDie();
    }
    protected override void EventHit()
    {    
        controllerTower.OnTowerHit();
    }
}
