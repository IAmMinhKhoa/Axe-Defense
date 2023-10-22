using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuyCard : MonoBehaviour
{
    private Button buttonBuy;
    [SerializeField]
    private Sprite buttonPurchasedImage;
    [SerializeField]
    private GameObject PurchasedText;
    [SerializeField]
    private GameObject CoinText; 
    [SerializeField]
    private GameObject CoinImage;

    private SO_CharacterInforMantion inforMantion;

    private int coinCurrent;
    private int coinCard;
    // Start is called before the first frame update
    void Start()
    {
        buttonBuy = GetComponent<Button>();

        if (buttonBuy != null)
        {
            // Đăng ký phương thức xử lý sự kiện khi nhấn vào button
            buttonBuy.onClick.AddListener(SetCoin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCoin()
    {
        coinCurrent = SYSTEM_GAME.Instance.GetCoin();
        coinCard = int.Parse(CoinText.GetComponent<TextMeshProUGUI>().text);
        coinCurrent -= coinCard;
        if(coinCurrent > 0)
        {
            CoinUI.instance.SetCoinUI(coinCurrent);
            buttonBuy.enabled = false;
            gameObject.GetComponent<Image>().sprite = buttonPurchasedImage;
            CoinText.SetActive(false);
            CoinImage.SetActive(false);
            PurchasedText.SetActive(true);

        }
    }
}
