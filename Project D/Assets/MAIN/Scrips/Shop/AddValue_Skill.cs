using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddValue_Skill : MonoBehaviour
{
    public SO_Active_Skill skillSO;

    [SerializeField]
    private GameObject imageSkill;
    [SerializeField]
    private GameObject typeSkillText; //có thể sẽ pt sau 
    [SerializeField]
    private GameObject infoSkillText;
    [SerializeField]
    private GameObject manaSkillText;
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
        imageSkill.GetComponent<Image>().sprite = skillSO.Avatar;
        infoSkillText.GetComponent<TextMeshProUGUI>().text = skillSO.InforSkill;
        manaSkillText.GetComponent<TextMeshProUGUI>().text = skillSO.CostSummon.ToString();
        if (!skillSO.ACTIVE)
        {
            coinText.GetComponent<TextMeshProUGUI>().text = skillSO.PriceBuy.ToString();
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
            skillSO.ACTIVE = true;
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
