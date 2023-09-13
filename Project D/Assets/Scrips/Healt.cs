using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    protected int maxHealt = 100;

    protected float delayAnimationHit = 0.25f;

    public float delayStatusAttack = 0.5f;

    public bool isAttacking;
    public void TakeDamage(int value, Animator animator)
    {
        maxHealt-=value;
        isAttacking = true;
        StartCoroutine(DelayedHit(animator));
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
