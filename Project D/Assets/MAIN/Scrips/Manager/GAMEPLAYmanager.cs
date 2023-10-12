using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEPLAYmanager : MonoBehaviour
{
    public static GAMEPLAYmanager instance;

    public GameObject TowerPlayer, TowerEnemy;


    public enum StateGame
    {
        Playing,
        Win,
        Lose,
        END
    }
    public  StateGame stateGame;

    private void Start()
    {
        instance = this;
        stateGame = StateGame.Playing;
    }


    private void Update()
    {
        switch (stateGame)
        {
            case StateGame.Playing:
                break;

            case StateGame.Win:
                Debug.Log("win.");
                stateGame = StateGame.END;
                break;

            case StateGame.Lose:
                Debug.Log("lose");
                stateGame = StateGame.END;
                break;
            case StateGame.END:
                break;
        }
    }
}
