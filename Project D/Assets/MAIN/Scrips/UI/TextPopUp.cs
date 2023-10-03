using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public float popUpDuration = 2f;
    public float popUpSpeed = 1f;
    public float fadeSpeed = 1f;
   

    private float timer = 0f;
    private float initialFontSize;
    private TextMeshPro textMeshPro;


    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        initialFontSize = textMeshPro.fontSize;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= popUpDuration)
        {
            // Bay lên và t?ng kích th??c
           
            float scale = Mathf.Lerp(0f, 1f, timer * popUpSpeed);
            textMeshPro.fontSize = initialFontSize * scale;
            transform.position = new Vector3(transform.position.x, transform.position.y+0.001f, 0f);

            // M? d?n
            float alpha = Mathf.Lerp(0f, 1f, timer * fadeSpeed);
            textMeshPro.alpha = alpha;
        }
        else
        {
            // M?t ?i
            float alpha = Mathf.Lerp(1f, 0f, (timer - popUpDuration) * fadeSpeed);
            textMeshPro.alpha = alpha;

            if (alpha <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
