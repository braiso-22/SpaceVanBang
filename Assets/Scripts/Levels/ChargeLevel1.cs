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

    void Start()
    {
        generateMiniAsteroides(0, -100f, 100f,200,-200f);

        generateMiniAsteroides(1.5f, 200f, 400f,500f,400f);
        generateMiniAsteroides(0.5f, 0, 200f,400f,200f);
        
        generateMiniAsteroides(-1.5f, 0f, 200f,-400f,-500f);
        generateMiniAsteroides(-0.5f, -100f, 100f, -200f, -400f);

    }

    float generateRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }

    // metodo para generar los mini asteroides
    void generateMiniAsteroides(float diagonal,float xInicio, float xFinal, float zInicio, float zFinal)
    {
        float counter = 0f;
        for (float i = zInicio; i > zFinal; i--)
        {

            Vector3 position = new Vector3(generateRandomNumber(xInicio - counter, xFinal - counter), generateRandomNumber(-120f, 100f), i);
            counter += diagonal;
            //  generate random rotation 
            Quaternion rotation = Quaternion.Euler(generateRandomNumber(0, 360), generateRandomNumber(0, 360), generateRandomNumber(0, 360));
            GameObject instantiatedObject = Instantiate(miniAsteroide, position, rotation);
            instantiatedObject.transform.parent = GameObject.Find("Pequeños").transform;
            if (instantiatedObject.GetComponent<InSamePosition>().getSamePosition())
            {
                Debug.Log("destruyendo");
                Destroy(instantiatedObject);
                i--;
            }
        }


    }
}
