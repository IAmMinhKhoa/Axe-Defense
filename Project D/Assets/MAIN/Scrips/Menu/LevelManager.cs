using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
        /*PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("ReachedIndex", 1);*/

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


        //SOUND BACKGROUND SCENE LEVEL MAP
        SoundManager.instance.PlayBackGround(2);
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;

        //SceneManager.LoadScene(levelName);
        SYSTEM_GAME.Instance.LoadSenceWithStringName(levelName);
        
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
        //SceneManager.LoadScene("Menu");
        SYSTEM_GAME.Instance.LoadSenceWithStringName("Menu");
    }
}


