using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void changeLevelMap()
    {
        SceneManager.LoadScene("LevelMap");
    }
    
    public void changeMenuIdle()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
