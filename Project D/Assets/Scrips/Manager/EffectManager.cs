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

    public void SpawmVFX(string nameEffect,Transform position)
    {
        GameObject effect = Get(nameEffect);
        GameObject newEffect = Instantiate(effect, position);
        newEffect.gameObject.SetActive(true);
    
    }
    protected GameObject Get(string nameEffect)
    {
        foreach (GameObject child in effects)
        {
            if (child.name == nameEffect) return child;
        }
        return null;
    }
}
