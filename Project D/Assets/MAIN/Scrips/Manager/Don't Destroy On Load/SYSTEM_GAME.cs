using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class SYSTEM_GAME : MonoBehaviour
{
    private static SYSTEM_GAME instance;

    protected bool FirstRunIntro=true;

    protected int CurrencyCoin;

    protected bool CheckLoadingSence = false;

    [SerializeField] protected Animator A_Transtion;


    protected string encryptedValue;

    float temp = 0;
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
        

        CurrencyCoin = PlayerPrefs.GetInt("Coin");
        encryptedValue = SecurityManager.Instance.Encrypt(CurrencyCoin.ToString());
        SetCoin(6969);
        //PlayerPrefs.SetInt("Coin", CurrencyCoin);
        
    }


    private void Update()
    {
        //CurrencyCoin = PlayerPrefs.GetInt("Coin");
        // Debug.Log(CurrencyCoin);
        // Debug.Log(System.DateTime.Now.Second)

        // Time.maximumDeltaTime = 77f;
        //Debug.Log(Time.frameCount);
        // Time.timeScale = 1;
        //Debug.Log(Time.realtimeSinceStartup); //sp up
        // Debug.Log(Time.fixedTime); //sd up
       /* double timeSystem = System.DateTime.Now.Second-2;
        double timeCurrent= Math.Round(Time.time);
        double timeTemp = timeCurrent - timeSystem;
        if (timeTemp>10)
        {
            Debug.Log("HACK SPEED CON GAI ME MAY");
            Time.timeScale = 0;
        }*/
       // Debug.Log(timeSystem + "  /  "+ timeCurrent);
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

        // Mã hóa giá tr? m?i c?a coin
        encryptedValue = SecurityManager.Instance.Encrypt(CurrencyCoin.ToString());
        Debug.Log(encryptedValue);
        // L?u giá tr? ?ã mã hóa

    }

    public int GetCoin()
    {
        Debug.Log(encryptedValue);
        string temp= SecurityManager.Instance.Decrypt(encryptedValue);
        int afterDecry = int.Parse(temp);
        if (afterDecry != CurrencyCoin)
        {
            Debug.Log("?????????????? HACK CDMMM");
            CurrencyCoin = afterDecry;
        }
        return afterDecry;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Coin", CurrencyCoin);
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
}
