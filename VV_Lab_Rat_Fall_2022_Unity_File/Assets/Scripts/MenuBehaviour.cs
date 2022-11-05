using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject timerObject;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject menuCamera;

    void Start()
    {
        //mainMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
            timerObject.GetComponent<Timer>().gameRunning = false;
        }
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false); 
        player.SetActive(true);
        playerCamera.SetActive(true);
        menuCamera.SetActive(false);
        timerObject.GetComponent<Timer>().gameRunning = true;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        mainMenu.SetActive(true);
        player.SetActive(false);
        playerCamera.SetActive(false);
        menuCamera.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
