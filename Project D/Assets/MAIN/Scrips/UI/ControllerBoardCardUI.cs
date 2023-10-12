using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControllerBoardCardUI : MonoBehaviour
{
    [SerializeField] protected List<SO_CharacterInforMantion> L_SO_Information_Characters = new List<SO_CharacterInforMantion>();
    [SerializeField] protected List<InforCard> L_Card_Default = new List<InforCard>();
    public GameObject BrCanDrop;
    public GameObject BrNotCanDrop;

    


    private void Start()
    {
        TurnOffBR();
        LoadCard();
       
    }


    protected void LoadCard()
    { 
        for (int i = 0; i < 4; i++)
        {
            CreatRandomCard();
        }
    }

    public void CreatRandomCard()
    {
        System.Random random = new System.Random();
        int Random_Char_Card = random.Next(0, 3);
        GameObject card = AddDataToCard(L_SO_Information_Characters[Random_Char_Card]);
        card.transform.SetParent(this.transform, false);
    }

    protected GameObject AddDataToCard(SO_CharacterInforMantion SO_Infor)
    {
        foreach (InforCard inforCard in L_Card_Default)
        {
            if (inforCard.name_Type == SO_Infor.typeCharacter.ToString())
            {
               
                GameObject card = Instantiate(inforCard.card, transform);
                
                GUI_CardBoard Gui_Card = card.GetComponent<GUI_CardBoard>();

                Gui_Card.textName.text = SO_Infor.name.ToString();
                Gui_Card.G_Prefab_Character = SO_Infor.Prefab_Character;

                return card;
            }
        }
        return null;
    }

  
    public void TurnOffBR()
    {
        BrCanDrop.SetActive(false);
        BrNotCanDrop.SetActive(false);
    }
    public void SetEventSummon()
    {
        CreatRandomCard();
    }


}

[System.Serializable]
public class InforCard
{
    public string name_Type;
    public GameObject card;
}