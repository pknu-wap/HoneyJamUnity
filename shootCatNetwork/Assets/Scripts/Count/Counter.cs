using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Counter : MonoBehaviourPunCallbacks
{
    GameObject GamePlayNetwork;
    GameObject CounterUI;

    bool isStart = false;


    private int remainingCount;//카운터의 남은 수
    public int RemaingCount
    {
        get { return remainingCount; }
        set
        {
            if (remainingCount < 0)
                GameOver();
            this.remainingCount = value;
            if (isStart)
            {
                CounterUI.GetComponent<CounterMethods>().UpdateRemainingCountText();
                CounterUI.GetComponent<CounterMethods>().UpdateYourCountText();
            }
            
        }
    }

    [Range(0, 500)]
    public int remainCountSize;
    public void CounterInit()
    {
        RemaingCount = remainCountSize;
        CountSize = 1;
        YourCount = 0;
        YourCountSize = 1;
        Debug.Log("ㅁㄴㄹㅇㅁㅇ"+YourCountSize);

        CounterUI.GetComponent<CounterMethods>().InitPrefab();

    }

    public int CountSize { get; set; } //카운터 가감 양(기본 1 , 아이템 따라 다름)

    private int yourCount;//플레이어가 지금까지 누른 수

    public int YourCount
    {
        get { return yourCount; }
        set
        {
            this.yourCount = value;
            if (isStart)
            GamePlayNetwork.GetComponent<GamePlayNetwork>().UpdatePlayerScore();
        }
    } 

    public int YourCountSize { get; set; } //플레이어 지금까지 누른 수에 가감할 양(기본 1, 아이템 적용에 따라 다름)


    void Update() {

      
    }
    void Start()
    { 
        GamePlayNetwork = GameObject.FindWithTag("Network");
        CounterUI = GameObject.FindWithTag("CounterMethods");
        Debug.Log(CounterUI);
        CounterInit();
     
        isStart = true;
    }

    

   



    public void GameOver()
    {
        Debug.Log("remainCount " + remainingCount);
  /*      RakingBoardPanel.SetActive(true)*/;


    }
    #region PunRpc
    [PunRPC]
    void _UpdateCount(int getCount)
    {
        Debug.Log("스크립트에 붙어 있는 변수 : " + RemaingCount + "지금 네트워크에 달려있는 변수 : " + getCount);
        RemaingCount = getCount;
  
    }


    #endregion
}
