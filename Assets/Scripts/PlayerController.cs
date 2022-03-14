using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviourPunCallbacks
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    private Animator anim;
    PhotonView Pv;

    int SpeedHash;

    Transform groundDetector;
    float distanceFromGround;
    float distanceFromGroundOnJumping;
    public LayerMask layerMask;
    bool isJumping;
    public float timer = 0.1f;
    private void Awake()
    {
        Pv = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (Pv.IsMine)
        {
            isJumping = false;
            characterController = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SpeedHash = Animator.StringToHash("Speed");
        }
        else
        {
            playerCamera.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Pv.IsMine)
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        distanceFromGroundOnJumping = DistanceFromGround();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            isJumping = true;
            anim.SetBool("Grounded", false);
            moveDirection.y = jumpSpeed;
            anim.SetBool("Jump", true);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (DistanceFromGround() <= 1f)
        {
            anim.SetBool("Grounded", true);
        }


        if (isJumping)
        {
            ResetTimer();
        }
        if (isJumping == false && characterController.isGrounded)
        {

        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            if (isRunning)
            {
                anim.SetFloat(SpeedHash, runningSpeed);
            }
            else
            {
                anim.SetFloat(SpeedHash, walkingSpeed);
            }
        }
        else
        {
            anim.SetFloat(SpeedHash, 0);
        }


        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
    bool Grounded()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, distanceFromGround, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return false;
        }
    }

    float DistanceFromGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return hit.distance;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return 0.0f;
        }
    }
    void ResetTimer()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.1f;
            anim.SetBool("Jump", false);
            isJumping = false;
        }
    }
}
