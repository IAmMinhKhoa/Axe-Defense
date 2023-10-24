using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCardToDeck : MonoBehaviour
{
    public Transform contentPickCard;
    public Transform contentInventory;
    public SO_DeskCard SO_DeckCard;

    

    private void Start()
    {
        add = GetComponent<AddValueAxie>();
    }
    public virtual void cc()
    {
        //SO_DeckCard.ListCardAxie.Add(add.axieSO);
        Debug.Log("fefwegwr");  
    }
}
