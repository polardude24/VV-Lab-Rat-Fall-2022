using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingContrller : MonoBehaviour
{
    private Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    public string[] userInput = new string[4]{"w", "a", "s", "d"};
    private int countingVariable = 0;
    private bool isWalking = false;

    void Update()
    {
        if (mAnimator != null)
        {
            if (isWalking)
            {
                KeyInput("w");
            }

            KeyInput("a");
            KeyInput("s");
            KeyInput("d");
            /*
            KeyInput(userInput[countingVariable]);
            countingVariable++;
            if (countingVariable == 4)
            {
                countingVariable = 0;
            }
            */
        }
    }

    public void KeyInput(string k)
    {
        if (Input.GetKey(k))
        {
            mAnimator.SetBool("Walk", true);
            isWalking = true;
            Debug.Log(userInput[countingVariable]);
        }
        else if (Input.GetKey(k) == false)
        {
            mAnimator.SetBool("Walk", false);
            isWalking = false;
        }
    }
}
