using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartCount : MonoBehaviour {
    private int Timer = 0;
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject START;

	// Use this for initialization
	void Start () {

        Timer = 0;
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
        START.SetActive(false);


		
	}
	
	// Update is called once per frame
	void Update () {

        if (Timer == 0)
        { //게임 시작시에 정지
            Time.timeScale = 0.0f;
        }

        if(Timer<=90)
        {
            Timer++;
            if (Timer < 30)
            {
                three.SetActive(true);
            }

            if(Timer>30)
            {
                three.SetActive(false);
                two.SetActive(true);
            }
            if (Timer > 60)
            {
                two.SetActive(false);
                one.SetActive(true);
            }

            if (Timer >= 90)
            {
                one.SetActive(false);
                START.SetActive(true);
                Time.timeScale = 1.0f;
            }


        }


	}
}
