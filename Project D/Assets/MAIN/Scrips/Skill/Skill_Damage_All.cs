using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Damage_All : BaseProactiveSkill
{
    [SerializeField] protected int damage;
    public override void TODOSKILL()
    {
        foreach (GameObject obejct in objectsWithLayer)
        {
            Health H_Object = obejct.GetComponent<Health>();
            if (H_Object != null)
            {
                H_Object.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Can't Found Damage ALl In " + obejct);
            }
        }
    }
}
