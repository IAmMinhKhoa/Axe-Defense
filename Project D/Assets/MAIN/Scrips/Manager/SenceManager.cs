using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
{

    public void loadScence(string Scene)    
    {
        SoundManager.instance.PlaySound(SoundType.SFX_HowerCard);

        Time.timeScale = 1f;
        SYSTEM_GAME.Instance.LoadSenceWithStringName(Scene);
    }

    public void RestartGame()
    {
        SoundManager.instance.PlaySound(SoundType.SFX_HowerCard);

        // Lấy tên scene hiện tại
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Tải lại scene hiện tại

        SYSTEM_GAME.Instance.LoadSenceWithStringName(currentSceneName);

        GAMEPLAYmanager.instance.TogglePause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextSenceLevel()
    {
        SoundManager.instance.PlaySound(SoundType.SFX_HowerCard);

        Time.timeScale = 1f;
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;


        SYSTEM_GAME.Instance.LoadSenceWithStringName(buildIndex.ToString());

    }
}
