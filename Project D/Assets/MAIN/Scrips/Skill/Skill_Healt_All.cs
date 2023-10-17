using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Healt_All : BaseProactiveSkill
{
    [SerializeField] protected int Value_Health_Regeneration = 10;


    public override void TODOSKILL()
    {
        foreach (GameObject obejct in objectsWithLayer)
        {
            Health H_Object = obejct.GetComponent<Health>();
            if (H_Object != null)
            {
                H_Object.SetHealth(H_Object.maxHealt);
            }
            else
            {
                Debug.LogWarning("Can't Found Healt In " + obejct);
            }
        }
    }


}
