using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.transform.position + offset;
        if (!FindObjectOfType<PlayerMovement>().crouch)
        {
            offset = new Vector3(0, 0.735f, 0);
        }
        else {
            offset = new Vector3(0, 0.3f, 0);
        }
    }
}
