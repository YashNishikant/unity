using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public GameObject treeobj;
    public GameObject treeobj2;
    public Transform player;
    public float range = 400;
    public float treeDistanceZ = 100;
    public float treeDistanceX = 100;
    public float treeNum = 5000;
    int treeType = 0;
    List<GameObject> treeArray = new List<GameObject>();

    void Start() {
        randomTrees(treeNum, range);
    }

    void Update() {
        optimize();
    }
    void optimize() {

        for (int i = 0; i < treeArray.Count; i++)
        {

            if ((Mathf.Abs(player.position.z - treeArray[i].transform.position.z) > treeDistanceZ) || (Mathf.Abs(player.position.x - treeArray[i].transform.position.x) > treeDistanceX))
            {
                treeArray[i].SetActive(false);
            }
            else
            {
                treeArray[i].SetActive(true);
            }
        }

    }

    void randomTrees(float numTrees, float range) {

        float randomX = 0;
        float randomZ = 0;

        for (int i = 0; i < numTrees; i++)
        {
            randomX = Random.Range(-range, range);
            randomZ = Random.Range(-range, range);

            treeType = Random.Range(1, 3);

            if (treeType == 1) {
                randomX = Random.Range(-range, range);
                randomZ = Random.Range(-range, range);
                
                GameObject treeObject = Instantiate(treeobj) as GameObject;
                treeObject.transform.position = new Vector3(randomX, 0, randomZ);
                treeArray.Add(treeObject);
            }
            if (treeType == 2) {
                randomX = Random.Range(-range, range);
                randomZ = Random.Range(-range, range);
                
                GameObject treeObject2 = Instantiate(treeobj2) as GameObject;
                treeObject2.transform.position = new Vector3(randomX, 0, randomZ);
                treeArray.Add(treeObject2);
            }
        }
    }
}
