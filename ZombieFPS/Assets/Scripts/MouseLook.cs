using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSens = 100f;
    public Transform player;
    public float xRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (!FindObjectOfType<UI>().quitmenu)
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -70f, 89f);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            player.Rotate(Vector3.up * mouseX);

            Cursor.lockState = CursorLockMode.Locked;
        }
        else {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }
}
