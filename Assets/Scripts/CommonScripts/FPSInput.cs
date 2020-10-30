using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 15F;
    public float gravity = 1F;
    public float sensivityHor = 170F;
    private Vector3 moveDirection = Vector3.zero;
    FixedJoystick joystick;
    FixedJoystick camjoystick;
    CharacterController controller;
    Button jumpbutton;
    AudioSource audio;
   
    
    bool clicked = false;
    bool hit = false;
    bool jump = false;

    public bool block = true;
    



    void Start()
    {
        
        joystick = GameObject.Find("Joystick").GetComponent<FixedJoystick>();
        camjoystick = GameObject.Find("CameraJoystick").GetComponent<FixedJoystick>();
        controller = GetComponent<CharacterController>();
        audio = GetComponents<AudioSource>()[0];       
        jumpbutton = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpbutton.onClick.AddListener(TaskOnClick);       

    }


    void Update()
    {      

        

        if (block)
        {

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                if (new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude > 2f && audio.isPlaying == false)
                {
                    audio.volume = Random.Range(0.8f, 1);
                    audio.pitch = Random.Range(0.8f, 1.1f);
                    audio.Play();
                }
                else if (jump && audio.isPlaying == false)
                {
                    audio.volume = Random.Range(0.8f, 1);
                    audio.pitch = Random.Range(0.8f, 1.1f);
                    audio.Play();
                    jump = false;
                }

                if (clicked)
                {
                    if (moveDirection == Vector3.zero)
                    {
                        moveDirection.y = jumpSpeed;
                        clicked = false;
                        jump = true;
                    }
                    else
                    {
                        moveDirection.y = (float)(jumpSpeed / 1.1);
                        clicked = false;
                        jump = true;
                    }
                }

            }


            if (hit)
            {
                moveDirection.y = -moveDirection.y;
                hit = false;
            }
            else
            {
                moveDirection.y -= gravity;
            }

            controller.Move(moveDirection * Time.deltaTime);            
        }

        transform.Rotate(0, camjoystick.Horizontal * sensivityHor * Time.deltaTime, 0);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "ceiling")
        {
            this.hit = true;  
        }
        else if(jump && !controller.isGrounded)
        {
            moveDirection = Vector3.zero;
        }

    }

    void TaskOnClick()
    {
        clicked = true;
    }


    

}

