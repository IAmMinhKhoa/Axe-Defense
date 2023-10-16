using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
{
    public void loadScence(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void RestartGame()
    {
        // Lấy tên scene hiện tại
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Tải lại scene hiện tại
        SceneManager.LoadScene(currentSceneName);
    }
}
