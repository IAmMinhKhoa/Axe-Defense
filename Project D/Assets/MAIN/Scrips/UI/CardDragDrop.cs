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
        private const float FlipDuration = 0.25f;
    //protected int SumMana = PlayerPrefs.GetInt("Mana_InGame");
        protected int cost_To_Summon;
    #endregion

    #region Component
        protected GUI_CardBoard Gui_Card;
        protected ControllerBoardCardUI controllerBoardCardUI;
        private Coroutine flipCoroutine;
    #endregion

    #region Variable_Position_Of_Screen
    protected float screenLeft;
        protected float screenRight;
        protected float screenTop;
        protected float screenBottom;
    #endregion

    #region Bool
        protected bool canDrop;
        private bool isFlipped = false;
        private bool isFlipping = false;
    #endregion

    #region GameObject
        public GameObject frontCard; 
        public GameObject endCard; 
    #endregion
    private void Start()
    {
        scrollViewParent = transform.parent;
        scrollViewInitialPosition = scrollViewParent.position;
        Gui_Card = GetComponent<GUI_CardBoard>();
        controllerBoardCardUI = GetComponentInParent<ControllerBoardCardUI>();

        cost_To_Summon = int.Parse(Gui_Card.textCostSummon.text.ToString()) ;

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
        if (CheckPositionCanDrop())
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

    protected bool CheckPositionCanDrop()
    {
        return mousePosition.x < screenLeft || 
            mousePosition.x > screenRight || mousePosition.y < screenBottom || 
            mousePosition.y > screenTop || mousePosition.x > leftHalfScreenLimit ||
            cost_To_Summon > PlayerPrefs.GetInt("Mana_InGame");
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

                //affter summon => sumCost = sumcost - cost_To_Summon => update new sumcost
                int sumCost = PlayerPrefs.GetInt("Mana_InGame");
                PlayerPrefs.SetInt("Mana_InGame", sumCost - cost_To_Summon);

                Destroy(gameObject);
                controllerBoardCardUI.TurnOffBR();
            }
        }
    }

    public void OnMouseDown()
    {
        if (!isFlipping )
        {
            if (isFlipped)
            {
                flipCoroutine = StartCoroutine(FlipCard(endCard, frontCard));
            }
            else
            {
                
                flipCoroutine = StartCoroutine(FlipCard(frontCard, endCard));
            }

            isFlipped = !isFlipped;
        }
    }

    private IEnumerator FlipCard(GameObject fromCard, GameObject toCard)
    {
        isFlipping = true;

        Quaternion startRotation = fromCard.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0f, 180f, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < FlipDuration)
        {
            float t = elapsedTime / FlipDuration;
            fromCard.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        fromCard.SetActive(false);
        fromCard.transform.rotation = startRotation;
        toCard.SetActive(true);

        isFlipping = false;
    }


    protected void GetVaribleScreen()
    {
        screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }
    public void DestroyThisObject()
    {
        controllerBoardCardUI.CreatRandomCard();
        Destroy(this.gameObject);
    }

}
