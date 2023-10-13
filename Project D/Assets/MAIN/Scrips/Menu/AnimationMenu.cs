using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenu : MonoBehaviour
{
    private void Start()
    {
        MenuController.instance.OnPhaseChanged += MenuController_OnPhaseChanged;

        Hide();
    }

    private void MenuController_OnPhaseChanged(object sender, System.EventArgs e)
    {
        if (MenuController.instance.isAnimation() || MenuController.instance.isMenu())
        {
            Show();
        }
        else
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
