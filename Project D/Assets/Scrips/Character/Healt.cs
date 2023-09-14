using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    protected int maxHealt = 100;

    protected float delayAnimationHit = 0.25f;

    protected Animator animatorCharacter;

    public float delayStatusAttack = 0.5f;

    public bool isAttacking;

    private void Start()
    {
        animatorCharacter=GetComponent<ControllerChacracrer>().animatorChar; 
    }
    public void TakeDamage(int value)
    {
        maxHealt-=value;
        isAttacking = true;
        StartCoroutine(DelayedHit(animatorCharacter));
        EffectManager.instance.SpawmVFX("Effect Hit Mage", transform);
        if (maxHealt <= 0)
        {
            //Destroy(gameObject);
        }
        StartCoroutine(DelayATK());
    }

    IEnumerator DelayedHit(Animator animator)
    {
        
        yield return new WaitForSeconds(delayAnimationHit);

        animator.SetTrigger("Hit");
    }

    IEnumerator DelayATK()
    {
        yield return new WaitForSeconds(delayStatusAttack);

        isAttacking = false;
    }
}
