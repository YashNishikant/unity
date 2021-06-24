
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text score;
    void Update()
    {
        if (player.transform.position.z < FindObjectOfType<SpawnObstacles>().endGoalNum)
        {
            score.text = "" + (int)player.position.z;
        }
        else
        {
            score.text = "YOU WIN!";
            FindObjectOfType<GameManager>().levelWon = true;
        }
        if (FindObjectOfType<GameManager>().gameEnded && player.transform.position.z < FindObjectOfType<SpawnObstacles>().endGoalNum) {

            score.text = "YOU LOSE!";
            FindObjectOfType<GameManager>().levelWon = false;
        }
    }
}
