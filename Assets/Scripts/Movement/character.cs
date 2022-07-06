using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public CharacterController controller;

    public PlayerData playerdatas;
    public AudioSource EE;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.T)&& Input.GetKeyDown(KeyCode.Y) && Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.W))
        {
            EE.Play();
        }

        
    
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Door")
        {
            if(playerdatas.keycollected == true)
            {
                DoorControl doorcontrol = other.GetComponent<DoorControl>();
                doorcontrol.Open();
                Debug.Log("door is triggered ");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            DoorControl doorcontrol = other.GetComponent<DoorControl>();
            doorcontrol.Close();
            Debug.Log("door is triggered ");
        }
    }

}

