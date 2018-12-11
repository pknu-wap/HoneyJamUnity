using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingBoard : MonoBehaviour {

    public GameObject RankingPanel;
    public GameObject MainPanel;

    void Start()
    {
        RankingBoardShow();
    }
     void Update () {
		
	}
    void RankingBoardShow() {
        while (true) { 
        RankingPanel.transform.position -= new Vector3(0,1, 0);
            if (RankingPanel.transform.position.y<= MainPanel.transform.position.y)
                break;
        }
    }
}
