using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTower_Player : ControllerTower
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

   

    private void Start()
    {
        Btn_Skill.onClick.AddListener(StartSkill);
        Init();
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
            ControllerSkillTower CT_skill = Obj_Skill.GetComponent<ControllerSkillTower>();
            if (!CT_skill.GetCanSkill()) {//CHECKING "OBJECT SKILL" IS FLYING ?
                //IF NOT "OBJECT SKILL" FLYING -> DO BELOW
                Img_LoadSkill.fillAmount = 0f;
                CT_skill.RUNSkill();
                canSkill = true;
            }
            
        }
    }
   
}

