using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    public void OnOpen()
    {
        myDoor.SetBool("OpenDoor", true);
    }
    public void OnClose()
    {
        myDoor.SetBool("OpenDoor", false);
    }

    private void OnTriggerEnter(Collider other)
    {
            
    }
}
