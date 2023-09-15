using System.Collections;
using System.Collections.Generic;
using Spine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.Rendering.DebugUI;

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

    public void TakeDamage(int value,string nameEffectExplosion)
    {
        
        isAttacking = true;
        

        maxHealt -= value;
        animatorCharacter.SetTrigger("Hit"); 

        EffectManager.instance.SpawmVFX(nameEffectExplosion, this.transform);
        if (maxHealt <= 0)
        {
            //Destroy(gameObject);
        }
        StartCoroutine(DelayATK());
    }
    


    IEnumerator DelayATK()
    {
        yield return new WaitForSeconds(delayStatusAttack);

        isAttacking = false;
    }
}
