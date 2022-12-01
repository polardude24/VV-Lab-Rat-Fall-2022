using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float opacity = 0f;
    public RawImage gameOver;
    public RawImage gameWon;
    public bool timeUp = false;
    public bool wonGame = false;
    public GameObject mainMenu;
   
    void Update()
    {

        if (timeUp)
        {
            Color g = new Color(255, 255, 255, opacity);
            gameOver.color = g;
            if (opacity < 3)
            {
                Time.timeScale -= Time.deltaTime;
                opacity += (Time.unscaledDeltaTime)/2.5f;
            }
            if (opacity > 2)
            {
                Time.timeScale = 0;
                mainMenu.SetActive(true);
                opacity = 0;
                Color e = new Color(255, 255, 255, 0);
                gameOver.color = e;
                timeUp = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (wonGame)
        {
            Color g = new Color(255, 255, 255, opacity);
            gameWon.color = g;
            if (opacity < 3)
            {
                Time.timeScale -= Time.deltaTime;
                opacity += (Time.unscaledDeltaTime) / 2.5f;
            }
            if (opacity > 2)
            {
                Time.timeScale = 0;
                mainMenu.SetActive(true);
                opacity = 0;
                Color e = new Color(255, 255, 255, 0);
                gameWon.color = e;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void BeatTheGame()
    {
        wonGame = true;
    }
}
