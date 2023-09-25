using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Melee : Health
{
    protected ControllerChacracrer controllerChacracrer;
    private void Start()
    {
        controllerChacracrer = GetComponent<ControllerChacracrer>();
    }
    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);

        EffectManager.instance.SpawmVFX("Effect Hit Melee", this.transform.position);
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
