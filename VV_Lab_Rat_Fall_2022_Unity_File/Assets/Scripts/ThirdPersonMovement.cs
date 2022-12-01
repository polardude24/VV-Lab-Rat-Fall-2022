using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    //public CharacterController controller;
    Rigidbody m_Rigidbody;
    public Transform cam;

    public float speed = 6f;
    public float Jumpspeed = 6f;
    public float Groundspeed = 6f;
    public float gravity = -9.81f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float speedLimiter = 10.0f;

    public bool isKilled = false;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool grounded = false;
    public float jumpForce= 0f;

    Rigidbody rb;


    Vector3 velocity;

    void Start()
    {
        jumpForce = fallMultiplier * 300;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = 5;
        

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        if (isKilled)
        {
            speed = 0;
        }
        else if (grounded == false && fallMultiplier > 2.5)
        {
            speed = Jumpspeed;
        }
        else
        {
            speed = Groundspeed;
        }


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

            if(m_Rigidbody.velocity.magnitude < speedLimiter)
                m_Rigidbody.AddForce(moveDir.normalized * speed);
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);

            //controller.Move(velocity * Time.deltaTime);



        }

        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            m_Rigidbody.AddForce(0, jumpForce, 0);
            grounded = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
}


