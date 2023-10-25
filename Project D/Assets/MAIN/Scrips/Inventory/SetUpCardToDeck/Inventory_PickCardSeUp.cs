using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_PickCardSeUp : MonoBehaviour
{
    [SerializeField] protected SO_DeskCard SO_CardOnDeck;
    [SerializeField] protected List<InforCard> L_Card_Default = new List<InforCard>();


    private void OnEnable()
    {
        
    }

    protected void InItCardFromDeck()
    {

    }

}


[System.Serializable]
public class InforCardOriginal
{
    public string name_Type;
    public GameObject card;
}
