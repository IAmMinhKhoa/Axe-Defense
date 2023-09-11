using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    protected int maxHealt = 100;
    public Animator animatorEnemy;
    public void MinusHelat(int value)
    {
        maxHealt-=value;
        Debug.Log("-"+value);
        animatorEnemy.SetTrigger("Hit");
        if (maxHealt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
