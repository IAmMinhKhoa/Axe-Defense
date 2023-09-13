using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Transform target;
    public float MaxSpeed = 5f;
    public float accelerationRate = 1f;

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
          
            // T�nh to�n h??ng di chuy?n t? v? tr� hi?n t?i c?a ObjectA ??n v? tr� hi?n t?i c?a target
            Vector3 direction = (target.position - transform.position).normalized;

            // T�nh to�n t?c ?? di chuy?n d?a tr�n th?i gian ?� tr�i qua
            currentMoveSpeed =  accelerationRate * elapsedTime;

            // Di chuy?n ObjectA theo h??ng di chuy?n v?i t?c ?? hi?n t?i
            transform.position += direction * currentMoveSpeed * Time.deltaTime;

            // T?ng th?i gian ?� tr�i qua
            elapsedTime += Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("ccc");   
            Destroy(gameObject);
        }
    }
}
