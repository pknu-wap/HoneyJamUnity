﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Counter : MonoBehaviourPunCallbacks
{

    public int yourCount;//플레이어가 누른 카운터 

    public Text yourCountText; //플레이어가 누른 카운터 수를 나타내는 텍스트

    private  int remainingCount;//카운터의 남은 수

    public Text remainingCountText; //카운터의 남은 수를 나타내는 텍스트

    public int RemaingCount
    {
        get { return remainingCount; }
        set
        {
            if (remainingCount < 0) Debug.Log("카운터가 0 이하로 내려갈 일이 뭐가 있을까");
            this.remainingCount = value;
        }
    }



    public int CountSize { get; set; } //카운터 가감 양(기본 1 , 아이템 따라 다름)

    public int YourCount { get; set; } //플레이어가 지금까지 누른 수

    public int YourCountSize { get; set; } //플레이어 지금까지 누른 수에 가감할 양(기본 1, 아이템 적용에 따라 다름)

    void Start()
    {
        UpdateRemainingCountText();
        UpdateYourCountText();
    }

    void Update()
    {

    }

    public void UpdateRemainingCountText()
    {
        remainingCountText.text = "Count : " + remainingCount;
    }

    public void UpdateYourCountText()
    {
        yourCountText.text = " 내 카운트 횟수는" + YourCount + "입니다";
    }

    #region PunRpc
    [PunRPC]
    void _UpdateCount(int getCount)
    {
        RemaingCount = getCount;
        UpdateRemainingCountText();//Update text
        Debug.Log("스크립트에 붙어 있는 변수 : " + RemaingCount + "지금 네트워크에 달려있는 변수 : " + getCount);

    }
    #endregion
}
