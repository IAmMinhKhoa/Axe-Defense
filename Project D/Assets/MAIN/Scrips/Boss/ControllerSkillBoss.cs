using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSkillBoss : MonoBehaviour
{
    public float fillTime = 5f; // Th?i gian ?? fill ??y (giây)
    public Image fillImage; // Reference t?i component Image c?a image b?n ?ang s? d?ng
    public GameObject PrefabSkill; // Prefab c?a Skill

    private void Start()
    {
        StartCoroutine(CountdownAndFill());
    }

    private IEnumerator CountdownAndFill()
    {
        while (true)
        {
            float timer = 0f;

            while (timer < fillTime)
            {
                timer += Time.deltaTime; // Tính toán th?i gian ?ã trôi qua
                float fillAmount = timer / fillTime; // Tính fill amount d?a trên th?i gian trôi qua và th?i gian c?n ?? fill ??y
                fillImage.fillAmount = fillAmount; // Gán fill amount vào image

                yield return null; // Ch? m?t frame ti?p theo
            }

            fillImage.fillAmount = 0f; // ??t fill amount v? 0

            // T?o Skill ho?c th?c hi?n hành ??ng sau khi fill ??y
            InstantiateSkill();

            yield return null; // Ch? m?t frame ti?p theo
        }
    }

    private void InstantiateSkill()
    {
        GameObject F_Skill = Instantiate(PrefabSkill);
        F_Skill.GetComponent<BaseProactiveSkill>().targetLayerName = "Player";
    }



}
