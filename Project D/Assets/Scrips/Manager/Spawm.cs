using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawm : MonoBehaviour
{
    bool canspawm = true;

    public GameObject obj;

    public Transform pointSpawm;
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(obj, pointSpawm.transform.position,Quaternion.identity);
        }


    }
}
