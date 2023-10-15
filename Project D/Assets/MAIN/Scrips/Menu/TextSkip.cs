using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSkip : MonoBehaviour
{
    private void Start()
    {
        MenuController.instance.OnShowSkip += MenuController_OnShowSkip;

        Hide();
    }

    private void MenuController_OnShowSkip(object sender, System.EventArgs e)
    {
        if (MenuController.instance.isMenu())
        {
            Hide();
        }
        else
        {
            Show();
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
