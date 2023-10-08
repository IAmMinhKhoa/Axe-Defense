using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static ObjectPoolManager;

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

    public GameObject SpawmVFX(string nameEffect, Vector3 position, Pooltyle pooltyle)
    {
        GameObject effect = Get(nameEffect);
        //GameObject newEffect = Instantiate(effect, position, Quaternion.identity);
        GameObject newEffect = ObjectPoolManager.SpawnOject(effect, position, Quaternion.identity, pooltyle);
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



  /*  private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject newEffect = ObjectPoolManager.SpawnOject(cc, transform.position, Quaternion.identity, ObjectPoolManager.Pooltyle.Gameobject);
        }
    }*/
}
