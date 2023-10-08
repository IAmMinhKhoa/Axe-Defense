using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnParticalToPool : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        ObjectPoolManager.ReturnOjectToPool(this.gameObject);
    }
}
