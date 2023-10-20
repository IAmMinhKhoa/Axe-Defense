using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSkillBoss : MonoBehaviour
{
    public float fillTime = 5f; // Th?i gian ?? fill ??y (gi�y)
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
                timer += Time.deltaTime; // T�nh to�n th?i gian ?� tr�i qua
                float fillAmount = timer / fillTime; // T�nh fill amount d?a tr�n th?i gian tr�i qua v� th?i gian c?n ?? fill ??y
                fillImage.fillAmount = fillAmount; // G�n fill amount v�o image

                yield return null; // Ch? m?t frame ti?p theo
            }

            fillImage.fillAmount = 0f; // ??t fill amount v? 0

            // T?o Skill ho?c th?c hi?n h�nh ??ng sau khi fill ??y
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
