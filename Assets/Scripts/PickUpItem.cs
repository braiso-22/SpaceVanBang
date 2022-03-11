using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject almacen;
    private bool enAlmacen;
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

        if (enAlmacen && GameManager.Instance.hasItem)
        {
            AudioManager.Instance.Play("ThrowItem");
            GameManager.Instance.hasItem = false;
            GameManager.Instance.itemsCollected++;
            GameManager.Instance.activarTutorial();
            Debug.Log("Has recuperado" + GameManager.Instance.itemsCollected +
             "/" + GameManager.Instance.itemsToCollect);
            if (GameManager.Instance.itemsCollected == GameManager.Instance.itemsToCollect)
            {
                GameManager.Instance.Win();
            }
        }
        else if (item != null && item.name.Equals("MochilaItem"))
        {
            AudioManager.Instance.Play("PickItem");
            // set hasPowerUp to true and destroy the item
            Debug.Log("Mochila");
            GameManager.Instance.hasPowerUp = true;
            Destroy(item);
            item = null;

        }
        else if (item != null && !GameManager.Instance.hasItem)
        {
            GameManager.Instance.activarTutorial();
            AudioManager.Instance.Play("PickItem");
            GameManager.Instance.hasItem = true;
            GameManager.Instance.lastItemName = item.name;
            Destroy(item);
            item = null;
            Debug.Log("Has cogido" + (GameManager.Instance.itemsCollected + 1) +
             "/" + GameManager.Instance.itemsToCollect);

        }
        else if (item != null && GameManager.Instance.hasItem)
        {
            Debug.Log("Ya tienes un item");
        }
        else
        {
            Debug.Log("No hay nada");
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "item")
        {
            Debug.Log("has tocado el item: " + collider.gameObject.name);
            item = collider.gameObject;
        }
        if (collider.gameObject.tag == "Almacen")
        {
            Debug.Log("Tocando el almacen: " + collider.gameObject.name);
            enAlmacen = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "item")
        {
            Debug.Log("has dejado el item");

        }
        if (collider.gameObject.tag == "Almacen")
        {
            Debug.Log("Has dejado el almacen: " + collider.gameObject.name);
            enAlmacen = false;
        }
    }
}
