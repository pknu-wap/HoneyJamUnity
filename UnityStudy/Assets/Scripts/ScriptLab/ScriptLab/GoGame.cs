using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGame : MonoBehaviour {

    void Awake()
    {

    }
    public void StartButton()
    {
        Invoke("startpage", .2f);
    }
    void startpage()
    {
        Application.LoadLevel("GameScene");
    }

}
