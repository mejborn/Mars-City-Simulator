using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public bool isPause = false;

    public Canvas pauseMenu;
    public Canvas exitMenu;
    public Button continueText;
    public Button exitText;
    public Button optionText;

    void Start()
    {
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        exitMenu = exitMenu.GetComponent<Canvas>();
        continueText = continueText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionText = optionText.GetComponent<Button>();
        pauseMenu.enabled = false;
        exitMenu.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0;
                pauseMenu.enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.enabled = false;
            }
        }
    }

    public void ContinuePress()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            pauseMenu.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.enabled = false;
        }
    }

    public void ExitPress()
    {
        exitMenu.enabled = true;
        continueText.enabled = false;
        exitText.enabled = false;
        optionText.enabled = false;
    }

    public void NoPress()
    {
        exitMenu.enabled = false;
        continueText.enabled = true;
        exitText.enabled = true;
        optionText.enabled = true;
    }

    public void YesPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
