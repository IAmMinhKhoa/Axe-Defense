using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Damage_All : BaseProactiveSkill
{
    [SerializeField] protected int damage;
    public override void TODOSKILL()
    {
        SoundManager.instance.PlaySound(SoundType.SFX_SkilDeadAll);
        foreach (GameObject obejct in objectsWithLayer)
        {
            Health H_Object = obejct.GetComponent<Health>();
            if (H_Object != null)
            {
                GameObject FX_BrokenHeart = EffectManager.instance.SpawmVFX("VFX_BrokenHeart", H_Object.gameObject.transform.position, ObjectPoolManager.Pooltyle.ParticleSystem);
                H_Object.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Can't Found Damage ALl In " + obejct);
            }
        }
        Destroy(gameObject);
    }


}
