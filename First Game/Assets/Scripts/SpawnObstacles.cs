using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public float spacingX = 0;
    public float spacingZ = 50;
    public int objCount = 0;
    public int frequency = 75;
    public float endGoalNum = 0;
    List<GameObject> blockArr = new List<GameObject>();
    void Start()
    {
        spawnAllObjects(1);
    }

    void Update()
    {
        if (FindObjectOfType<GameManager>().levelWon)
        {
            deleteAllObjects();
            //spawnAllObjects(1);
            FindObjectOfType<GameManager>().levelWon = false;
        }

    }

    int spawnObject(float randomX, float randomZ) {
        
        GameObject a = Instantiate(obstacle) as GameObject;
        a.transform.position = new Vector3(spacingX, 1, spacingZ);
        blockArr.Add(a);

        spacingX = randomX;
        spacingZ += randomZ;
        objCount++;
        return objCount;
    }

    void deleteAllObjects() {

        for (int i = blockArr.Count-1; i > 0; i--) {
            blockArr.RemoveAt(i);

        }

    }

    void spawnAllObjects(int max) {
        resetObjSpawnVars();
        while (objCount < max)
        {
            objCount = spawnObject(Random.Range(-4, 4), Random.Range(1, frequency));
        }
        endGoalNum = blockArr[blockArr.Count - 1].transform.position.z + 10;
    }

    void resetObjSpawnVars() {
        spacingX = 0;
        spacingZ = 50;
        objCount = 0;
    }
}
