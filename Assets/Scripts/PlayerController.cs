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

    // Use this for initialization
    void Awake()
    {
        playerInput = new PlayerInputController();
        rb = GetComponent<Rigidbody>();
        playerInput.Suelo.Saltar.performed += _ => jump();

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
        jump();
    }

    void move()
    {

        Vector3 direction = transform.forward * moveInput.y;
        rb.MovePosition(rb.position + direction * (runSpeed * Time.deltaTime));

        Quaternion rightDirection = Quaternion.Euler(0f, moveInput.x * (rotateSpeed * Time.fixedDeltaTime), 0f);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
        rb.MoveRotation(newRotation);

    }
    void jump()
    {
        if (isGrounded())
        {
            rb.AddForce(Vector3.up * 1000f, ForceMode.Impulse);
        }

    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }


}
