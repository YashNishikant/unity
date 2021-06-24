using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float playerSpeed = 800f;
    public float sideForce = 50f;
    public float upForce = 1000f;
    void Start()
    {
        
    }

    void FixedUpdate()  
    {
        rb.AddForce(0, 0, playerSpeed * Time.deltaTime);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 50);
        keyMovement();
        positionCheck();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }

    }
    void positionCheck() {

        if (rb.position.y < -5) {
            FindObjectOfType<GameManager>().endGame();
        }
        if (rb.transform.position.z >= FindObjectOfType<SpawnObstacles>().endGoalNum)
        {
            FindObjectOfType<GameManager>().endGame();
        }
    }

    void keyMovement() {

        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space)){
            rb.AddForce(0, upForce * Time.deltaTime, 0);
        }
    }

}
