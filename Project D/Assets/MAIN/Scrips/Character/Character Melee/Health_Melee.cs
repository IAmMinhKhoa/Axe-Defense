using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Melee : Health
{
    protected ControllerChacracrer controllerChacracrer;
    private void Start()
    {
        if (!(controllerChacracrer = GetComponent<ControllerChacracrer>()))
        {
            Debug.LogWarning("Can't Getcomponet" + this.gameObject.name);
        }
        
        
       
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
