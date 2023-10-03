using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class ControllerShader : MonoBehaviour
{
   
    protected Material orginalMaterial;
    protected Material cloneMaterial;
    public SkeletonRenderer skeletonRenderer;
    protected Material clonedMaterial;
    private void Awake()
    {
        if (orginalMaterial == null)
        {
            orginalMaterial = skeletonRenderer.skeletonDataAsset.atlasAssets[0].PrimaryMaterial;
            cloneMaterial=Instantiate(orginalMaterial);
            skeletonRenderer.CustomMaterialOverride[orginalMaterial] = cloneMaterial;
        }

    }
  
    public  void SetShader(string NameVariable,float elapsedTime,float timeMax)
    {
        if (cloneMaterial != null)
        {
            
            float valueDis = Mathf.Clamp01(elapsedTime / timeMax);
            cloneMaterial.SetFloat(NameVariable, valueDis);
        }
        else
        {
            Debug.LogWarning("Null Material Of Character");
        }
        
    }
}
