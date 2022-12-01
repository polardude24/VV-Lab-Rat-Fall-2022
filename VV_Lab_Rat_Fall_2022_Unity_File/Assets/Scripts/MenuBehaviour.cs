using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject timerObject;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject menuCamera;

    void Start()
    {
        mainMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainMenu.SetActive(false);
        player.SetActive(true);
        playerCamera.SetActive(true);
        menuCamera.SetActive(false);
        timerObject.GetComponent<Timer>().gameRunning = true;
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mainMenu.SetActive(true);
        player.SetActive(false);
        playerCamera.SetActive(false);
        menuCamera.SetActive(true);
        timerObject.GetComponent<Timer>().gameRunning = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
