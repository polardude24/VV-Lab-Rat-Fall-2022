using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPressing : MonoBehaviour
{
    //[SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    public GameObject door;
    public bool end_button; 

    public UnityEvent onPressed, onReleased;


    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {

        // Debug.Log(GetValue());
        if (!isPressed && GetValue() >= 1)
        {
            if (end_button)
            {
                Pressed(); 
            } else
            {
                Destroy(door);
            } 
      
        }
        if (isPressed && GetValue()  <= 0.72)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition / joint.linearLimit.limit) ;

        if (Mathf.Abs(value) < deadzone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
    }
}
