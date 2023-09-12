using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionController : MonoBehaviour
{
    public LayerMask enemyLayer;

    private bool isTouchingEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            isTouchingEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            isTouchingEnemy = false;
        }
    }

    public bool IsTouchingEnemy()
    {
        return isTouchingEnemy;
    }
}
