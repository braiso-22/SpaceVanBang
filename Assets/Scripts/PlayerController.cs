using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputController playerInput;
    private Rigidbody rb;
    private float playerSpeed = 6;
    private float jumpForce = 100000;
    private float jumpSpeed = 20;

    private void Awake()
    {
        playerInput = new PlayerInputController();
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log(rb);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput.Suelo.Saltar.performed += _ => Saltar();
    }

    private void Saltar()
    {
        Debug.Log("jumpSpeed");
        rb.AddForce(transform.up * jumpForce * jumpSpeed * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        // Lee el input de movimiento y lo printea por debug
        Vector2 movementInput = playerInput.Suelo.Mover.ReadValue<Vector2>();
        Debug.Log(movementInput);

        // Efectua el movimiento
        Vector3 movi = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(movi * Time.deltaTime * playerSpeed);
    }
}
