using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public event EventHandler OnPhaseChanged, OnShowSkip, OnShowSound;

    public Animator animator;

    private bool hasPlayedIntro = false;

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
    public float buttonTimeSkip = 10f;
    private bool textDisplayed = false;

    // Giai đoạn hiện tại
    private MenuPhase currentPhase;

    private void Awake()
    {
        instance = this;

        currentPhase = MenuPhase.Logo;
    }

    private void Update()
    {
        if (!textDisplayed)
        {
            // Giảm giá trị của biến đếm thời gian
            buttonTimeSkip -= Time.deltaTime;

            // Kiểm tra nếu giá trị của biến đếm thời gian nhỏ hơn hoặc bằng 0
            if (buttonTimeSkip <= 0f)
            {
                // Hiển thị đoạn text
                OnShowSkip?.Invoke(this, new EventArgs());

                // Đánh dấu biến đã hiển thị là true
                textDisplayed = true;
            }
        }
        if (textDisplayed && Input.GetKeyDown(KeyCode.Space))
        {
            changeScenceMenu();
        }
        switch (currentPhase)
        {
            case MenuPhase.Logo:
                logoDuration -= Time.deltaTime;
                if (logoDuration < 0)
                {
                    currentPhase = MenuPhase.Animation;
                    OnPhaseChanged?.Invoke(this, new EventArgs());
                    OnShowSound?.Invoke(this, new EventArgs());
                }
                break;
            case MenuPhase.Animation:
                animationDuration -= Time.deltaTime;    
                if (animationDuration < 0)
                {
                    currentPhase = MenuPhase.Menu;
                    OnPhaseChanged?.Invoke(this, new EventArgs());
                }
                break;
            case MenuPhase.Menu:
                animator.SetTrigger("Idle");
                OnShowSkip?.Invoke(this, new EventArgs());
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

    public void changeScenceMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
