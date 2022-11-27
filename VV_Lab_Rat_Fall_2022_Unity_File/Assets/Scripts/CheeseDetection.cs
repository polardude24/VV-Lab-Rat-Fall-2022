using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDetection : MonoBehaviour
{
    public GameObject collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cheese"))
        {
            Debug.Log("You win!");
            collider.SetActive(false);
        }
    }
}
