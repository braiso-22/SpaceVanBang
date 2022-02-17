using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private GameManager() { }


    public void changeToScene(int num)
    {

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
}
