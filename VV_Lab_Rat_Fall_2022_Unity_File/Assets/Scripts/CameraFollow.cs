using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;

    private float distance = 10f;
    public float maxdistance = 10f;
    private float currentX = 0f;
    private float currentY = 0f;
    public float sensitivityY = 4;
    public float sensitivityX = 1;

    public void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerTransform.position, (transform.position-playerTransform.position), out hit, 999)){
            if(hit.transform != cameraTransform)
            {
                distance = Mathf.Min(maxdistance, hit.distance - 0.3f);
            }
        }
        else
        {
            distance = maxdistance;
        }
    }

    public void LateUpdate()
    {

        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");

        Vector3 dir = new Vector3(0f,0f,-distance);
        Quaternion rot = Quaternion.Euler(currentY, currentX, 0f);
        cameraTransform.position = playerTransform.position + (rot * dir);
        cameraTransform.LookAt(playerTransform.position);
    }
}
