using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeLevel1 : MonoBehaviour
{
    public GameObject miniAsteroide;
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

    void Start(){
        for (int i = -200; i < 200; i++)
        {
            Vector3 position = new Vector3(generateRandomNumber(-100f,100f), generateRandomNumber(-100f,100f), i);
            GameObject instantiatedObject = Instantiate(miniAsteroide, position, Quaternion.identity);

            if (instantiatedObject.GetComponent<InSamePosition>().getSamePosition())
            {
                Debug.Log("destruyendo");
                Destroy(instantiatedObject);
                i--;
            }
        }
    }

    float generateRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }
}
