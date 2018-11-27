using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    void Awake()
    {

    }
    public void ExitButton()
    {
        Invoke("exitpage", .2f);
    }
    void exitpage()
    {
        Application.Quit();
    }


}
