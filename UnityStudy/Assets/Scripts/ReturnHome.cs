using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : MonoBehaviour {

    void Awake()
    {

    }
    public void ReturnButton()
    {
        Invoke("returnpage", .2f);
    }
    void returnpage()
    {
        Application.LoadLevel("MainScene");
    }

}
