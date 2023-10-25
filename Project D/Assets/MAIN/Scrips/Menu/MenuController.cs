using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public event EventHandler OnPhaseChanged, OnShowSound;

    public Animator animator;

    

    // Enum liệt kê các giai đoạn của Scene menu
    public enum MenuPhase
    {
        Logo,       // Giai đoạn hiển thị logo
        Animation,  // Giai đoạn hiển thị đoạn animation
        Menu  // Giai đoạn hiển thị menu button
    }

    // Thời gian hiển thị của từng giai đoạn
    public float logoDuration = 3f;
    public float animationDuration = 17f;
    //public float buttonTimeSkip = 10f;


    // Giai đoạn hiện tại
    private MenuPhase currentPhase;

    private void Awake()
    {
        instance = this;

        currentPhase = MenuPhase.Logo;

        Time.timeScale = 1f;

    }

    private void Start()
    {
        //SOUND BACKGROUND SCENE MENU
        SoundManager.instance.PlayBackGround(1);

        SoundManager.instance.SetAllVolumesToOriginal();
    }
    private void Update()
    {
       

            switch (currentPhase)
            {
                case MenuPhase.Logo:
                    logoDuration -= Time.deltaTime;
                    if (logoDuration < 0 || SYSTEM_GAME.Instance.GetBoolFirstPlayIntro()==false)
                    {
                        currentPhase = MenuPhase.Animation;
                        OnPhaseChanged?.Invoke(this, new EventArgs());
                        OnShowSound?.Invoke(this, new EventArgs());
                    }
                    break;
                case MenuPhase.Animation:
                    animationDuration -= Time.deltaTime;
                    if (animationDuration < 0 || SYSTEM_GAME.Instance.GetBoolFirstPlayIntro() == false)
                    {
                        currentPhase = MenuPhase.Menu;
                        OnPhaseChanged?.Invoke(this, new EventArgs());
                    }
                    break;
                case MenuPhase.Menu:
                    animator.SetTrigger("Idle");
                    SYSTEM_GAME.Instance.SetBoolFirstPlayIntro(false);
                    break;
            }

        Debug.Log(currentPhase);
    }

    public bool isLogoIntro()
    {
        return currentPhase == MenuPhase.Logo;
    }

    public bool isAnimation ()
    {
        return currentPhase == MenuPhase.Animation;
    }

    public bool isMenu()
    {
        return currentPhase == MenuPhase.Menu;
    }

  

}
