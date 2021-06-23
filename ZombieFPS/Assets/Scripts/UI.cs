using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Transform Player;
    public Text coords;
    string status;
    public int score = 0;
    public Text ScoreTxt;
    public bool quitmenu = false;
    public Button quitbutton;
    public Text quitbuttontext;
    public Text TargetsHit;
    void Update()
    {

        if (!quitmenu)
        {
            coords.text = (int)Player.position.x + ", " + (int)Player.position.y + ", " + (int)Player.position.z;
            ScoreTxt.text = "" + score;
            quitbutton.image.enabled = false;
            quitbuttontext.enabled = false;
            coords.enabled = true;
            ScoreTxt.enabled = true;
            TargetsHit.enabled = true;
        }
        else {
            quitbutton.image.enabled = true;
            coords.enabled = false;
            ScoreTxt.enabled = false;
            quitbuttontext.enabled = true;
            TargetsHit.enabled = false;
        }
    }
}
