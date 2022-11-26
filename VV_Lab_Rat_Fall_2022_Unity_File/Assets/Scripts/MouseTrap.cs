using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public Animator anim;
    public GameObject timerObject;
    public GameObject cheese;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Play", true);
            Debug.Log("This is working");
            timerObject.GetComponent<Timer>().f = 0;
            cheese.SetActive(false);
        }
    }
}
