using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameEnded = false;
    public bool levelWon = false;
    public float restartDelay = 1;
    public void endGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Invoke("restart", restartDelay);
        }
    }
    void restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
