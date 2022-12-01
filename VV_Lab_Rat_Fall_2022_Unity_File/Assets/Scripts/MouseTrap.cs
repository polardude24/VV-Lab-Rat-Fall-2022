using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public Animator anim;
    public GameObject timerObject;
    public GameObject cheese;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<ThirdPersonMovement>().isKilled = true;
            anim.SetBool("Play", true);
            timerObject.GetComponent<Timer>().f = 0;
            cheese.SetActive(false);
        }
    }
}
