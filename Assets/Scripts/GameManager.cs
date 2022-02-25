using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    void onAwake(){
        instance = this;
        DontDestroyOnLoad(this);
    }

    [Header("Items")]
    public int itemsToCollect;
    [SerializeField] public int itemsCollected;
    public bool hasItem;
    public string lastItemName = "";

    [Header("game")]
    public bool hasWon;
    public bool gameOver;

    public void changeToScene(int num)
    {
        hasWon = false;
        gameOver = false;
        StartCoroutine(changeRoutine(num));
    }
    IEnumerator changeRoutine(int num)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(num);
    }
    public void exitGame()
    {
        Debug.Log("salir");
        Application.Quit();
    }

    public void restartGame()
    {
        Debug.Log("reiniciar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
