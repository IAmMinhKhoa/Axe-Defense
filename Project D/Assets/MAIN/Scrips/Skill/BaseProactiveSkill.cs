using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProactiveSkill : MonoBehaviour
{
    public string targetLayerName = "YourLayerName"; // Tên c?a layer b?n mu?n tìm

    public List<GameObject> objectsWithLayer;
    private void Start()
    {
        objectsWithLayer = new List<GameObject>();

        int targetLayer = LayerMask.NameToLayer(targetLayerName);

        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == targetLayer && obj.tag!="Tower" )
            {
                objectsWithLayer.Add(obj);
            }
        }


        TODOSKILL();
      
    }



    public virtual void TODOSKILL() { }

}
