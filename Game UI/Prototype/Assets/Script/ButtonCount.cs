using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCount : MonoBehaviour {


    public Text counterText;
    private int count = 12;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        string count1 = count.ToString();
        counterText.text = "내 카운트 횟수는" + count1;



    }

    public void Counting()
    {
        count++;
    }
}
