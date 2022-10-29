using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float opacity = 0f;
    public RawImage gameOver;
    public bool timeUp = false;


    void Update()
    {
        if (timeUp)
        {
            Color g = new Color(255, 255, 255, opacity);
            gameOver.color = g;
            if (opacity < 2)
            {
                opacity += (Time.deltaTime)/2.5f;
            }
        }
    }
}
