using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public bool startGame = false;

    void Start()
    {
        mainMenu.SetActive(true);
    }

    void Update()
    {
        if (startGame)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(true);
        }


    }
}
