using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private PlayerInputController playerInput;
    private GameObject item;


    void Awake()
    {
        playerInput = new PlayerInputController();
        playerInput.Suelo.Interactuar.performed += _ => interactuar();
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

    void interactuar()
    {
        Debug.Log("Interactuando");
        if (item != null && !GameManager.Instance.hasItem)
        {
            GameManager.Instance.hasItem = true;
            GameManager.Instance.lastItemName = item.name;
            Destroy(item);
            GameManager.Instance.itemsCollected++;
            Debug.Log("Has cogido el item" + GameManager.Instance.itemsCollected);
            item = null;
            if (GameManager.Instance.itemsCollected == GameManager.Instance.itemsToCollect)
            {
                GameManager.Instance.hasWon = true;
                Debug.Log("has ganado");
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "item")
        {
            Debug.Log("has tocado el item");
            item = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "item")
        {
            Debug.Log("has dejado el item");
            item = null;
        }
    }
}
