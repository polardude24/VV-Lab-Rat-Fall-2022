using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject TextObject;
    public float timeLeftMinutes = 5;
    public float timeLeftSeconds = 0;
    public float f = 300f;
    public float f1;
    public TextMeshProUGUI text;
    public GameObject GameOverObject;
    public bool gameRunning = false;
    void Update()
    {
        if (gameRunning)
        {
            f -= Time.deltaTime;
        }
        
        f1 = Mathf.CeilToInt(f);
        timeLeftSeconds = f1 % 60;
        timeLeftMinutes = Mathf.Floor(f1 / 60);
        if (f > -1)
        {
            if (timeLeftSeconds <= 9)
            {
                text.text = "Time left: \n" + timeLeftMinutes.ToString() + ":0" + timeLeftSeconds.ToString();
            }
            else if (timeLeftSeconds > 9)
            {
                text.text = "Time left: \n" + timeLeftMinutes.ToString() + ":" + timeLeftSeconds.ToString();
            }
        }
        else
        {
            TextObject.SetActive(false);
            GameOverObject.GetComponent<GameOver>().timeUp = true;            
        }
    }
}