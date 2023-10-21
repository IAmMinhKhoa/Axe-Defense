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
    private GameObject coinText;


    private void Start()
    {
        imageSkill.GetComponent<Image>().sprite = skillSO.Avatar;
        infoSkillText.GetComponent<TextMeshProUGUI>().text = skillSO.InforSkill;
        manaSkillText.GetComponent<TextMeshProUGUI>().text = skillSO.CostSummon.ToString();
        coinText.GetComponent<TextMeshProUGUI>().text = skillSO.PriceBuy.ToString();
    }
}
