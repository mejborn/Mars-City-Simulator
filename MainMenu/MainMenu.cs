using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Canvas exitMenu;
    public Canvas optionMenu; 
    public Button playText;
    public Button optionText;
    public Button exitText;


    // Use this for initialization
    void Start ()
    {
        exitMenu = exitMenu.GetComponent<Canvas>();
        playText = playText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionText = optionText.GetComponent <Button>();
        exitMenu.enabled = false;
    }

    public void PlayPress()
    {
       SceneManager.LoadScene("MainLevel");
    }

    public void OptionPress()
    {

    }


    public void ExitPress()
    {
        exitMenu.enabled = true;
        playText.enabled = false;
        exitText.enabled = false;
        optionText.enabled = false; 
    }

    public void NoPress()
    {
        exitMenu.enabled = false;
        playText.enabled = true;
        exitText.enabled = true;
        optionText.enabled = true;
    }

    public void YesPress()
    {
        Application.Quit();
    }


}
