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
            // Xác ??nh h??ng di chuy?n (ph?i/trái) d?a trên tag
            bool isMovingRight = gameObject.CompareTag("Player");

            movementController.Move(isMovingRight);
            attackController.Attack();
        }
    }
}
