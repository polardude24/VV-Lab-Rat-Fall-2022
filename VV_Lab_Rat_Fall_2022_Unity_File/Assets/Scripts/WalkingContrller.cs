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
    private float distanceToGround = 0;
    RaycastHit hit = new();

    void Update()
    {
        if (Physics.Raycast (transform.position, -Vector3.up, out hit))
        {
            distanceToGround = hit.distance * 4;
            mAnimator.SetFloat("RunMultiplier", 1 / distanceToGround);
        }
        if (mAnimator != null)
        {

            if (player.GetComponent<ThirdPersonMovement>().grounded)
            {
                mAnimator.SetFloat("RunMultiplier", 1);
            }
            if (KeyInput("w") || KeyInput("a") || KeyInput("s") || KeyInput("d"))
            {
                mAnimator.SetBool("Walk", true);
            }
            else mAnimator.SetBool("Walk", false);
            if (KeyInput("space") && player.GetComponent<ThirdPersonMovement>().grounded)
            {
                mAnimator.Play("Start Walk");
                //WaitABit();
            }
        }
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(0.3f);
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
