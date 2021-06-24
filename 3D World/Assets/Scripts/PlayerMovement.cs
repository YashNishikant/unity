using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController controller;
    Vector3 velocity;
    bool hitGround = false;
    public float gravity = -19.62f;
    public Transform groundcheck;
    public float GroundDistance;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public bool crouch = false;
    public float distToGround = 2f;
    public Transform Terrain;
    public float angle;
    public Vector3 offsetRaycast;
    void FixedUpdate()
    {
        playerMovement();
        playergravity();

    }

    void playerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;



        if (hitGround && Input.GetKey(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (hitGround && Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = true;
            controller.transform.localScale = new Vector3(0.5f, 0.7f, 0.5f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            controller.transform.localScale = new Vector3(1, 1, 1);
            crouch = false;
        }

        if (!crouch) { 
            controller.Move(move * speed * Time.deltaTime);
        }
        else{
            controller.Move(move * speed/3 * Time.deltaTime);
        }

        hitGround = Physics.Raycast(transform.position, Vector3.down, distToGround*1.5f + 0.1f);

    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        angle = Vector3.Angle(Vector3.up, hit.normal);
    }

    void playergravity() {

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (hitGround)
        {
            velocity.y = 0;
        }
    
    }
}
