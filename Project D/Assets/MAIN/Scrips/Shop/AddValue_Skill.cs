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
            buttonBuy.GetComponent<Button>().enabled = false;
            coinImage.SetActive(false);
            coinText.SetActive(false);
            purchasedText.SetActive(true);
        }
    }
}
