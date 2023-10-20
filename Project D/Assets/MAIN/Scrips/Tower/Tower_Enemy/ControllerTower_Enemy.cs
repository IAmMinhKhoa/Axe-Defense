using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControllerTower_Enemy : ControllerTower
{
    #region Controller
    protected ControllerCollision CT_Collision;
    protected Health_Tower CT_HealthTW;
    #endregion

    #region

    #endregion

    #region
    #endregion

    #region
    #endregion

    #region BOSS (Set up befor game play)
    [Header("BOSS (Set up befor game play)")]
    public bool UNCLOCK_FUNCTION_BOSS;
    [SerializeField] protected GameObject F_Boss;
    protected bool checkSpamBoss=false;
    #endregion
    [Space(20)]



    protected Collider2D[] L_Collider; //list collider object with layer
    [SerializeField] protected SO_CharacterInforMantionRANGER SO_Information;
    [SerializeField] protected Transform PointAttack;

    protected bool canAttack = true;
    [SerializeField] protected float attackCooldown;

    [SerializeField] protected List<GameObject> L_Enemy =new List<GameObject> ();
    private void Start()
    {
        CT_Collision=GetComponent<ControllerCollision>();
        CT_HealthTW = GetComponent<Health_Tower>();
        Init();

        //spam enemy by time
        InvokeRepeating("SpamtRandomEnemy",4 , 20);
    }

    private void Update()
    {
        L_Collider = CT_Collision.Return_L_CollderTouching();
        if (L_Collider.Length!=0)
        {
            Attack();
        }

        if (CT_HealthTW.GetCurrentHealth() < (CT_HealthTW.maxHealt / 4.0) && checkSpamBoss==false) // tru cua ke dich duoi 40% HP la se spam ra boss
        {
            checkSpamBoss = true;
            SummonBoss();
        }
    }


    protected void Attack()
    {
        if (!canAttack)
            return;
        L_A_InTower[1].SetTrigger("Attack");
        SetUpSkill();
        StartCoroutine(WaitCoroutine());
    }

    protected void SetUpSkill()
    {
        // GameObject BallSkill = Instantiate(SO_Information.PrefabSkill, PointAttack.position, Quaternion.identity);
        GameObject BallSkill = ObjectPoolManager.SpawnOject(SO_Information.PrefabSkill, PointAttack.transform.position, Quaternion.identity, ObjectPoolManager.Pooltyle.Skill);
        Skill Skill = BallSkill.GetComponent<Skill>();

        Skill.SetTargetForSkill(L_Collider[0].gameObject.transform);//Get first object in list object "enemy layer"
        Skill.SetDamgeSKill(SO_Information.Damge);
    }

    IEnumerator WaitCoroutine()//Waiting Cooldown
    {
        canAttack = false;
        yield return null;
      
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }


    public void SpamtRandomEnemy()
    {
        System.Random random = new System.Random();
        int Random_Index = random.Next(0, 3);
        GameObject Enemy = Instantiate(L_Enemy[Random_Index],new Vector3(transform.position.x-4f, transform.position.y, transform.position.z),quaternion.identity);
    }

    #region FUNCTION_BOSS
    protected void SummonBoss()
    {
        Instantiate(F_Boss, new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z), quaternion.identity);
    }

    #endregion
}
