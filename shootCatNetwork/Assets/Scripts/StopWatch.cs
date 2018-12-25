using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour {
    public GameObject StartCount;
    public int timeLimit;
    public Text limitText;

	// Use this for initialization
	void Start () {
        string a = timeLimit.ToString();
        limitText.text = a;
		
	}
	
	// Update is called once per frame
	void Update () {
        
            int t = timeLimit - (int)Time.time;
            string b = t.ToString();

            limitText.text = "남은 시간" + b;

        
	}
}
