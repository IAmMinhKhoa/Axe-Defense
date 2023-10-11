using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Variable
        private Vector3 initialPosition;
        private Transform parentToReturnTo;
        private Vector3 scrollViewInitialPosition;
        private Transform scrollViewParent;
    
        protected Vector3 mousePosition; //position of mouse
        public float leftHalfScreenLimit = -1f; //limit can drop object 
    #endregion

    #region Component
        protected GUI_CardBoard Gui_Card;
        protected ControllerBoardCardUI controllerBoardCardUI;
    #endregion

    #region Variable_Position_Of_Screen
        protected float screenLeft;
        protected float screenRight;
        protected float screenTop;
        protected float screenBottom;
    #endregion

    #region Bool
        protected bool canDrop;
    #endregion

    private void Start()
    {
        scrollViewParent = transform.parent;
        scrollViewInitialPosition = scrollViewParent.position;
        Gui_Card = GetComponent<GUI_CardBoard>();
        controllerBoardCardUI = GetComponentInParent<ControllerBoardCardUI>();    

        GetVaribleScreen();



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

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        if (mousePosition.x < screenLeft || mousePosition.x > screenRight || mousePosition.y < screenBottom || mousePosition.y > screenTop || mousePosition.x >leftHalfScreenLimit)
        {
            canDrop = false;
            controllerBoardCardUI.BrNotCanDrop.SetActive(true);
            controllerBoardCardUI.BrCanDrop.SetActive(false);
        }
        else
        {
            canDrop = true;
            controllerBoardCardUI.BrCanDrop.SetActive(true);
            controllerBoardCardUI.BrNotCanDrop.SetActive(false);
        }

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == parentToReturnTo)
        {
            transform.position = initialPosition;
        }
        else
        {
            
              
            if (canDrop==false)
            {
                //out area screen
                transform.SetParent(scrollViewParent);
                transform.position = scrollViewInitialPosition;
                controllerBoardCardUI.TurnOffBR();
            }   
            else
            {
                 
                //Instantiate(prefab_Character_Of_Card, mousePosition, Quaternion.identity);
                Gui_Card.SetEvent_SummonPrefab(mousePosition);
                controllerBoardCardUI.SetEventSummon();
                Destroy(gameObject);
                controllerBoardCardUI.TurnOffBR();

            }
            
        }
    }


    protected void GetVaribleScreen()
    {
        screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }


}
