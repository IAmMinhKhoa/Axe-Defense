using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddValue_ArcherOrMelee : MonoBehaviour
{
    public SO_CharacterInforMantionRANGER axieRANGERSO;

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
        imageAxie.GetComponent<Image>().sprite = axieRANGERSO.Avatar;
        typeAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.typeCharacter.ToString();
        nameAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.nameChar;
        manaAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.CostSummon.ToString();
        healthAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.HP.ToString();
        acttackAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.Damge.ToString();
        coinText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.PriceBuy.ToString();
    }
}
