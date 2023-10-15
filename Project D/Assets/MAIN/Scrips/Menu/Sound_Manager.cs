using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager1 : MonoBehaviour
{
    private void Start()
    {
        MenuController.instance.OnShowSound += MenuController_OnShowSound;

        Hide();
    }

    private void MenuController_OnShowSound(object sender, System.EventArgs e)
    {
        if (MenuController.instance.isAnimation())
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
