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
    [SerializeField]
    private Sprite purchasedSprite;

    private int coinCurrent;
    private int coinCard;
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
            setButtonPurchased();
        }

        buttonBuy.GetComponent<Button>().onClick.AddListener(SetCoin);
    }

    private void SetCoin()
    {
        coinCurrent = SYSTEM_GAME.Instance.GetCoin();
        coinCard = int.Parse(coinText.GetComponent<TextMeshProUGUI>().text);
        coinCurrent -= coinCard;
        if (coinCurrent > 0)
        {
            axieRANGERSO.ACTIVE = true;
            CoinUI.instance.SetCoinUI(coinCurrent);
            setButtonPurchased();
        }
    }

    private void setButtonPurchased()
    {
        buttonBuy.GetComponent<Button>().enabled = false;
        buttonBuy.GetComponent<Image>().sprite = purchasedSprite;
        coinImage.SetActive(false);
        coinText.SetActive(false);
        purchasedText.SetActive(true);
    }
}
