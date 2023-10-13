using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoIntro : MonoBehaviour
{
    private void Start()
    {
        MenuController.instance.OnPhaseChanged += MenuController_OnPhaseChanged;

        Show();
    }

    private void MenuController_OnPhaseChanged(object sender, System.EventArgs e)
    {
        if(MenuController.instance.isLogoIntro())
        {
            Show();
        } else
        {
            Hide();
        }   
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
