using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public static CameraDrag instance;

    private Vector3 dragOrigin;
    public float dragSpeed = 2f;
    public float leftLimit = -10f; // Gi?i h?n di chuy?n camera sang trái
    public float rightLimit = 10f; // Gi?i h?n di chuy?n camera sang ph?i
    public bool isDrag = true;

    private void Awake()
    {
        instance = this;
    }
    void LateUpdate()
    {
        if (!isDrag)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);

        transform.Translate(move, Space.World);

        // Ki?m tra gi?i h?n di chuy?n
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, leftLimit, rightLimit);
        transform.position = cameraPosition;
    }
}
