﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GamePlayNetwork : MonoBehaviourPunCallbacks
{
    #region Variable
    PhotonView CounterView;
    public GameObject CounterPrefab;
    public GameObject ItemPrefab;
    Counter CounterScript;
    PhotonView ItemView;
    #endregion
    PlayerInfo[] playerInfo;
    List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();
    public TMPro.TextMeshProUGUI[] PlayerNickname;
    public TMPro.TextMeshProUGUI[] PlayerScore;
    
  
    #region ViewInstantiate

    [SerializeField]
    void CounterViewInst()
    {
        if (CounterPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color>카운터 프리팹 설정 안됬음 ", this);
        }
        else
        {
            PhotonNetwork.Instantiate("Counter", new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }
        
    }

    [SerializeField]
    void ItemViewInst()
    {
        if (ItemPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color>아이템 프리팹 설정 안됬음 ", this);
        }
        else
        {
            PhotonNetwork.Instantiate("Item", new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }
    }
    #endregion

   
    void PlayerInfoSet() {

        Debug.Log("실행은된다 InfoSet"+PhotonNetwork.PlayerList);
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Debug.Log("i : " +i +" player : "+p.NickName);
        
            PlayerNickname[i].text = p.NickName;
            PlayerScore[i].text = p.score+"";
            i++;
        }
        i = 0;

    }
    [PunRPC]
    void _UpdatePlayerScore()
    {
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            PlayerScore[i].text = p.score + "";
            i++;
        }
        i = 0;
    }
    #region RPCs
    public void UpdateCount()//다른 플레이어 카운트 숫자 동기화
    {

        int getCount = 0;
        if (CounterView.IsMine)
        {
            getCount = CounterScript.RemaingCount;

            CounterView.RPC("_UpdateCount", RpcTarget.Others, getCount);
        }
    }
    public void NetworkIce()//Ice 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkIce", RpcTarget.Others);
    }

    public void NetworkCrashBlock()//CrashBlock 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkCrashBlock", RpcTarget.Others);
    }

    public void NetworkCountPump()//CrashBlock 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID); 
        ItemView.RPC("_NetworkCountPump", RpcTarget.Others);
    }
    public void NetworkDoubleCount()//CrashBlock 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkDoubleCount", RpcTarget.Others);
    }
    public void UpdatePlayerScore()//CrashBlock 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(CounterView + "  " + CounterView.ViewID);
        CounterView.RPC("_UpdatePlayerScore", RpcTarget.All);
    }
    #endregion




    #region Behaviour
    void Awake()
    {
        Screen.SetResolution(1080 / 5, 1920 / 5, false);
    }



    void Start()
    {
        CounterScript = CounterPrefab.GetComponent<Counter>();
        CounterView = CounterPrefab.GetComponent<PhotonView>();
        ItemView = ItemPrefab.GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            CounterViewInst();
            ItemViewInst();
        }
        playerInfo = new PlayerInfo[4];
        PlayerInfoSet();

    
    }

    
    #endregion
    public void UpdateNetworkScore(int score)
    {
        PhotonNetwork.LocalPlayer.score = score;


    }

}
class PlayerInfo{
   public string playerNickname;
    int score;

    public PlayerInfo(string getName) {
        this.playerNickname = getName;
    }
        

}