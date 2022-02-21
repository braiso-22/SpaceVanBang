using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputController playerInput;
    private Vector2 input;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float rotateSpeed = 900f;
    private Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        playerInput = new PlayerInputController();
        rb = GetComponent<Rigidbody>();

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
        input = playerInput.Suelo.Mover.ReadValue<Vector2>();

    }
    void FixedUpdate()
    {
        move();
    }

    void move()
    {

        Vector3 direction = transform.forward * input.y;
        rb.MovePosition(rb.position + direction * (runSpeed * Time.deltaTime));

        Quaternion rightDirection = Quaternion.Euler(0f, input.x * (rotateSpeed * Time.fixedDeltaTime), 0f);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
        rb.MoveRotation(newRotation);

    }


}
