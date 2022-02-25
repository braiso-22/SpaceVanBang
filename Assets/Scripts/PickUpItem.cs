using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "item")
        {
            if(!GameManager.Instance.hasItem){
                GameManager.Instance.hasItem = true;
                GameManager.Instance.lastItemName = collider.gameObject.name;
                Destroy(collider.gameObject);
                GameManager.Instance.itemsCollected++;
                Debug.Log("Has cogido el item"+GameManager.Instance.itemsCollected);
                if(GameManager.Instance.itemsCollected == GameManager.Instance.itemsToCollect){
                    GameManager.Instance.hasWon = true;
                    Debug.Log("has ganado");
                }
            }
        }
    }
}
