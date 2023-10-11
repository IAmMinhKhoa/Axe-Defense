using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.FlowStateWidget;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealt = 100;
    private float DefaultHealth;
    protected bool isAttacking;
    protected float delayStatusAttack = .5f;
    protected bool isDie = false;
    [SerializeField] TextMeshProUGUI textHealth;
    public virtual void TakeDamage(float value)
    {
        if (isDie!=true)//if character not die
        {
            EventHit();
        }
        

        isAttacking = true;

        maxHealt -= value;

        GameObject TextDamge = EffectManager.instance.SpawmVFX("FrefabTextDamge", new Vector3(this.transform.position.x, transform.position.y + 2f, transform.position.z), ObjectPoolManager.Pooltyle.Gameobject);

        TMP_Text textMeshPro = TextDamge.GetComponent<TMP_Text>();

        textMeshPro.text = value.ToString();

        if (maxHealt <= 0 && isDie==false)
        {
            EventDie();
            isDie = true;
            textHealth.enabled=false;   
            Destroy(gameObject, 1.5f);
        }
        StartCoroutine(DelayATK());

        textHealth.SetText(maxHealt.ToString() + "/"+ DefaultHealth);
    }

    protected virtual void EventDie() { }
    protected virtual void EventHit() { }
    
    IEnumerator DelayATK()
    {
        yield return new WaitForSeconds(delayStatusAttack);

        isAttacking = false;
    }
    public bool GetIsAttacking()
    {
        return isAttacking;
    }
    public void SetHealth(float value)
    {
        this.maxHealt = value;
        DefaultHealth = maxHealt;
        textHealth.SetText(maxHealt.ToString() + "/" + DefaultHealth);
    }
}
