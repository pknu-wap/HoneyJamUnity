using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterActor : MonoBehaviour {

    public Counter counter;

    void start() {

        CounterInit();
        Debug.Log("rc: " + counter.CountSize);
        Debug.Log("yc: " + counter.YourCountSize);
    }

    void Update () {
        Debug.Log("rc: " + counter.CountSize);
        Debug.Log("yc: " + counter.YourCountSize);
    }

    public void CounterInit() {

        counter.RemaingCount = 300;
        counter.CountSize = 1;
        counter.YourCount = 0;
        counter.YourCountSize = 1;

    }

   public void CounterSub(){ //카운터 빼기 함수
int a = counter.RemaingCount- counter.CountSize; //버튼 누르면 이 함수를 호출 시켜서 빼줌
        counter.RemaingCount = a;
        counter.SetRemainingCountText();
        Debug.Log("남은 카운터 마이너스 실행중");
    }

    public void YourCountPlus() {
        int b = counter.YourCount + counter.YourCountSize; //버튼 누르면 이 함수를 호출 시켜서 더해줌
        counter.YourCount = b;

        counter.SetYourCountText();
        Debug.Log("유얼카운트 플러스 실행중");
    }
}
