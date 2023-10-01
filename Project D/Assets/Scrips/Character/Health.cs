using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.FlowStateWidget;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealt = 100;
    private int DefaultHealth;
    protected bool isAttacking;
    protected float delayStatusAttack = .5f;
    [SerializeField] TextMeshProUGUI textHealth;
    public virtual void TakeDamage(int value)
    {
        EventHit();

        isAttacking = true;

        maxHealt -= value;

        GameObject TextDamge = EffectManager.instance.SpawmVFX("FrefabTextDamge", new Vector3(this.transform.position.x, transform.position.y + 2f, transform.position.z));

        TMP_Text textMeshPro = TextDamge.GetComponent<TMP_Text>();

        textMeshPro.text = value.ToString();

        if (maxHealt <= 0)
        {
            EventDie();
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
    public void SetHealth(int value)
    {
        this.maxHealt = value;
        DefaultHealth = maxHealt;
        textHealth.SetText(maxHealt.ToString() + "/" + DefaultHealth);
    }
}
