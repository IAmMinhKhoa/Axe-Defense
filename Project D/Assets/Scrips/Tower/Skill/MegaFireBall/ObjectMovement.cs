using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public Collider2D forbiddenAreaCollider;
    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Vector3 newPosition = mousePos + offset;
            // Ki?m tra va ch?m v?i Collider c?a khu v?c không ???c phép
            if (!forbiddenAreaCollider.bounds.Contains(newPosition))
            {
                transform.position = newPosition;
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
