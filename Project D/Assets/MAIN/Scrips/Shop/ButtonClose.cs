using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClose : MonoBehaviour
{
    private Button buttonClose;     
    public string scenceNameToChange;
    // Start is called before the first frame update
    void Start()
    {
        buttonClose = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonClose.onClick.AddListener(changeToMenu);
    }

    private void changeToMenu()
    {
        SceneManager.LoadScene(scenceNameToChange);  
    }
}
