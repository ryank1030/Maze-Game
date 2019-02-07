using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float rotateSpeed = 3.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up);
        //transform.Translate(Vector3.up);
        
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            Debug.Log(moveDirection.ToString());
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
      
    }
}
