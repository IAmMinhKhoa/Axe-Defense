using System.Collections;
using System.Collections.Generic;
using Spine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.Rendering.DebugUI;

public class Healt : MonoBehaviour
{
    [SerializeField]protected int maxHealt = 100;

    protected float delayAnimationHit = 0.25f;


    protected float delayStatusAttack =2.5f;

    protected bool isAttacking;

    protected Animator animatorCharacter;

    private void Start()
    {
        animatorCharacter=GetComponent<ControllerChacracrer>().animatorChar; 
    }

    public void TakeDamage(int value)
    {
        
        isAttacking = true;
        

        maxHealt -= value;
        animatorCharacter.SetTrigger("Hit");

        //Effect Hit Mage
        EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform);
        if (maxHealt <= 0)
        {
            animatorCharacter.SetTrigger("Die");
            Destroy(gameObject,1.5f);
        }
        StartCoroutine(DelayATK());
    }
    


    IEnumerator DelayATK()
    {
        yield return new WaitForSeconds(delayStatusAttack);

        isAttacking = false;
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }
}
