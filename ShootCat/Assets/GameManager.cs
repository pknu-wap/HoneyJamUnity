using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class GameManager : MonoBehaviourPunCallbacks
{
    bool isLoad = false;
    void Start () {
	}
	
	void Update () {
	}
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
  public  void LoadArena()
    {
        isLoad = true;
       
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("LoadArena");
        if (isLoad)
        {
            PhotonNetwork.LoadLevel("GamePlay");
        }
       
    }
    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects
    }
    public void GameStart()
    {
        ////ItemView.ViewID = ItemViewID;
        //Debug.Log(CounterView + "  " + CounterView.ViewID);
        //CounterView.RPC("_UpdatePlayerScore", RpcTarget.Others);
    }
}
