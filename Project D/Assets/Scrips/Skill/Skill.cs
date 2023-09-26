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
          
            // Tính toán h??ng di chuy?n t? v? trí hi?n t?i c?a ObjectA ??n v? trí hi?n t?i c?a target
            Vector3 direction = (target.position - transform.position).normalized;

            // Tính toán t?c ?? di chuy?n d?a trên th?i gian ?ã trôi qua
            currentMoveSpeed =  accelerationRate * elapsedTime;

            // Di chuy?n ObjectA theo h??ng di chuy?n v?i t?c ?? hi?n t?i
            transform.position += direction * currentMoveSpeed * Time.deltaTime;

            // T?ng th?i gian ?ã trôi qua
            elapsedTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CharacterRanged"))
        {
            collision.gameObject.GetComponent<Health_Ranged>().TakeDamage(damge);  
        }
        else if (collision.gameObject.CompareTag("CharacterMelee"))
        {
            collision.gameObject.GetComponent<Health_Melee>().TakeDamage(damge);  
        }else if (collision.gameObject.CompareTag("Tower"))
        {
            collision.gameObject.GetComponent<Health_Tower>().TakeDamage(damge);
        }
        EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position);
        Destroy(gameObject);
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
