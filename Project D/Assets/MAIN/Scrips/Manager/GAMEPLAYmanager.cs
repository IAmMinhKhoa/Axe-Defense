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
    public event EventHandler E_OnWin, E_OnLose, E_OnPause;
    #endregion

    #region GameObject
    [SerializeField] protected GameObject UI_Win, UI_Lose, UI_Pause;
    [SerializeField] protected Button Btn_SpeedGame;
    [SerializeField] protected Animator animatorPanelSetting;
    #endregion

    #region Variable
    protected bool isPaused = false;
    protected bool isX2Speed=false;
    public int DefaultMana = 3;
    public TextMeshProUGUI[] textLevels;
    #endregion

    #region Sound
    public AudioSource audioSource;
    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    private bool isSoundOn = true;
    #endregion


    public enum StateGame
    {
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
        Btn_SpeedGame.onClick.AddListener(UpSpeedGame);
        foreach(TextMeshProUGUI textLevel in textLevels)
        {
            textLevel.text = getScenceName();
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
        StartCoroutine(DelayToChangeState(UI_Win, 2f));
 
    }

    private void GAMEPLAYmanager_E_OnLose(object sender, EventArgs e)
    {
        StartCoroutine(DelayToChangeState(UI_Lose, 2f));
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
        E_OnPause?.Invoke(this, EventArgs.Empty);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            audioSource.mute = false;
            soundButton.image.sprite = soundOnSprite;
        }
        else
        {
            audioSource.mute = true;
            soundButton.image.sprite = soundOffSprite;
        }
    }

    public string getScenceName()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        return currentScene.name;
    }

    protected IEnumerator DelayToChangeState(GameObject obj,float t)
    {
        yield return new WaitForSeconds(t);
        obj.SetActive(true);
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

    public void UpSpeedGame(string name)
    {
        isX2Speed = !isX2Speed;
        if (isX2Speed)
        {
            Time.timeScale = 2f;
            Btn_SpeedGame.GetComponentInChildren<TextMeshProUGUI>().text = "X2";
        }
        else
        {
            Time.timeScale = 1f;
            Btn_SpeedGame.GetComponentInChildren<TextMeshProUGUI>().text = "X1";
        }
    }
}
