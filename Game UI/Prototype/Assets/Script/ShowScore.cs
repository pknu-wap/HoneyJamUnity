using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour {

    public GameObject ScoreBoard;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScoreBoardSetActive()
    {
        ScoreBoard.SetActive(!ScoreBoard.active);
    }
}
