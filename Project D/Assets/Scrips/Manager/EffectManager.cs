using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    static public EffectManager instance;
    public List<GameObject> effects;

    private void Awake()
    {
        EffectManager.instance = this;
        LoadEffects();
    }

    protected void LoadEffects()
    {
        this.effects= new List<GameObject>();
        foreach (Transform child in transform)
        {
            this.effects.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public GameObject SpawmVFX(string nameEffect, Vector3 position)
    {
        GameObject effect = Get(nameEffect);
        GameObject newEffect = Instantiate(effect, position, Quaternion.identity);
        newEffect.gameObject.SetActive(true);
        return newEffect;


    }
    protected GameObject Get(string nameEffect)
    {
        foreach (GameObject child in effects)
        {
            if (child.name == nameEffect) return child;
        }
        return null;
    }



   /* private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Ki?m tra xem ng??i dùng ?ã nh?n nút chu?t trái (0) hay không
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            SpawmVFX("FrefabTextDamge",mousePosition);
        }
    }*/
}
