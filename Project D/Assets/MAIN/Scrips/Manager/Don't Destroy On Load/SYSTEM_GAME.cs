using System.Collections;
using System.Collections.Generic;
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
        SetCoin(6969);

        CurrencyCoin = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin", CurrencyCoin);
    }


    public void SetBoolFirstPlayIntro(bool temp)
    {
        FirstRunIntro = temp;
    }
    public bool GetBoolFirstPlayIntro()
    {
        return FirstRunIntro;
    }   

    public void SetCoin(int Value)
    {
        //update new coin
        PlayerPrefs.SetInt("Coin", Value);
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt("Coin");
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
