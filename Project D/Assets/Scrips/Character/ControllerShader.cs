using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class ControllerShader : MonoBehaviour
{
   
    public Material _material;


    public  void SetShader(string NameVariable,float elapsedTime,float timeMax)
    {
        if (_material != null)
        {
            float valueDis = Mathf.Clamp01(elapsedTime / timeMax);
            _material.SetFloat(NameVariable, valueDis);
        }
        else
        {
            Debug.LogWarning("Null Material Of Character");
        }
        
    }
}
