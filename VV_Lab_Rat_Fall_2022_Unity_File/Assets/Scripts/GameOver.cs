using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float time = 0;
    

    void Update()
    {
        time -= Time.deltaTime;
    }
}
