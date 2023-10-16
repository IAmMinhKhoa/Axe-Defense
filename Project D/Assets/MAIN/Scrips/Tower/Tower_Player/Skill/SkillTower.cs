using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTower : MonoBehaviour
{
    protected Transform Target;
    [SerializeField] ControllerCollision CT_Collision;
    public float moveSpeed = 5f;
    [SerializeField] int Damgage;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, moveSpeed * Time.deltaTime);
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TargetPoint")
        {
            Health healthEnemy = null;
            foreach (Collider2D enemy in CT_Collision.Return_L_CollderTouching())
            {
                if (enemy.gameObject.tag == "CharacterMage" || enemy.gameObject.tag == "CharacterArcher")
                {
                    Health_Ranged healthRanged = enemy.GetComponent<Health_Ranged>();
                    if (healthRanged != null)
                    {
                        healthEnemy = healthRanged;
                        healthEnemy.TakeDamage(Damgage);
                    }
                }
                else if (enemy.gameObject.tag == "CharacterMelee")
                {
                    Health_Melee healthMelee = enemy.GetComponent<Health_Melee>();
                    if (healthMelee != null)
                    {
                        healthEnemy = healthMelee;
                        healthEnemy.TakeDamage(Damgage);
                    }
                }
            }
            EffectManager.instance.SpawmVFX("Effect Hit Mage", this.transform.position, ObjectPoolManager.Pooltyle.ParticleSystem);

            //SOUND IMPAC SKILL OF TOWER

            SoundManager.instance.PlaySound(SoundType.Impac_Skill_Tower);

            Destroy(this.gameObject);
            
        }
    }
    public void SetTarget(Transform target)
    {
        this.Target = target;
    }
}
