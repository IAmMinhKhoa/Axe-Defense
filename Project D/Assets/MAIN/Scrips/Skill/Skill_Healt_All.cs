using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Healt_All : BaseProactiveSkill
{

    public override void TODOSKILL()
    {
        SoundManager.instance.PlaySound(SoundType.SFX_Health);
        foreach (GameObject obejct in objectsWithLayer)
        {
            Health H_Object = obejct.GetComponent<Health>();
            if (H_Object != null)
            {
                GameObject FX_BrokenHeart = EffectManager.instance.SpawmVFX("VFX_Health", H_Object.gameObject.transform.position, ObjectPoolManager.Pooltyle.ParticleSystem);
                H_Object.SetHealth(H_Object.maxHealt);
            }
            else
            {
                Debug.LogWarning("Can't Found Healt In " + obejct);
            }
        }
        Destroy(gameObject);
    }


}
