using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Freeze_All : BaseProactiveSkill
{
    [SerializeField] protected int timeFreeze=2;
    public override void TODOSKILL()
    {
        foreach (GameObject obejct in objectsWithLayer)
        {
            ControllerChacracrer CTC_Object = obejct.GetComponent<ControllerChacracrer>();
            if (CTC_Object != null)
            {
                StartCoroutine(StartSkill(CTC_Object));
            }
            else
            {
                Debug.LogWarning("Can't Found Freeze In " + obejct);
            }
        }
    }


    private IEnumerator StartSkill(ControllerChacracrer CObject)
    {
        CObject.SetFreeze(true);
        GameObject  FX_Freeze= EffectManager.instance.SpawmVFX("VFX_Freeze", CObject.gameObject.transform.position, ObjectPoolManager.Pooltyle.ParticleSystem);
        SoundManager.instance.PlaySound(SoundType.SFX_Freeze);
        
        yield return new WaitForSeconds(timeFreeze);

        CObject.SetFreeze(false);
        FX_Freeze.SetActive(false);
        Destroy(gameObject);
    }
}
