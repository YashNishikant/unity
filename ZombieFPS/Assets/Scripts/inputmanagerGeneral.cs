using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inputmanagerGeneral : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FindObjectOfType<UI>().quitmenu = !FindObjectOfType<UI>().quitmenu;
        }
    }
}
