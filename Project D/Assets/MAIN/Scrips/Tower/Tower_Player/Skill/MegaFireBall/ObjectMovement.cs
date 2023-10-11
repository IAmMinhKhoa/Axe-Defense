using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private bool isDragging = false;
 
    protected bool CanMoveOject = true;

    protected float screenLeft;
    protected float screenRight;
    protected float screenTop;
    protected float screenBottom;

    private Vector3 lastPosition;
    private void OnMouseDown()
    {
        isDragging = true;
      
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
    private void Start()
    {
        screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }
    private void Update()
    {
        if (isDragging && CanMoveOject)
        {

            Vector3 mousePosition = GetMouseWorldPosition();

            Vector3 newPosition = mousePosition;

            if (mousePosition.x < screenLeft || mousePosition.x > screenRight || mousePosition.y < screenBottom || mousePosition.y > screenTop) //out screen
            {
                transform.position = lastPosition;
                Debug.Log("out");
            }
            else
            {
               
                transform.position = newPosition;
                lastPosition = newPosition;
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }
    public void SetCanMoveObject(bool temp)
    {
        this.CanMoveOject = temp;
    }
}
