using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControllerBoardCardUI : MonoBehaviour
{
    [SerializeField] protected List<SO_CharacterInforMantion> L_SO_Information_Characters = new List<SO_CharacterInforMantion>();
    [SerializeField] protected List<InforCard> L_Card_Default = new List<InforCard>();
   

    private void Start()
    {
        /* GameObject card = Instantiate(L_Card_Default[0], transform);
         card.transform.parent = T_Content_Scroll;
         GUI_CardBoard Gui_Card = card.GetComponent<GUI_CardBoard>();
         Gui_Card.textName.text = L_SO_Information_Characters[0].name.ToString();
         Gui_Card.G_Prefab_Character = L_SO_Information_Characters[0].Prefab_Character;*/
        LoadCard();
    }

    protected void LoadCard()
    {
        System.Random random = new System.Random();
        
        for (int i = 0; i < 3; i++)
        {
            int Random_Char_Card = random.Next(0, 3);
            // if (L_SO_Information_Characters[Random_Char_Card].typeCharacter)
            AddDataToCard(L_SO_Information_Characters[Random_Char_Card]);
            Debug.Log(L_SO_Information_Characters[Random_Char_Card].name);
        }
    }

    protected void AddDataToCard(SO_CharacterInforMantion SO_Infor)
    {
        foreach (InforCard inforCard in L_Card_Default)
        {
            Debug.Log(inforCard.name_Type +" " + SO_Infor.typeCharacter.ToString());
            if (inforCard.name_Type == SO_Infor.typeCharacter.ToString())
            {
                Debug.Log("chuan :" + inforCard.name_Type);
                GameObject card = Instantiate(inforCard.card, transform);
                card.transform.parent = this.transform;
                GUI_CardBoard Gui_Card = card.GetComponent<GUI_CardBoard>();

                Gui_Card.textName.text = SO_Infor.name.ToString();
                Gui_Card.G_Prefab_Character = SO_Infor.Prefab_Character;
            }
            else
            {
                Debug.Log("deo");
            }
        }
    }
}

[System.Serializable]
public class InforCard
{
    public string name_Type;
    public GameObject card;
}