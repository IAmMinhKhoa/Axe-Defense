using System.Collections;
using System.Collections.Generic;
using Spine;
using TMPro;
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

    protected ControllerChacracrer controllerChacracrer;
    private void Start()
    {
        controllerChacracrer=GetComponent<ControllerChacracrer>();
        animatorCharacter = controllerChacracrer.animatorChar; 
    }

    public void TakeDamage(int value, ControllerChacracrer.TypeCharacter typeChar)
    {
        
        isAttacking = true;
        
        maxHealt -= value;

        animatorCharacter.SetTrigger("Hit");

        GameObject TextDamge= EffectManager.instance.SpawmVFX("FrefabTextDamge",new Vector3(this.transform.position.x,transform.position.y+2f,transform.position.z));


        TMP_Text textMeshPro = TextDamge.GetComponent<TMP_Text>();

        textMeshPro.text = value.ToString();

        if(typeChar== ControllerChacracrer.TypeCharacter.Mage){
            EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position);
        }
        else
        {
            EffectManager.instance.SpawmVFX("Effect Hit Melee", this.transform.position);
        }
        

        if (maxHealt <= 0)
        {
            animatorCharacter.SetTrigger("Die");

            controllerChacracrer.OnCharacterDie();

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

       public void SetHealth(int value)
    {
        this.maxHealt = value;
    }
}
