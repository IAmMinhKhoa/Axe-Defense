using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMEPLAYmanager : MonoBehaviour
{
    #region Singloten
    public static GAMEPLAYmanager instance;
    #endregion

    #region Event
    public event EventHandler E_OnWin, E_OnLose, E_OnPause, E_OnTutorial;
    #endregion

    #region GameObject
    [SerializeField] protected GameObject UI_Win, UI_Lose, UI_Pause, UI_Tutorial;
    [SerializeField] protected Button Btn_SpeedGame;
    [SerializeField] protected Animator animatorPanelSetting;
    #endregion

    #region Variable
    protected bool isPaused = false;
    protected bool isTutorial = false;
    protected bool isX2Speed=false;
    
    public TextMeshProUGUI[] textLevels;
    #endregion

    #region Sound

    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    
    #endregion


    public enum StateGame
    {
        SetUpCard,
        Playing,
        Win,
        Lose,
        Pause,
        END
    }
    public  StateGame stateGame;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stateGame = StateGame.Playing;
        Time.timeScale = 1f;
        soundButton.onClick.AddListener(ToggleSound);
        E_OnLose += GAMEPLAYmanager_E_OnLose;
        E_OnWin += GAMEPLAYmanager_E_OnWin;
        E_OnPause += GAMEPLAYmanager_E_OnPause;
        E_OnTutorial += GAMEPLAYmanager_E_OnTutorial;
        Btn_SpeedGame.onClick.AddListener(UpSpeedGame);
        foreach(TextMeshProUGUI textLevel in textLevels)
        {
            textLevel.text = getScenceName();
        }


        //SOUND BACKGROUND SCENE MENU
        SoundManager.instance.PlayBackGround(3);

        //CHECK STATUS OF SOUND AND SET UP ICON (ON OR OFF ICON SOUND)
        CheckStatusSoundAndSetIcon();
    }

    private void GAMEPLAYmanager_E_OnTutorial(object sender, EventArgs e)
    {
        if (isTutorial)
        {
            UI_Tutorial.SetActive(true);
            CameraDrag.instance.isDrag = false;
        }
        else
        {
            animatorPanelSetting.SetTrigger("Show");
            UI_Tutorial.SetActive(false);
            CameraDrag.instance.isDrag = true;
        }
    }

    private void GAMEPLAYmanager_E_OnPause(object sender, EventArgs e)
    {
        if(isPaused)
        {
            animatorPanelSetting.SetTrigger("Show");
            UI_Pause.SetActive(true);
            CameraDrag.instance.isDrag = false;
        } 
        else
        {
            UI_Pause.SetActive(false);
            CameraDrag.instance.isDrag = true;
        }
    }

    private void GAMEPLAYmanager_E_OnWin(object sender, EventArgs e)
    {
        UnlockNextLevel();
        StartCoroutine(DelayToChangeState(UI_Win, 2f, SoundType.WinGame));
    }

    private void GAMEPLAYmanager_E_OnLose(object sender, EventArgs e)
    {
        StartCoroutine(DelayToChangeState(UI_Lose, 2f,SoundType.LoseGame));
    
    }

    private void Update()
    {
        
        switch (stateGame)
        {
            case StateGame.SetUpCard:
                break;

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
        E_OnPause?.Invoke(this, EventArgs.Empty);
        Time.timeScale = isPaused ? 0f : 1f;

        if (isPaused)
        {
            SoundManager.instance.PauseSound();
        }
        else
        {
            SoundManager.instance.SetAllVolumesToOriginal();
        }
    }

    public void ToggleTutorial()
    {
        isTutorial = !isTutorial;
        E_OnTutorial?.Invoke(this, EventArgs.Empty);
        Time.timeScale = isTutorial ? 0f : 1f;
    }

    private void ToggleSound()
    {
        bool statusSound = SoundManager.instance.ToggleSound();
        CheckStatusSoundAndSetIcon();
    }
    private void CheckStatusSoundAndSetIcon()
    {
        bool temp = SoundManager.instance.activeSound;
        if (temp)
        {
            soundButton.image.sprite = soundOnSprite;
        }
        else
        {
            soundButton.image.sprite = soundOffSprite;
        }
    }

    public string getScenceName()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        return currentScene.name;
    }

    protected IEnumerator DelayToChangeState(GameObject obj,float t, SoundType type)
    {
        yield return new WaitForSeconds(t);
        obj.SetActive(true);
        //SOUND WHEN type 
        SoundManager.instance.PlaySound(type);
        Time.timeScale = 0f;
    }


    public void UpSpeedGame()
    {
        isX2Speed = !isX2Speed;
        if(isX2Speed) {
            Time.timeScale = 2f;
            Btn_SpeedGame.GetComponentInChildren<TextMeshProUGUI>().text = "X2";
        }
        else
        {
            Time.timeScale = 1f;
            Btn_SpeedGame.GetComponentInChildren<TextMeshProUGUI>().text = "X1";
        }
    }

    private void UnlockNextLevel()
    {
        
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
       
    }


}
