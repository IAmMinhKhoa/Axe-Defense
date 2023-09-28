using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSkillTower : MonoBehaviour
{
    public enum State
    {
        Waiting,
        Start,
        End
    }
    public State StateSkill;

    [SerializeField] protected float TimeWaiting;
    private float WaitingTimer;

    public event EventHandler E_StartSkill;

    public GameObject Prefab_skill;
    public Transform Target_Skill;
    private void Start()
    {
        StateSkill = State.Waiting;
        E_StartSkill += ControllerSkillTower_E_StartSkill;
    }

    private void ControllerSkillTower_E_StartSkill(object sender, EventArgs e)
    {
        GameObject MegaFireBalll= Instantiate(Prefab_skill, new Vector3(Target_Skill.position.x, Target_Skill.position.y + 5, 0), Quaternion.identity);
        MegaFireBalll.GetComponent<SkillTower>().SetTarget(Target_Skill);
    }

    private void Update()
    {
        switch (StateSkill)
        {
            case State.Waiting:
                WaitingTimer += Time.deltaTime;
                if(WaitingTimer>= TimeWaiting)
                {
                    StateSkill = State.Start;
                    E_StartSkill?.Invoke(this, EventArgs.Empty);
                    Debug.Log("spawm");
                }
                break;
            case State.Start:
                break;
            case State.End:
                break;
            default:
                break;
        }
    }
}
