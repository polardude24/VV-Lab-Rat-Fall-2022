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

    void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                mAnimator.SetBool("Walk", true);
                //mAnimator.Play("Walk");
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                //mAnimator.StopPlayback();
                mAnimator.SetBool("Walk", false);
            }
        }
    }
}
