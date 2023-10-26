using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CoinUI : MonoBehaviour
{
    public static CoinUI instance;
    [SerializeField]
    private GameObject coinText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        //CHỈ ĐỂ TEST THÔI 
        //SYSTEM_GAME.Instance.SetCoin(999999); //TEST CAI CC

        coinText.GetComponent<TextMeshProUGUI>().text = SYSTEM_GAME.Instance.GetCoin().ToString();    
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinUI(int value)
    {
        SYSTEM_GAME.Instance.SetCoin(value);
        coinText.GetComponent<TextMeshProUGUI>().text = SYSTEM_GAME.Instance.GetCoin().ToString();
    }
}
