using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public float moveSpeed = 6.0F;
    public float rotateSpeed = 3.0F;
    public Joystick joystick;
    public bool logging = false;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        if (logging)
        {
            Debug.Log("Horizontal:" + joystick.Horizontal);
            Debug.Log("Vertical: " + joystick.Vertical);
            Debug.Log(moveDirection.ToString());
        }

        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, joystick.Horizontal * rotateSpeed, 0);
        moveDirection = new Vector3(0, 0, joystick.Vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
