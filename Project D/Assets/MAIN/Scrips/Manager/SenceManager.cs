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
}
