using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
    List<string> namesList = new List<string>();
    List<string> sciencefieldList = new List<string>(); 

    public Canvas mainMenu;
    public Canvas exitMenu;
    public Canvas optionMenu;
    public Canvas addPlayer;
    public Canvas inputField;
    public Button playText;
    public Button optionText;
    public Button exitText;

    public Button scientist;
    public Button engenieer;
    public Button farmer;
    public Button tourist;
    public Button astronaut;

    public Button createPlayer;

    string playerName;

    // Use this for initialization
    void Start ()
    {
        mainMenu = mainMenu.GetComponent<Canvas>();
        exitMenu = exitMenu.GetComponent<Canvas>();
        optionMenu = optionMenu.GetComponent<Canvas>();
        addPlayer = addPlayer.GetComponent<Canvas>();
        inputField = inputField.GetComponent<Canvas>();
        playText = playText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionText = optionText.GetComponent <Button>();

        scientist = scientist.GetComponent<Button>();
        engenieer = engenieer.GetComponent<Button>();
        farmer = farmer.GetComponent<Button>();
        tourist = tourist.GetComponent<Button>();
        astronaut = astronaut.GetComponent<Button>();
       
        createPlayer = createPlayer.GetComponent<Button>();

        mainMenu.enabled = true;
        exitMenu.enabled = false;
        optionMenu.enabled = false;
        addPlayer.enabled = false;
        inputField.enabled = false;
    }

    public void PressPlay()
    {
        mainMenu.enabled = false;
        addPlayer.enabled = true;
    }

    public void StartGame()
    {
       SceneManager.LoadScene("MainLevel");
    }

    public void OptionPress()
    {

    }

    public void ExitPress()
    {
        exitMenu.enabled = true;
        mainMenu.enabled = false;
    }

    public void NoPress()
    {
        exitMenu.enabled = false;
        mainMenu.enabled = true; 
    }

    public void YesPress()
    {
        Application.Quit();
    }

    public void CreatePerson()
    {

        inputField.enabled = true;
        
        scientist.interactable = false;
        engenieer.interactable = false;
        farmer.interactable = false;
        tourist.interactable = false;
        astronaut.interactable = false;

        createPlayer.enabled = true;  
    } 

    public void FinishPerson()
    {
        inputField.enabled = false;

        scientist.interactable = true;
        engenieer.interactable = true;
        farmer.interactable = true;
        tourist.interactable = true;
        astronaut.interactable = true;

        createPlayer.enabled = false;
        
    }

    public void SetPlayerName(string value)
    {
        playerName = value;
        namesList.Add(playerName);
        foreach (string data in namesList)
        {
            Debug.Log(data);
        }
    }

    public void SciFieldList()
    {
        
        if (scientist)
            sciencefieldList.Add("scientist");
        else if (engenieer)
            sciencefieldList.Add("engenieer");
        else if (farmer)
            sciencefieldList.Add("farmer");
        else if (tourist)
            sciencefieldList.Add("tourist");
        else if (astronaut)
            sciencefieldList.Add("astronaut");

        Debug.Log(sciencefieldList.Count);

        foreach (string data in sciencefieldList)
        {
            Debug.Log(data);
        }
    }

}



