using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimate : MonoBehaviour {

    public GameObject Button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void MoveToPush()
    {
        iTween.MoveTo(Button, iTween.Hash("y", -560, "time", 0.2f, "islocal", true, "oncompletetarget", Button, "oncomplete", "Back"));

        Debug.Log("ㅇㅂㅈ압쟁");
    }

    private void Back()
    {
        iTween.MoveTo(Button, iTween.Hash("y", -538, "time", 0.2f, "islocal", true));
    }
}
