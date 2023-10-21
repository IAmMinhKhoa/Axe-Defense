using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddValue_Melee : MonoBehaviour
{
    public SO_CharacterInforMantion axieSO;

    [SerializeField]
    private GameObject imageAxie;
    [SerializeField]
    private GameObject typeAxieText;
    [SerializeField]
    private GameObject nameAxieText;
    [SerializeField]
    private GameObject manaAxieText;
    [SerializeField]
    private GameObject healthAxieText;
    [SerializeField]
    private GameObject acttackAxieText;
    [SerializeField]
    private GameObject coinText;


    private void Start()
    {
        imageAxie.GetComponent<Image>().sprite = axieSO.Avatar;
        typeAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.typeCharacter.ToString();
        nameAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.nameChar;
        manaAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.CostSummon.ToString();
        healthAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.HP.ToString();
        acttackAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.Damge.ToString();
        coinText.GetComponent<TextMeshProUGUI>().text = axieSO.PriceBuy.ToString();
    }

}
