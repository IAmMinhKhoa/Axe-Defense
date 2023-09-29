using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Transform target;
    public float MaxSpeed = 5f;
    public float accelerationRate = 1f;
 


    protected int damge;

    private float currentMoveSpeed;
    private float elapsedTime;

    private void Start()
    {
        currentMoveSpeed = 0;
        elapsedTime = 0f;


    }

    private void Update()
    {
        if (target != null)
        {


            Vector3 direction = (target.position - transform.position).normalized;
                 currentMoveSpeed = accelerationRate * elapsedTime;

            transform.position += direction * currentMoveSpeed * Time.deltaTime;

            float distanceThreshold = 0.1f; // Ng??ng kho?ng cách ?? xem ?ã ch?m ??n hay ch?a

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= distanceThreshold)
            {
                MadeDamage();
            }
            elapsedTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    protected void MadeDamage()
    {
        if (target.gameObject.CompareTag("CharacterRanged"))
        {
            target.gameObject.GetComponent<Health_Ranged>().TakeDamage(damge);
            EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position);
            Destroy(gameObject);
        }
        else if (target.gameObject.CompareTag("CharacterMelee"))
        {
            target.gameObject.GetComponent<Health_Melee>().TakeDamage(damge);
            EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position);
            Destroy(gameObject);
        }
        else if (target.gameObject.CompareTag("Tower"))
        {
            target.gameObject.GetComponent<Health_Tower>().TakeDamage(damge);
            EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position);
            Destroy(gameObject);
        }
    }

   
    public void SetDamgeSKill(int value)
    {
        damge = value;
    }
    public void SetTargetForSkill(Transform target)
    {
        this.target = target;
    }
}
