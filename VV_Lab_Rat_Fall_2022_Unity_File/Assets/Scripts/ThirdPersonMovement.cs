using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //public CharacterController controller;
    Rigidbody m_Rigidbody;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.81f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool grounded = false;

    Vector3 velocity;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        //velocity.y -= gravity * Time.deltaTime;
        //m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, velocity.y, m_Rigidbody.velocity.z);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            m_Rigidbody.AddForce(moveDir.normalized * speed);
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
            //controller.Move(velocity * Time.deltaTime);



        }

        if(Input.GetKey(KeyCode.Space) && grounded == true)
        {
            m_Rigidbody.AddForce(0, 750, 0);
            grounded = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
}
