using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    protected int maxHealt = 100;
    public Animator animatorEnemy;
    public float delay = 0.25f;
    public void TakeDamage(int value)
    {
        maxHealt-=value;
        Debug.Log("-"+value);
        StartCoroutine(DelayedHit());
        if (maxHealt <= 0)
        {
            //Destroy(gameObject);
        }
    }

    IEnumerator DelayedHit()
    {
        
        yield return new WaitForSeconds(delay);

        animatorEnemy.SetTrigger("Hit");
    }
}
