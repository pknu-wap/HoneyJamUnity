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
   [Range(0,500)] 
    public int remainCountSize;

    public void CounterInit() {

        counter.RemaingCount = remainCountSize;
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

    public void DoubleCount()//카운트 두배 함수
    {
       counter.CountSize= counter.CountSize* 2;
        counter.YourCountSize = counter.YourCountSize * 2;
       
    }
    public void DivideCount()//카운트 2분의 1 함수
    {
        counter.CountSize = counter.CountSize/2;
        counter.YourCountSize = counter.YourCountSize / 2;
    }
    public void InitCount()//카운트사이즈 초기화
    {
        counter.CountSize = 1;

    }
    public void YourCountPlus() {
        counter.YourCount += counter.YourCountSize; //버튼 누르면 이 함수를 호출 시켜서 더해줌
        counter.UpdateYourCountText();
    }
}
