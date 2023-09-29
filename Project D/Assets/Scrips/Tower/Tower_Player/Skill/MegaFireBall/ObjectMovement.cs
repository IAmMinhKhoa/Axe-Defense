using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
 
    protected bool CanMoveOject = true;
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
        if (isDragging&&CanMoveOject)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Vector3 newPosition = mousePos + offset;
            transform.position = newPosition;
            
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void SetCanMoveObject(bool temp)
    {
        this.CanMoveOject = temp;
    }
}
