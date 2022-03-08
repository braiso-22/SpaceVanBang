using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private PlayerInputController playerInput;
    [SerializeField] Vector2 mouseInput;
    float rotationX = 0f;
    bool mouseClicked = false;
    void Awake()
    {
        playerInput = new PlayerInputController();
        playerInput.Camara.RightClickHold.performed += _ => mouseClicked = true;
        playerInput.Camara.RightClickRelease.performed += _ => mouseClicked = false;

        playerInput.Camara.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }
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

    // Change the rotation of the camera support in base of mouseInput x
    void Update()
    {
        if (mouseClicked)
        { // Rotate on x axis with clamp
                rotationX -= mouseInput.y;
                rotationX = Mathf.Clamp(rotationX, -60f, 60f);
                transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
        else
        {
            rotationX=0;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }


}
