using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class ControllerShader : MonoBehaviour
{
   
    public Material _material;
    public MeshRenderer render ;
    protected Material clonedMaterial;
    private void Awake()
    {
        clonedMaterial = Instantiate(_material);
        render.material = clonedMaterial;
    }
  
    public  void SetShader(string NameVariable,float elapsedTime,float timeMax)
    {
        if (_material != null)
        {
            _material = render.material;
            float valueDis = Mathf.Clamp01(elapsedTime / timeMax);
            _material.SetFloat(NameVariable, valueDis);
        }
        else
        {
            Debug.LogWarning("Null Material Of Character");
        }
        
    }
}
