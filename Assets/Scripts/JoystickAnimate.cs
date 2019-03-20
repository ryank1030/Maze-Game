using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickAnimate : MonoBehaviour
{
    public float moveSpeed = 6.0F;
    public float rotateSpeed = 3.0F;
    public Joystick joystick;
    public bool logging = false;
    private Vector3 moveDirection = Vector3.zero;
    bool run = false, forward = false, right = false, left = false, back = false;

    void Update()
    {
        if (logging)
        {
            Debug.Log("Horizontal:" + joystick.Horizontal);
            Debug.Log("Vertical: " + joystick.Vertical);
        }

        CharacterController controller = GetComponent<CharacterController>();
        Animator animate = GetComponent<Animator>();


        //movement initilize
        forward = false;
        run = false;
        back = false;
        right = false;
        left = false;
        if (joystick.Vertical > .5)
        {
            run = true;
        }
        else if (joystick.Vertical > 0)
        {
            forward = true;
        }
        else if (joystick.Vertical < 0)
        {
            back = true;
        }

        if (joystick.Horizontal > .75)
        {
            right = true;
        }
        else if (joystick.Horizontal < -.75)
        {
            left = true;
        }


        //movement logic
        playerStopMovement(animate);
        if (run)
        {
            playerWalk(true, animate);
            playerRun(true, animate);
        }
        else if (forward)
        {
            playerWalk(true, animate);
        }
        else if (back)
        {
            //move player backwards
            //need animation for this
        }

        if (run && right)
        {
            playerRunRight(true, animate);
        }
        else if (run && left)
        {
            playerRunLeft(true, animate);
        }

        if (forward && right)
        {
            playerTurnRight(true, animate);
        }
        else if (forward && left)
        {
            playerTurnLeft(true, animate);
        }


    /*
        transform.Rotate(0, joystick.Horizontal * rotateSpeed, 0);
        moveDirection = new Vector3(0, 0, joystick.Vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);
    */
    }

    public void ResetPlayerLocation()
    {
        transform.position = new Vector3(35, 0, 40);
        transform.rotation = Quaternion.Euler(0, 35, 0);
    }

    private void playerWalk(bool b, Animator animate)
    {
        animate.SetBool("Walk", b);
    }

    private void playerTurnRight(bool b, Animator animate)
    {
        animate.SetBool("Turn Right", b);
    }

    private void playerTurnLeft(bool b, Animator animate)
    {
        animate.SetBool("Turn Left", b);
    }

    private void playerRun(bool b, Animator animate)
    {
        animate.SetBool("Run", b);
    }

    private void playerRunRight(bool b, Animator animate)
    {
        animate.SetBool("Run Right", true);
    }

    private void playerRunLeft(bool b, Animator animate)
    {
        animate.SetBool("Run Left", true);
    }

    private void playerStopMovement(Animator animate)
    {
        animate.SetBool("Walk", false);
        animate.SetBool("Turn Right", false);
        animate.SetBool("Turn Left", false);
        animate.SetBool("Run", false);
        animate.SetBool("Run Left", false);
        animate.SetBool("Run Right", false);
    }
}
