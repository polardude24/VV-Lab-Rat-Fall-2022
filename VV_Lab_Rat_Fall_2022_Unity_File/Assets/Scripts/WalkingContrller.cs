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
            if (KeyInput("w") || KeyInput("a") || KeyInput("s") || KeyInput("d"))
            {
                mAnimator.SetBool("Walk", true);
            }
            else mAnimator.SetBool("Walk", false);
        }
    }

    public bool KeyInput(string k)
    {
        if (Input.GetKey(k))
        {
            isWalking = true;
        }
        else if (Input.GetKey(k) == false)
        {
            isWalking = false;
        }
        return isWalking;
    }
}
