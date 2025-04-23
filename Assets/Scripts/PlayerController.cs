using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour

{



    public Camera cam;
    public float gravity;
    public float walkSpeed;
    public float runSpeed;
    public float jump;
    public bool canJump = true;
    public float speedAccel;
    public float lookSpeed;
    public float lookXLimit;
    public bool canMove = true;

    public int FOV;
    public int FOVMax;
    public float FOVDelta;

    private float xRotation;
    private float xSpeed;
    private float ySpeed;
    private float moveSpeed;
    private Vector3 move = Vector3.zero;
    private CharacterController controller;
    private bool colliding = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && canMove)
        {
            if (isRunning)
            {
                // RUNNING

                // if moveSpeed is within a speedAccel range of runSpeed then make movespeed equal to runSpeed
                // if not then: if moveSpeed is greater than runSpeed subtract speedAccel
                // if not then: add speedAccel

                moveSpeed += (Mathf.Abs(moveSpeed - runSpeed) <= speedAccel) ? -(moveSpeed - runSpeed) : (moveSpeed > runSpeed) ? -speedAccel : speedAccel;

                xSpeed = Input.GetAxis("Horizontal") * moveSpeed;
                ySpeed = Input.GetAxis("Vertical") * moveSpeed;
            }
            else
            {
                // WALKING
                
                // if moveSpeed is within a speedAccel range of walkSpeed then make movespeed equal to walkSpeed
                // if not then: if moveSpeed is greater than walkSpeed subtract speedAccel
                // if not then: add speedAccel

                moveSpeed += (Mathf.Abs(moveSpeed - walkSpeed) <= speedAccel) ? -(moveSpeed - walkSpeed) : (moveSpeed > walkSpeed) ? -speedAccel : speedAccel;

                xSpeed = Input.GetAxis("Horizontal") * moveSpeed;
                ySpeed = Input.GetAxis("Vertical") * moveSpeed;
            }
        }
        else
        {
            // NOT INPUTTING

            xSpeed += (xSpeed <= speedAccel) ? -xSpeed : (xSpeed > speedAccel) ? -speedAccel : speedAccel;
            ySpeed += (ySpeed <= speedAccel) ? -ySpeed : (ySpeed > speedAccel) ? -speedAccel : speedAccel;
        }

        float movementDirectionY = move.y;

        move = (forward * ySpeed) + (right * xSpeed);

        if (Input.GetButtonDown("Jump") && canMove && controller.isGrounded && canJump)
        {
            move.y = jump;
        }
        else
        {
            move.y = movementDirectionY;
        }

        if (!controller.isGrounded)
        {
            move.y -= gravity * Time.deltaTime;
        }

        //move.x = Input.GetAxis("Horizontal") * moveSpeed;
        //move.z = Input.GetAxis("Vertical") * moveSpeed;
        controller.Move(move * Time.deltaTime);

        if (canMove)
        {
            xRotation += -Input.GetAxis("Mouse Y") * lookSpeed;
            xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }


        if (isRunning && (xSpeed != 0 || ySpeed != 0))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, FOVMax, FOVDelta);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, FOV, FOVDelta);
        }
    }

    public bool isColliding()
    {
        return colliding;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
    }
}