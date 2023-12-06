using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SYSTEM_GAME : MonoBehaviour
{
    private static SYSTEM_GAME instance;

    protected bool FirstRunIntro=true;

    protected int CurrencyCoin;

    protected bool CheckLoadingSence = false;

    [SerializeField] protected Animator A_Transtion;


    protected string encryptedValue;

    float temp = 0;
    double prvioustime=0;
    double gametime;
    double realtime=0;
    double timeDiff;

    public SO_ValueSystem SO_system;

    public GameObject canvasHacking;


    private float lastGameTime = 0f;

    public static SYSTEM_GAME Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SYSTEM_GAME>();

                if (instance == null)
                {
                    GameObject managerObject = new GameObject("SYSTEM GAME");
                    instance = managerObject.AddComponent<SYSTEM_GAME>();
                    DontDestroyOnLoad(managerObject);
                }
            }

            return instance;
        }
    }

    void Awake()
    {
         
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        //SET COIN CHO NGTA CH?I CHO D?


        //CurrencyCoin = PlayerPrefs.GetInt("Coin");
        // SO_system.coin = SecurityManager.Instance.Encrypt("800");
        /* Debug.Log(SO_system.coin);
         CurrencyCoin = int.Parse( SecurityManager.Instance.Decrypt(SO_system.coin));
         Debug.Log(CurrencyCoin);
         encryptedValue = SecurityManager.Instance.Encrypt(CurrencyCoin.ToString());*/
        // SetCoin(6969);
        //PlayerPrefs.SetInt("Coin", CurrencyCoin);
      
       // SetCoin(SO_system.coin);
    }

    private void Start()
    {
        prvioustime = System.DateTime.Now.Second;
        gametime = 1;


       
        SetCoin(SO_system.coin);


    }

    private void Update()
    {
        Checking_Timer_Local();
        //Checking_Timer_API();

        Debug.Log(gametime + "/" + realtime);
    }
    #region CHECKING TIMER WITH MENTOD 1 : TIMER LOCAL
    protected void Checking_Timer_Local()
    {
        if (prvioustime != DateTime.Now.Second)
        {
            realtime++;
            prvioustime = DateTime.Now.Second;
            timeDiff = (int)gametime - realtime;
            if (timeDiff > 5)
            {
                canvasHacking.SetActive(true);
                Debug.Log("HACKING TIMER !!!!!!");
                Time.timeScale = 0;
            }
        }
        gametime += Time.deltaTime;
    }

    #endregion

    protected void Checking_Timer_API()
    {
        float currentGameTime = WorldTimeAPI.Instance.GetCurrentDateTime().Second;
        if (prvioustime != currentGameTime)
        {
            realtime++;
            prvioustime = currentGameTime;
            timeDiff = (int)gametime - realtime;
            if (timeDiff > 5)
            {
                canvasHacking.SetActive(true);
                Debug.Log("cc3");
                Time.timeScale = 0;
            }
        }
        gametime += Time.deltaTime;
    }

    public void SetBoolFirstPlayIntro(bool temp)
    {
        FirstRunIntro = temp;
    }
    public bool GetBoolFirstPlayIntro()
    {
        return FirstRunIntro;
    }   

    public void SetCoin(int NewValue)
    {
        //update new coin
        CurrencyCoin = NewValue;
        encryptedValue = SecurityManager.Instance.Encrypt(CurrencyCoin.ToString());
      //  Debug.Log(encryptedValue);

    }

    public int GetCoin()
    {
      //  Debug.Log(encryptedValue);
        string temp= SecurityManager.Instance.Decrypt(encryptedValue);
        int afterDecry = int.Parse(temp);
        if (afterDecry != CurrencyCoin)
        {
            Debug.Log("?????????????? CHEAT GI DO BRO");
            CurrencyCoin = afterDecry;
        }
        return afterDecry;
    }

    private void OnDestroy()
    {
        SO_system.coin = CurrencyCoin;
    }

    public void LoadSenceWithStringName(string input)
    {
        //StartCoroutine(LoadSenceWithFX(nameSence));

        if (int.TryParse(input, out int buildIndex))
        {
            SoundManager.instance.PlaySound(SoundType.Transtion_Sence);
            StartCoroutine(LoadSceneWithFXByBuildIndex(buildIndex));
        }
        else
        {
            SoundManager.instance.PlaySound(SoundType.Transtion_Sence);
            StartCoroutine(LoadSceneWithFXByName(input));
        }
    }

    IEnumerator LoadSceneWithFXByBuildIndex(int buildIndex)
    {
        if (!CheckLoadingSence)
        {
            A_Transtion.SetTrigger("End");
            CheckLoadingSence = true;
            yield return new WaitForSeconds(1f);
            CheckLoadingSence = false;

            if (buildIndex >= 0 && buildIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(buildIndex);
             
                A_Transtion.SetTrigger("Start");
            }
            else
            {
                Debug.LogError("Invalid build index: " + buildIndex);
            }
        }
        
        
    }

    IEnumerator LoadSceneWithFXByName(string sceneName)
    {

        if (!CheckLoadingSence)
        {
            A_Transtion.SetTrigger("End");
            CheckLoadingSence = true;
            yield return new WaitForSeconds(1f);

            CheckLoadingSence = false;
            SceneManager.LoadScene(sceneName);
            A_Transtion.SetTrigger("Start");
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
