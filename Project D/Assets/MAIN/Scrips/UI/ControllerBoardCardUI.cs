using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBoardCardUI : MonoBehaviour
{
    [SerializeField] protected List<SO_CharacterInforMantion> L_SO_Information_Characters = new List<SO_CharacterInforMantion>();
    [SerializeField] protected List<GameObject> L_Card_Default = new List<GameObject>();
    [SerializeField] Transform T_Content_Scroll;

    private void Start()
    {
        GameObject card = Instantiate(L_Card_Default[0], transform);
        card.transform.parent = T_Content_Scroll;
        GUI_CardBoard Gui_Card = card.GetComponent<GUI_CardBoard>();
        Gui_Card.textName.text = L_SO_Information_Characters[0].name.ToString();
        Gui_Card.G_Prefab_Character = L_SO_Information_Characters[0].Prefab_Character;
    }
}
