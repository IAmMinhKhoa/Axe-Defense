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
    private GameObject buttonBuy;
    [SerializeField]
    private GameObject coinImage;
    [SerializeField]
    private GameObject coinText;
    [SerializeField]
    private GameObject purchasedText;


    private void Start()
    {
        imageAxie.GetComponent<Image>().sprite = axieRANGERSO.Avatar;
        typeAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.typeCharacter.ToString();
        nameAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.nameChar;
        manaAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.CostSummon.ToString();
        healthAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.HP.ToString();
        acttackAxieText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.Damge.ToString();
        if (!axieRANGERSO.ACTIVE)
        {
            coinText.GetComponent<TextMeshProUGUI>().text = axieRANGERSO.PriceBuy.ToString();
        }
        else
        {
            buttonBuy.GetComponent<Button>().enabled = false;
            coinImage.SetActive(false);
            coinText.SetActive(false);
            purchasedText.SetActive(true);
        }
    }
}
