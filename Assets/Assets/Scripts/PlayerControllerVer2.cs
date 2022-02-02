using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVer2 : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform pivot;
    public Vector3 playerVelocity;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public bool isGrounded;
    public bool hasJumped;
    public bool isGliding;

    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    float turnSmoothVelocity;
    Animator my_Animator;

    void Start()
    {
        my_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Declaring inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

	    //Don't forget to add an isMoving bool inside your Animator
        my_Animator.SetBool("isMoving", isWalking);

        //Movement based on camera
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


         //declaring input for right click
            float horizontalRightClick = Input.GetAxisRaw("Fire2");
            float verticalRightClick = Input.GetAxisRaw("Fire2");
            Vector3 directionRightClick = new Vector3(horizontal, 0f, vertical).normalized;
        //Right click cam
        if (directionRightClick.magnitude >= 0.1f)
        {
            transform.LookAt(pivot);
        }


            //single jump with anti-spam built in
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                hasJumped = true;
            }

            //double jump which is only executes once
            if (Input.GetButtonDown("Jump") && hasJumped && isGrounded == false)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                hasJumped = false;
            }

            //Glide W.I.P
            if (Input.GetButton("Jump") && hasJumped == false && isGrounded == false)
            {
                gravityValue = -1.25f;
                isGliding = true;
            }
            else
            {
                isGliding = false;
                gravityValue = -9.81f;
            }


            //resets velocity so the gravity doesnt mess up
            if (isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            
            //Creates gravity for the player
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        
    }

    //sets the player to grounded if in contact with a floor gameobject

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
            hasJumped = false;
        }
    }

    //sets the player to not grounded if not in contact with a floor gameobject
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

}
