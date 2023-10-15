using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] btnGameObjects;
    [SerializeField]
    private GameObject levelButtons;
    [SerializeField]
    private Sprite iconLock;
    [SerializeField]
    private Sprite iconUnlock;

    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < btnGameObjects.Length; i++)
        {
            btnGameObjects[i].GetComponent<Button>().interactable = false;
            btnGameObjects[i].transform.GetChild(0).GetComponent<Image>().sprite = iconLock;
        }
        for(int i = 0; i < unlockedLevel; i++)
        {
            btnGameObjects[i].GetComponent<Button>().interactable = true;
            btnGameObjects[i].transform.GetChild(0).GetComponent<Image>().sprite = iconUnlock;
        }
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);  
    }

    void ButtonsToArray()
    {
        int childCount = levelButtons.transform.childCount;
        btnGameObjects = new GameObject[childCount];
        for(int i = 0;i < childCount;i++)
        {
            btnGameObjects[i] = levelButtons.transform.GetChild(i).gameObject;
        }
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}


