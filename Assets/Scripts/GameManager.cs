using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameInstance;
    private AudioManager reproductor;
    private GameManager() { }
    void Start()
    {
        gameInstance = getGameInstance();
        reproductor = gameObject.AddComponent<AudioManager>();
    }
    public GameManager getGameInstance()
    {
        if (gameInstance != null)
        {
            return gameInstance;
        }

        return gameObject.AddComponent<GameManager>();
    }

    void Update()
    {

    }
}
