using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCharater : MonoBehaviour
{
    const string RUN = "action/run";
    const string IDLE = "action/idle/normal";
    const string ATK = "attack/melee/horn-gore";


    public float speed = 5f; 

    private Rigidbody2D rb;

    public Animator animatorChar;

    protected bool isMoving = true;


    protected bool canAtk = false;
    protected float timer = 2f;
    protected float timeDefault = 0;

    protected bool isTouchingEnemy = false;

 



    public Transform attackPoint;
    public float atkRanged = 0.5f;
    public LayerMask enemyLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        timeDefault = timer;

        
    }

    private void MoveCharater_E_ATK(object sender, EventArgs e)
    {
        Attack();
    }

    private void Update()
    {
       


        if (isMoving)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
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

        if (canAtk&&isTouchingEnemy)
        {
            Attack();
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("cc");
            animatorChar.SetTrigger("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&&collision.gameObject != null)
        {
            isMoving = false;
            isTouchingEnemy = true;
            Debug.Log("cham ke dich");
           
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        isMoving = true;
        isTouchingEnemy = false;    
    }

    private void Attack()
    {
        if (canAtk)
        {
            canAtk = false;
           
            timer = timeDefault;
            animatorChar.SetTrigger("Attack");
            animatorChar.SetBool("Run", false);
            

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, atkRanged, enemyLayer);

            /*foreach (Collider2D enemy in hitEnemies)
            {
                
                // Destroy(enemy.gameObject);
                enemy.GetComponent<Healt>().MinusHelat(20);
                
            }*/
            hitEnemies[0].GetComponent<Healt>().MinusHelat(20);
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
