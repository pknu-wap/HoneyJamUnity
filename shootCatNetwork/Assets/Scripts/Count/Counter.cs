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
    PhotonView CounterPhotonView;
    bool isStart = false;

    [SerializeField]
    private int remainingCount;//카운터의 남은 수
    public int RemaingCount
    {
        get { return remainingCount; }
        set
        {
            this.remainingCount = value;
            Debug.Log("value:"+value);
            if (remainingCount < 0)
                GameOver();
         
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
        CounterPhotonView = this.GetComponent<PhotonView>();
        CounterUI.GetComponent<CounterMethods>().InitPrefab();

    }

    public int CountSize { get; set; } //카운터 가감 양(기본 1 , 아이템 따라 다름)
    [SerializeField]
    private int yourCount;//플레이어가 지금까지 누른 수

    public int YourCount
    {
        get { return yourCount; }
        set
        {
            Debug.Log("yourcount프로퍼티 변경중");
            this.yourCount = value;
            if (isStart)
                GamePlayNetwork.GetComponent<GamePlayNetwork>().UpdatePlayerScore();
        }
    } 

    public int YourCountSize { get; set; } //플레이어 지금까지 누른 수에 가감할 양(기본 1, 아이템 적용에 따라 다름)


    void Update() {
        _UpdatePlayerScore();

    }
    void Start()
    { 
        GamePlayNetwork = GameObject.FindWithTag("Network");
        CounterUI = GameObject.FindWithTag("CounterMethods");
        Debug.Log(CounterUI);
        CounterInit();
     
        isStart = true;
    }





    public void UpdateLocalPlayerScore() {
        PhotonNetwork.LocalPlayer.score++;
        Debug.Log("Localplayerscore: "+PhotonNetwork.LocalPlayer.score);
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
        RemaingCount = getCount;
        CounterUI.GetComponent<CounterMethods>().UpdateRemainingCountText();
        Debug.Log("스크립트에 붙어 있는 변수 : " + RemaingCount + "지금 네트워크에 달려있는 변수 : " + getCount);

    }
    [PunRPC]
    void _UpdatePlayerScore()
    {
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Debug.Log("p : " + p + " i : " + i);
            Debug.Log("pscore: "+p.score);
            GamePlayNetwork.GetComponent<GamePlayNetwork>().PlayerScore[i].text = p.score + "";
            i++;
        }
        i = 0;
    }

    #endregion
}
