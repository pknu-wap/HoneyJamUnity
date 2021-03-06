﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Counter : MonoBehaviourPunCallbacks
{
    GameObject GamePlayNetwork;
    GameObject CounterUI;
    PhotonView CounterPhotonView;
    public GameObject Fish;
    bool isStart = false;

    [SerializeField]
    private int remainingCount;//카운터의 남은 수
    [Range(0, 500)]
    public int TwoScoreCount;//점수 2 주는 카운터 제한
    [Range(0, 500)]
    public int TenScoreCount;//점수 10 주는 카운터 제한

    public int RemaingCount
    {
        get { return remainingCount; }
        set
        {
            this.remainingCount = value;


            if (RemaingCount >= TenScoreCount)
                InitCountMethod();
            if (TenScoreCount < RemaingCount && RemaingCount <= TwoScoreCount)
                TwoScoreCountMethod();


            if (RemaingCount <= TenScoreCount) 
                TenScoreCountMethod();
            
          
            if (remainingCount <= 0)
            {
                isStart = false;
                GamePlayNetwork.GetComponent<GamePlayNetwork>().LocalPlayer.isLoser = true;
                GamePlayNetwork.GetComponent<GamePlayNetwork>().UpdateLoser();
                GameOver();
            }
            if (isStart)
                CounterUI.GetComponent<CounterMethods>().UpdateRemainingCountText();
        }
    }
    #region 카운터 수에 따라 동작하는 메소드
    void TwoScoreCountMethod()
    {
        YourCountSize = 2;
        CounterUI.GetComponent<CounterMethods>().Changeimg(50);
    }
    void TenScoreCountMethod()
    {
        YourCountSize = 10;
        CounterUI.GetComponent<CounterMethods>().Changeimg(10);
        CounterUI.GetComponent<CounterMethods>().HideCount();
    }
    void InitCountMethod() {
        CounterUI.GetComponent<CounterMethods>().Changeimg(100);
        CounterUI.GetComponent<CounterMethods>().ActiveCount();
    }
    #endregion
    public int YourCount
    {
        get { return yourCount; }
        set
        {
            this.yourCount = value;
            if (isStart)
            {
                CounterUI.GetComponent<CounterMethods>().UpdateSendScore();
                CounterUI.GetComponent<CounterMethods>().UpdateYourCountText();
                CounterUI.GetComponent<CounterMethods>().UpdateLocalScoreText();
            }
        }
    }   void Update()
    {
    }

    [Range(0, 500)]
    public int remainCountSize;
    public void CounterInit()
    {
        RemaingCount = remainCountSize;
        CountSize = 1;
        YourCount = 0;
        YourCountSize = 1;
    }

    public int CountSize { get; set; } //카운터 가감 양(기본 1 , 아이템 따라 다름)
    [SerializeField]
    private int yourCount;//플레이어가 지금까지 누른 수



    public int YourCountSize { get; set; } //플레이어 지금까지 누른 수에 가감할 양(기본 1, 아이템 적용에 따라 다름)

    void Start()
    {

        GamePlayNetwork = GameObject.FindWithTag("Network");
        CounterUI = GameObject.FindWithTag("CounterMethods");

        CounterInit();

        isStart = true;
        CounterUI.GetComponent<CounterMethods>().UpdateRemainingCountText();
    }
    public void GameOver()
    {
        Fish.SetActive(false);
        CounterUI.GetComponent<CounterMethods>().StartRankingPanel();
        Debug.Log("remainCount " + remainingCount);
       
    }

}
