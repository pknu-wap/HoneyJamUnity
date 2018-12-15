using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*이 스크립트에서 카운터 안에 있는 숫자들 텍스트로 나타내고 덧셈 뺼샘등의 메소드를 관리한다*/
public class CounterMethods : MonoBehaviour
{
    [SerializeField]
    GameObject CounterPrefab;
    public  Counter counter;

    public Text yourCountText; //플레이어가 누른 카운터 수를 나타내는 텍스트

    public Text remainingCountText; //카운터의 남은 수를 나타내는 텍스트
  
    public GameObject block;
    public void UpdateSendCount()
    {
       if( CounterPrefab.GetComponent<PhotonView>().IsMine)
            CounterPrefab.GetComponent<CounterPhotonView>().networkCurrentCount = counter.RemaingCount;
        
    }
    void Start() {
   
    }

    public void Init() {
        CounterPrefab = GameObject.FindWithTag("CounterPhotonView");
    }
    public void CounterSub()
    { 
        counter.RemaingCount -= counter.CountSize;
        UpdateSendCount();
     
    }

    public void CounterPlus(int plusSize)
    { 
        counter.RemaingCount += plusSize;

    }

    public void DoubleCount()//카운트 두배 함수
    {
        counter.CountSize = counter.CountSize * 2;
        counter.YourCountSize = counter.YourCountSize * 2;

    }
    public void DivideCount()//카운트 2분의 1 함수
    {
        counter.CountSize = counter.CountSize / 2;
        counter.YourCountSize = counter.YourCountSize / 2;
    }
    public void InitCount()//카운트사이즈 초기화
    {
        counter.CountSize = 1;

    }
    public void YourCountPlus() {
       
        counter.YourCount += counter.YourCountSize; //버튼 누르면 이 함수를 호출 시켜서 더해줌
     
    }
    public void UpdateRemainingCountText()
    {
        remainingCountText.text = "Count : " + counter.RemaingCount;
    }

    public void UpdateYourCountText()
    {
        yourCountText.text = " 내 카운트 횟수는" + counter.YourCount + "입니다";
    }
}
