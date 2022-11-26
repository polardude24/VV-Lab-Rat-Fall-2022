using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingContrller : MonoBehaviour
{
    private Animator mAnimator;
    public GameObject player;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    private bool isWalking = false;
    public bool isJumping = false;

    void Update()
    {
        if (mAnimator != null)
        {
            if (player.GetComponent<ThirdPersonMovement>().grounded == false)
            {
                mAnimator.SetFloat("RunMultiplier", 0.2f);
            }
            else mAnimator.SetFloat("RunMultiplier", 1);
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
