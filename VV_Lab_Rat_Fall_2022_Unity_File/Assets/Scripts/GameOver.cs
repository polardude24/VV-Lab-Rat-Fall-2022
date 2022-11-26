using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float opacity = 0f;
    public RawImage gameOver;
    public bool timeUp = false;
    public GameObject mainMenu;


    void Update()
    {
        if (timeUp)
        {
            Color g = new Color(255, 255, 255, opacity);
            gameOver.color = g;
            if (opacity < 3)
            {
                opacity += (Time.deltaTime)/2.5f;
            }
            if (opacity > 2)
            {
                mainMenu.SetActive(true);
                opacity = 0;
                Color e = new Color(255, 255, 255, 0);
                gameOver.color = e;
                timeUp = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
