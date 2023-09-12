using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollision : MonoBehaviour
{
    public Collider2D[] L_ColliderTouching;
    [SerializeField] protected Transform PointChecking;
    [SerializeField] protected float CheckRanged = 0.5f;
    public LayerMask LayerChecking;


    private void Update()
    {
        L_ColliderTouching = Physics2D.OverlapCircleAll(PointChecking.position, CheckRanged, LayerChecking);
    }


    public bool IsTouchingLayer()
    {
        return L_ColliderTouching.Length != 0;
    }

    private void OnDrawGizmosSelected()
    {
        if (PointChecking == null)
            return;

        Gizmos.DrawWireSphere(PointChecking.position, CheckRanged);
    }


    public Collider2D[] Return_L_CollderTouching()
    {
        return L_ColliderTouching;
    }
}
