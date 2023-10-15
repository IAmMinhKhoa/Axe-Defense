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
    [SerializeField] protected float TimeEnding;
    private float EndingTimer;
    protected bool CanSkill;
    #endregion

    #region GameObject
    public GameObject Prefab_skill;
    public Transform Target_Skill;
    public TextMeshProUGUI textCDSkill;
    #endregion

    private void Start()
    {
        E_StartSkill += ControllerSkillTower_E_StartSkill; 
    }

    private void ControllerSkillTower_E_StartSkill(object sender, EventArgs e)
    {
        //EVENT CALL WHEN FROM STATE WAITING -> STATE START TO INSTANCE "OBJECT SKILL"
        GameObject MegaFireBalll= Instantiate(Prefab_skill, new Vector3(Target_Skill.position.x, Target_Skill.position.y + 10, 0), Quaternion.identity);
        MegaFireBalll.transform.parent = this.transform;
       //SET TARGET FOR "OBJECT SKILL" TO FOLLOW THIS TARGET
        MegaFireBalll.GetComponent<SkillTower>().SetTarget(Target_Skill);
    }

    private void Update()
    {
        if (CanSkill)
        {
            switch (StateSkill)
            {
                case State.Waiting:
                    WaitingTimer -= Time.deltaTime;
                    textCDSkill.text = Mathf.FloorToInt(WaitingTimer).ToString();
                    if (WaitingTimer <= 0)
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
                    EndingTimer -= Time.deltaTime;
                    if (EndingTimer <= 0)
                    {
                        Target_Skill.gameObject.SetActive(false);
                        CanSkill = false;
                    }
                    break;
                default:
                    break;
            }
        }

    }


    public void RUNSkill()
    {
        //FUNCTION RUN WHEN PLAYER CLICK BUTTON "SKILL OF TOWER"

        //RETURN STATE IN WAITING
        StateSkill = State.Waiting;

        //VARIABLE "CanSkill" MAKE LOOP IN UPDATE RUN
        this.CanSkill = true;

        //RESET VARIABLE TIME DEFAULT
        WaitingTimer = TimeWaiting;
        EndingTimer = TimeEnding;

        //ENABLE OBJECT "TARGET" AND " TEXT COOLDOWN"
        Target_Skill.gameObject.SetActive(true);
        textCDSkill.enabled = true;

        //ENABLE FOR TARGET CAN MOVE BY CURSOR
        Target_Skill.gameObject.GetComponent<ObjectMovement>().SetCanMoveObject(true);
    }
    public bool GetCanSkill()
    {
        return CanSkill;
    }
}
