using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterMethods : MonoBehaviour {

    [SerializeField] Counter counter;
    public GameObject block;

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

    public void CounterPlus(int plusSize)
    { //카운터 더하기 함수
        counter.RemaingCount += plusSize;
        counter.UpdateRemainingCountText();
    }

    public void CountDouble()
    {//카운트 두배 함수
        counter.RemaingCount -= counter.CountSize * 2;
        counter.YourCount+= counter.YourCountSize * 2;
        counter.UpdateRemainingCountText();
        counter.UpdateYourCountText();
    }

    public void YourCountPlus() {
        counter.YourCount += counter.YourCountSize; //버튼 누르면 이 함수를 호출 시켜서 더해줌
        counter.UpdateYourCountText();
    }
}
