using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition;
    private Transform parentToReturnTo;
    private Vector3 scrollViewInitialPosition;
    private Transform scrollViewParent;



    protected GUI_CardBoard Gui_Card;
   // public GameObject prefab_Character_Of_Card;
    //public float leftHalfScreenLimit = -4.8f;
    private void Start()
    {
        scrollViewParent = transform.parent;
        scrollViewInitialPosition = scrollViewParent.position;
        Gui_Card = GetComponent<GUI_CardBoard>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
        parentToReturnTo = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == parentToReturnTo)
        {
            transform.position = initialPosition;
        }
        else
        {
            if (transform.position.x >= scrollViewInitialPosition.x && transform.position.x <= scrollViewInitialPosition.x + scrollViewParent.GetComponent<RectTransform>().rect.width &&
                transform.position.y >= scrollViewInitialPosition.y && transform.position.y <= scrollViewInitialPosition.y + scrollViewParent.GetComponent<RectTransform>().rect.height)
            {
                transform.SetParent(scrollViewParent);
                transform.position = scrollViewInitialPosition;
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                if (mousePosition.x < 0)
                {

                    //Instantiate(prefab_Character_Of_Card, mousePosition, Quaternion.identity);
                    Gui_Card.SetEvent_SummonPrefab(mousePosition);
                    Destroy(gameObject);
                }
                else
                {
                    transform.SetParent(scrollViewParent);
                    transform.position = scrollViewInitialPosition;
                }
            }
        }
    }
}
