using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Ranged : Health
{
    protected ControllerChacracrer controllerChacracrer;
    private void Start()
    {
        controllerChacracrer = GetComponent<ControllerChacracrer>();
    
    }
    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);

    }

    protected override void EventDie()
    {
        controllerChacracrer.OnCharacterDie();
    }
    protected override void EventHit()
    {
        controllerChacracrer.OnCharacterHIT();
    }
}
