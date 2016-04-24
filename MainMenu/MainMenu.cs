using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

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
    public Button engineer;
    public Button farmer;
    public Button tourist;
    public Button astronaut;

    public Button createPlayer;

    string sciField;
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
        engineer = engineer.GetComponent<Button>();
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
        sciField = EventSystem.current.currentSelectedGameObject.name;
        if (sciField.Equals("Scientist"))
        {
            sciencefieldList.Add("scientist");
            foreach (string data in sciencefieldList)
            {
                Debug.Log(data);
            }
        }
        else if (sciField.Equals("Engineer"))
        {
            sciencefieldList.Add("engineer");
            foreach (string data in sciencefieldList)
            {
                Debug.Log(data);
            }
        }
        else if (sciField.Equals("Farmer"))
        {
            sciencefieldList.Add("farmer");
            foreach (string data in sciencefieldList)
            {
                Debug.Log(data);
            }
        }
        else if (sciField.Equals("Tourist"))
        {
            sciencefieldList.Add("tourist");
            foreach (string data in sciencefieldList)
            {
                Debug.Log(data);
            }
        }
        else if (sciField.Equals("Astronaut"))
        {
            sciencefieldList.Add("astronaut");
            foreach (string data in sciencefieldList)
            {
                Debug.Log(data);
            }
        }
        else
        {
            Debug.Log("Damn");
        }


    inputField.enabled = true;
        
        scientist.interactable = false;
        engineer.interactable = false;
        farmer.interactable = false;
        tourist.interactable = false;
        astronaut.interactable = false;

        createPlayer.enabled = true;  
    } 

    public void FinishPerson()
    {
        inputField.enabled = false;

        scientist.interactable = true;
        engineer.interactable = true;
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

}



