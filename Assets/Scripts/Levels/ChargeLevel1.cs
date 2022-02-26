using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeLevel1 : MonoBehaviour
{
    void Awake()
    {
        // get all game objects with the tag "gravity"
        GameObject[] gravityObjects = GameObject.FindGameObjectsWithTag("gravity");

        // for each game object
        foreach (GameObject gravityObject in gravityObjects)
        {
            Vector3 position = gravityObject.transform.position;
            // set position 
            position = new Vector3(generateRandomNumber(-45f, 45f), generateRandomNumber(-35f, 35f), position.z);
            gravityObject.transform.position = position;
        }
    }

    float generateRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }
}
