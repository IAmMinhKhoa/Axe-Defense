using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerSkillTower : MonoBehaviour
{
    #region Enum
    public enum State
    {
        Waiting,
        Start,
        End
    }
    public State StateSkill;
    #endregion

    #region Event
    protected event EventHandler E_StartSkill;
    #endregion

    #region Variable
    [SerializeField] protected float TimeWaiting;
    private float WaitingTimer;
    #endregion

    #region GameObject
    public GameObject Prefab_skill;
    public Transform Target_Skill;
    public TextMeshProUGUI textCDSkill;
    #endregion


    private void Start()
    {
        WaitingTimer=TimeWaiting;
        StateSkill = State.Waiting;
        E_StartSkill += ControllerSkillTower_E_StartSkill;
        textCDSkill.enabled = true;
    }

    private void ControllerSkillTower_E_StartSkill(object sender, EventArgs e)
    {
        GameObject MegaFireBalll= Instantiate(Prefab_skill, new Vector3(Target_Skill.position.x, Target_Skill.position.y + 10, 0), Quaternion.identity);
        MegaFireBalll.GetComponent<SkillTower>().SetTarget(Target_Skill);
    }

    private void Update()
    {
        switch (StateSkill)
        {
            case State.Waiting:
                WaitingTimer -= Time.deltaTime;
                textCDSkill.text= Mathf.FloorToInt(WaitingTimer).ToString();
                if (WaitingTimer<= 0)
                {
                    StateSkill = State.Start;
                    E_StartSkill?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.Start:
                textCDSkill.enabled = false;
                Target_Skill.gameObject.GetComponent<ObjectMovement>().SetCanMoveObject(false);
                StateSkill = State.End;
                break;
            case State.End:
                //this.gameObject.SetActive(false);
                break;
            default:
                break;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            E_StartSkill?.Invoke(this, EventArgs.Empty);
        }
    }
}
