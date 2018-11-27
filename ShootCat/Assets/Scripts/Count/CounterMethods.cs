using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMethods : MonoBehaviour {

    public Counter counter;
    public GameObject ScorePanel;

    void Awake() {
        CounterInit();
    }

    void Update () {
        
    }

    public void CounterInit() {

        counter.RemaingCount = 300;
        counter.CountSize = 1;
        counter.YourCount = 0;
        counter.YourCountSize = 1;

    }

   public void CounterSub(){ //카운터 빼기 함수
        counter.RemaingCount-= counter.CountSize;
        counter.UpdateRemainingCountText();
    }

    public void YourCountPlus() {
        counter.YourCount += counter.YourCountSize; //버튼 누르면 이 함수를 호출 시켜서 더해줌
        counter.UpdateYourCountText();
    }

    public void ScorePanelStart() {

        ScorePanel.SetActive(true);
        while (true)
        {if (ScorePanel.transform.position.y <= 0)
                break;
            ScorePanel.transform.position -= new Vector3(0, 1, 0);
            ScorePanel.GetComponent<RectTransform>();
        }
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
            ScorePanelStart();

    }
}
