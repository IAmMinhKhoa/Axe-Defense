using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTower : MonoBehaviour
{
    #region GameObject
    [SerializeField] protected Button Btn_Skill;
    [SerializeField] protected Image Img_LoadSkill;
    [SerializeField] protected GameObject Obj_Skill;
    #endregion

    #region Variable
    [SerializeField] protected float CDSkillTower;
    protected float CDSkillTimer;
    protected bool canSkill=true;
    #endregion

    #region Event
    public event EventHandler E_TowerDie;
    public event EventHandler E_TowerHit;
    #endregion

    private void Start()
    {
        Btn_Skill.onClick.AddListener(StartSkill);
       
    }



    private void Update()
    {
        if (canSkill)
        {
            CDSkillTimer += Time.deltaTime;
           Img_LoadSkill.fillAmount = CDSkillTimer / CDSkillTower;

            if (CDSkillTimer >= CDSkillTower)
            {
                canSkill = false;
                CDSkillTimer = 0f;
                
            }
        }
    }

    protected void StartSkill()
    {
        if (!canSkill)
        {
            Img_LoadSkill.fillAmount = 0f;
            Obj_Skill.SetActive(true);
            canSkill = true;
        }
    }
    public void OnTowerDie()
    {
        E_TowerDie?.Invoke(this, EventArgs.Empty);
    }
    public void OnTowerHit()
    {
        E_TowerHit?.Invoke(this, EventArgs.Empty);
    }
}

