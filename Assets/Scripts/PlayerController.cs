using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputController playerInput;
    private Vector2 moveInput;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float rotateSpeed = 1800f;
    private Rigidbody rb;
    Vector3 referenceVel = Vector3.zero;

    // Use this for initialization
    void Awake()
    {
        playerInput = new PlayerInputController();
        rb = GetComponent<Rigidbody>();
        playerInput.Suelo.Saltar.performed += _ => jump();
        playerInput.Suelo.Saltar.canceled += _ => stopJump();

    }

    // OnEnable and OnDisable methods are called when the gameObject is enabled and disabled
    void OnEnable()
    {
        // Subscribe to the events of the player input controller
        playerInput.Enable();
    }

    void OnDisable()
    {
        // Unsubscribe from the events of the player input controller
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.Suelo.Mover.ReadValue<Vector2>();

    }
    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        Vector3 direction = transform.forward * moveInput.y;
        // add force to the rigidbody in the direction of the player's forward vector
        rb.AddForce(direction * walkSpeed * 500f, ForceMode.Force);

        Quaternion rightDirection = Quaternion.Euler(0f, moveInput.x * (rotateSpeed * Time.fixedDeltaTime), 0f);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
        rb.MoveRotation(newRotation);

        // Vector3 targetVelocity = new Vector2(moveInput.y * 10f, rb.velocity.z);
        // rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref referenceVel, 0.05f);


        // block velocity if the player is not pressing any movement keys
        if (isGrounded() && moveInput.x == 0 && moveInput.y == 0)
        {
            rb.velocity = Vector3.zero;
        }
    }
    void jump()
    {
        if (isGrounded())
        {
            rb.AddForce(rb.transform.up * 1000f, ForceMode.Impulse);
        }
    }
    void stopJump()
    {
        rb.AddForce(rb.transform.up * -1000f, ForceMode.Impulse);
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -rb.transform.up, 1.2f);
    }

}