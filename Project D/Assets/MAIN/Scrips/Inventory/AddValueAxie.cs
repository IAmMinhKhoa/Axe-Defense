using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Collections.Specialized.BitVector32;

public class AddValueAxie : MonoBehaviour
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

    private void Start()
    {
        imageAxie.GetComponent<Image>().sprite = axieSO.Avatar;
        typeAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.typeCharacter.ToString();
        nameAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.nameChar;
        manaAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.CostSummon.ToString();
        healthAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.HP.ToString();
        acttackAxieText.GetComponent<TextMeshProUGUI>().text = axieSO.Damge.ToString();
    }
}
