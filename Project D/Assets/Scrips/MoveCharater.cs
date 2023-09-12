using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCharater : MonoBehaviour
{

    public float speed = 5f; 

    private Rigidbody2D rb;

    public Animator animatorChar;

    protected bool isMoving = true;


    protected bool canAtk = false;
    protected float timer = 2f;
    protected float timeDefault = 0;

    protected bool isTouchingEnemy = false;


    protected Collider2D[] hitEnemies;


    public Transform attackPoint;
    public float atkRanged = 0.5f;
    public LayerMask enemyLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        timeDefault = timer;

        
    }


    private void Update()
    {

        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, atkRanged, enemyLayer);

        if (hitEnemies.Length != 0)
        {
            isMoving = false;
            isTouchingEnemy = true;
        }
        else
        {
            isMoving = true;
            isTouchingEnemy = false;
        }

        if (isMoving)
        {
            if (gameObject.tag == "Player")
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }else 
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            
            animatorChar.SetBool("Run", true);
        }

        if (canAtk == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canAtk = true;
            }
        }

        if (canAtk && isTouchingEnemy)
        {
            Attack();

        }
        
    }


    private void Attack()
    {
        if (canAtk)
        {
            canAtk = false;
           
            timer = timeDefault;
            animatorChar.SetTrigger("Attack");
            animatorChar.SetBool("Run", false);

            hitEnemies[0].GetComponent<Healt>().TakeDamage(20);
            foreach (Collider2D cc in hitEnemies)
            {
                Debug.Log(cc.name);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, atkRanged);
      
    }

}
