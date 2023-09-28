using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTower : MonoBehaviour
{
    protected Transform Target;
    public float moveSpeed = 5f;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TargetPoint")
        {
            EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position);
            Destroy(this.gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.Target = target;
    }
}
