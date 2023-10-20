using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealt = 100;
    private float CurrentHealth;
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

        CurrentHealth -= value;

        GameObject TextDamge = EffectManager.instance.SpawmVFX("FrefabTextDamge", new Vector3(this.transform.position.x, transform.position.y + 2f, transform.position.z), ObjectPoolManager.Pooltyle.Gameobject);

        TMP_Text textMeshPro = TextDamge.GetComponent<TMP_Text>();

        textMeshPro.text = value.ToString();

        //SOUND WHEN BY HIT
        SoundManager.instance.PlaySound(SoundType.Hit);

        if (CurrentHealth <= 0 && isDie==false)
        {
            EventDie();
            isDie = true;
            textHealth.enabled=false;
            //add mana when enemy die
            if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                ControllerSummon.instance.AddAndSaveMana(2);
            }
            Destroy(gameObject, 1.5f);
        }
        StartCoroutine(DelayATK());

        textHealth.SetText(CurrentHealth.ToString() + "/"+ maxHealt);
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
        CurrentHealth = maxHealt;
        textHealth.SetText(CurrentHealth.ToString() + "/" + maxHealt);
    }
    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }
    public bool GetStatusIsDie()
    {
        return isDie;
    }
}
