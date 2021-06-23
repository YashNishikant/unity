using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public GameObject treeobj;
    public Transform player;
    public float range = 400;
    public float gravity = -19.62f;
    public float treeDistanceZ = 100;
    public float treeDistanceX = 100;
    public float treeNum = 1000;
    public GameObject zombie;
    //public GameObject grassMesh;
    List<GameObject> vegetationArray = new List<GameObject>();
    float grassNumber = 3000;
    public List<GameObject> zombieArray = new List<GameObject>();
    float delay = 0;
    bool locking;

    void Start()
    {
        randomTrees(treeNum, range);
        spawnZombies();
        
    }

    void Update()
    {
        optimize();

        delay++;
        if (delay > 2000 && !locking)
        {
            deleteDownedTargets();
            locking = true;
        }
        else {
            delay = 0;
        }
    }

    void spawnZombies() {

        for (int i = 0; i < 200; i++)
        {
            GameObject zombieObj = Instantiate(zombie) as GameObject;
            zombieObj.transform.position = new Vector3(Random.Range(-400, 400), 1, Random.Range(-400, 400));
            zombieArray.Add(zombieObj);
        }
    }

    void deleteDownedTargets(){

        for (int i = 0; i < zombieArray.Count; i++) {
            if (zombieArray[i].transform.rotation.eulerAngles.y > 30) {
                zombieArray[i].SetActive(false);
            }
        }

    }

    void optimize()
    {

        for (int i = 0; i < vegetationArray.Count; i++)
        {

            if ((Mathf.Abs(player.position.z - vegetationArray[i].transform.position.z) > treeDistanceZ) || (Mathf.Abs(player.position.x - vegetationArray[i].transform.position.x) > treeDistanceX))
            {
                vegetationArray[i].SetActive(false);
            }
            else
            {
                vegetationArray[i].SetActive(true);
            }
        }

    }

    void randomTrees(float numTrees, float range)
    {

        float randomX = 0;
        float randomZ = 0;

        float randomrotation = 0;

        for (int i = 0; i < numTrees; i++)
        {
                randomX = Random.Range(-range, range);
                randomZ = Random.Range(-range, range);
                randomrotation = Random.Range(0,360);

                GameObject treeObject = Instantiate(treeobj) as GameObject;
                treeObject.transform.position = new Vector3(randomX, 0, randomZ);
                treeObject.transform.Rotate(0f, randomrotation, 0f);
                vegetationArray.Add(treeObject);

        }

        for (int i = 0; i < grassNumber; i++) {

            randomX = Random.Range(-range, range);
            randomZ = Random.Range(-range, range);
        }

    }
}

