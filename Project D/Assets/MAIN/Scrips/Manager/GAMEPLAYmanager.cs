using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEPLAYmanager : MonoBehaviour
{
    public static GAMEPLAYmanager instance;

    public GameObject UI_Win, UI_Lose;

    public event EventHandler E_OnWin,E_OnLose;

    protected bool isPaused = false;
    public enum StateGame
    {
        Playing,
        Win,
        Lose,
        Pause,
        END
    }
    public  StateGame stateGame;

    private void Start()
    {
        instance = this;
        stateGame = StateGame.Playing;
        Time.timeScale = 1f;
        E_OnLose += GAMEPLAYmanager_E_OnLose;
        E_OnWin += GAMEPLAYmanager_E_OnWin;
    }

    private void GAMEPLAYmanager_E_OnWin(object sender, EventArgs e)
    {
        StartCoroutine(DelayToChangeState(UI_Win, 1f));
 
    }

    private void GAMEPLAYmanager_E_OnLose(object sender, EventArgs e)
    {
        StartCoroutine(DelayToChangeState(UI_Lose, 1f));
    }

    private void Update()
    {
        
        switch (stateGame)
        {
            case StateGame.Playing:
                break;

            case StateGame.Win:
                E_OnWin?.Invoke(this, EventArgs.Empty);
                stateGame = StateGame.END;
                break;

            case StateGame.Lose:
                E_OnLose?.Invoke(this, EventArgs.Empty);
                stateGame = StateGame.END;
                break;
            case StateGame.END:
                break;
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    protected IEnumerator DelayToChangeState(GameObject obj,float t)
    {
        yield return new WaitForSeconds(t);
        obj.SetActive(true);
        TogglePause();
    }


    public void RestartScene()
    {
        if (SceneManager.instance==null){
            Debug.LogWarning("Not have Sence manager don't destroy on load ?");
            return;
        }
        SceneManager.instance.ReloadScene();

    }
    public void MoveToSence(int i)
    {
        if (SceneManager.instance == null)
        {
            Debug.LogWarning("Not have Sence manager don't destroy on load ?");
            return;
        }
        SceneManager.instance.LoadScene(i);

    }
}
