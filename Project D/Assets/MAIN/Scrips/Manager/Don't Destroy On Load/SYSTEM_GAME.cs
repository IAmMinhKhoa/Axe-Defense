using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYSTEM_GAME : MonoBehaviour
{
    private static SYSTEM_GAME instance;

    protected bool FirstRunIntro=true;

    protected int CurrencyCoin;

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
}
