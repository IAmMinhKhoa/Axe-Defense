using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Transform target;
    protected int damage;

    protected string typeChar;


    public float MaxSpeed = 5f;
    public float accelerationRate = 1f;
 
    private float currentMoveSpeed;

    private void OnEnable()
    {
        currentMoveSpeed = 0f;
    }

   

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            currentMoveSpeed += accelerationRate * Time.deltaTime;
           
            transform.position += direction * currentMoveSpeed * Time.deltaTime;

            float distanceThreshold = 0.1f; // Ng??ng kho?ng cách ?? xem ?ã ch?m ??n hay ch?a

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= distanceThreshold)
            {
                MadeDamage();
            }


        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected void MadeDamage()
    {
        Health healthComponent=null;
        string enemyTag = target.gameObject.gameObject.tag;

        if (enemyTag == "CharacterMage")
        {
            healthComponent = target.gameObject.GetComponent<Health_Ranged>();
        }
        else if (enemyTag == "CharacterArcher")
        {
            healthComponent = target.gameObject.GetComponent<Health_Ranged>();
        }
        else if (enemyTag == "CharacterMelee")
        {
            healthComponent = target.gameObject.GetComponent<Health_Melee>();
        }
        else if (enemyTag == "Tower")
        {
            healthComponent = target.gameObject.GetComponent<Health_Tower>();
        }
        if (healthComponent != null)
        {
            
            float coefficient = DEFAULT_VALUE.GetAttackCoefficient(typeChar,enemyTag);
            //Debug.Log(damage+"/"+coefficient);
            healthComponent.TakeDamage(Mathf.Round(damage * coefficient));
            EffectManager.instance.SpawmVFX("Effect Hit Mage", transform.position, ObjectPoolManager.Pooltyle.ParticleSystem);
            //Destroy(gameObject);
            ObjectPoolManager.ReturnOjectToPool(this.gameObject);

        }
    }


    public void SetDamgeSKill(int value)
    {
        damage = value;
    }
    public void SetTargetForSkill(Transform target)
    {
        this.target = target;
    }
    public  void SetTagOwnSkill(string myTag)
    {
        typeChar = myTag;
    }
}
