using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public GameObject test;
    public Vector3 objPos;
    GameObject woodWall;
    public bool toggle;
    public float buildDistanceX = 100;
    public float buildDistanceZ = 100;
    public float delay = 30f;
    public float timer = 0f;
    public float delayKey = 0f;
    List<GameObject> buildList = new List<GameObject>();
    float wallGravity = -19.62f;
    RaycastHit hit;

    void FixedUpdate(){
        raycasting();
        renderBlocks();
        buildControls();
    }

    void raycasting() {

        objPos = new Vector3((transform.position.x), (transform.position.y), (transform.position.z));

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5)){
            test.transform.position = hit.point;
        }
        else{
            test.transform.position = objPos + transform.TransformDirection(Vector3.forward).normalized * 5;
        }

    }
    
    void buildControls() {

        timer++;
        if (timer > 2*delay) {
            timer = delay+1;
        }

        if (Input.GetKey(KeyCode.B) && delayKey > 20){
            toggle = !toggle;
            delayKey = 0;
        }
        delayKey++;
        if (delayKey > 30) {
            delayKey = 21;
        }

        if (Input.GetMouseButtonDown(0) && toggle && timer > delay){
            timer = 0;

            woodWall = Instantiate(test) as GameObject;
            woodWall.layer = 0;
            buildList.Add(woodWall);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && toggle)
        {
            woodWall.transform.position += transform.TransformDirection(Vector3.forward).normalized * 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && toggle)
        {
            woodWall.transform.position += transform.TransformDirection(Vector3.forward).normalized * -1;
        }
        if (Input.GetMouseButton(1) && toggle)
        {
            woodWall.transform.Rotate(0, 1, 0);
        }

    }
    void renderBlocks() {

        for (int i = 0; i < buildList.Count; i++)
        {
            if ((Mathf.Abs(buildList[i].transform.position.z - buildList[i].transform.position.z) > buildDistanceZ) || (Mathf.Abs(buildList[i].transform.position.x - buildList[i].transform.position.x) > buildDistanceX))
            {
                buildList[i].SetActive(false);
            }
            else
            {
                buildList[i].SetActive(true);
            }

            if (buildList[i].transform.position.y > 0) {
                buildList[i].transform.position += new Vector3(0, wallGravity / 80 , 0);

            }

        }

    }

}
