using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private MovementController movementController;
    private AttackController attackController;
    private CollisionController collisionController;

    private void Start()
    {
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
        collisionController = GetComponent<CollisionController>();
    }

    private void Update()
    {
        bool isMoving = !collisionController.IsTouchingEnemy();
        if (isMoving)
        {
            // X�c ??nh h??ng di chuy?n (ph?i/tr�i) d?a tr�n tag
            bool isMovingRight = gameObject.CompareTag("Player");

            movementController.Move(isMovingRight);
            attackController.Attack();
        }
    }
}
