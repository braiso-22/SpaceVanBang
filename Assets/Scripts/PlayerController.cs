using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputController playerInput;
    private Vector2 moveInput;
    private float flyInput;

    [Header("Velocidades")]
    [SerializeField] private float walkSpeed = 5f;
    public float maxVelocity = 11f;
    [SerializeField] private float rotateSpeed = 1800f;
    private Rigidbody rb;
    Vector3 referenceVel = Vector3.zero;

    [Header("Checkeo de suelo")]
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask groundLayer;
    public bool onGravity;


    // Use this for initialization
    void Awake()
    {
        playerInput = new PlayerInputController();
        rb = GetComponent<Rigidbody>();
        playerInput.Suelo.Saltar.performed += _ => jump();
        playerInput.Suelo.Menu.performed += _ => GameManager.Instance.activarMenu();
    }

    // Start
    void Start()
    {
        // set position to the position of the game object with name "AsteroideInicio"
        transform.position = GameObject.Find("AsteroideInicio").transform.position + new Vector3(-2, 10, 0);
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
        flyInput = playerInput.SinGravedad.Propulsar.ReadValue<float>();
    }
    void FixedUpdate()
    {
        move();

        // get component children of gameobject with name mochila 
        foreach (Transform child in GameObject.Find("Mochila").transform.GetChild(0).transform)
        {
            // set child renderer to enabled
            child.gameObject.GetComponent<Renderer>().enabled = GameManager.Instance.hasPowerUp;
        }

    }
    void move()
    {
        if (onGravity)
        {
            flyInput = 0f;
            maxVelocity = 11f;
        }
        else
        {
            maxVelocity = 5f;
        }

        Vector3 forwardDirection = transform.forward * moveInput.y;
        Vector3 upDirection = transform.up * flyInput;
        // add force to the rigidbody in the direction of the player's forward vector
        rb.AddForce(forwardDirection * walkSpeed * 500f, ForceMode.Force);
        rb.AddForce(upDirection * walkSpeed * 500f, ForceMode.Force);

        // Rotacion calcula el vector de rotacion con el input y rota el rigidbody
        Quaternion rightDirection = Quaternion.Euler(0f, moveInput.x * (rotateSpeed * Time.fixedDeltaTime), 0f);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
        rb.MoveRotation(newRotation);
        // block velocity if the player is not pressing any movement keys
        if (isGrounded() && moveInput == Vector2.zero)
        {
            rb.velocity = Vector3.zero;
        }
        else if (isGrounded())
        {
            AudioManager.Instance.playWithWaitTime("Walk", 0.25f, 0.5f);
        }

        if (!onGravity && (moveInput != Vector2.zero || flyInput != 0))
        {
            AudioManager.Instance.playWithWaitTime("Propulsion", 0.15f, 0.25f);
        }
        //block velocity to a max speed of 20
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
    void jump()
    {
        if (isGrounded() && GameManager.Instance.hasPowerUp)
        {
            rb.AddForce(rb.transform.up * 1000f, ForceMode.Impulse);
        }
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, radiusCheck, groundLayer);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("gravity"))
        {
            onGravity = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("gravity"))
        {
            onGravity = false;
        }
    }


}