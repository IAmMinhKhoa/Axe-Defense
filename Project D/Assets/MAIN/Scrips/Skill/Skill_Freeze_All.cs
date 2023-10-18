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
        yield return new WaitForSeconds(timeFreeze);

        CObject.SetFreeze(false);
    }
}
