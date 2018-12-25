using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CounterPhotonView : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject counterUI;
    Counter counter;

    GameObject GamePlayNetwork;
    GamePlayNetwork gamePlayNetwork;
    CounterMethods counterMethods;
    public int networkCurrentCount;
    public int networkScore;
    public int actorNumber;
    int receiveNetworkScore;
    int receiveActorNumber;

    void Start()
    {
        Init();
        networkCurrentCount = counter.remainCountSize;
        actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
    }

    void Init() {
        counterUI = GameObject.FindWithTag("CounterMethods");
        counterMethods = counterUI.GetComponent<CounterMethods>();
        counter = counterUI.GetComponent<Counter>();
        counterUI.GetComponent<CounterMethods>().Init();
        GamePlayNetwork = GameObject.FindWithTag("Network");
        gamePlayNetwork = GamePlayNetwork.GetComponent<GamePlayNetwork>();


    }

    [PunRPC]
    void _UpdateLoser(int actorNumber) {
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
        {
            if (p.actorNumber == actorNumber)
            {
                p.isLoser = true;
                break;
            }

        }
        counterUI.GetComponent<CounterMethods>().StartRankingPanel();
       
    }
    [PunRPC]
    void _ReadyToMaster(int actorNumber)
    {
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
        {
            if (p.actorNumber == actorNumber)
            {
                p.isReady = true;
                break;
            }
            
        }
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
        {
            if (!p.isReady) break;
            gamePlayNetwork.Ready();
        }
 

    }

    [PunRPC]
    void _Ready()
    {

        GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().LoadingPanel.SetActive(false);
        GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().CountdownText.SetActive(true);
        GameObject.FindWithTag("Audio").GetComponent<AudioSource>().enabled = true;
    }

    [PunRPC]
    void _Ready(int actorNumber)
    {
       
            GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().LoadingPanel.SetActive(false);
            GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().CountdownText.SetActive(true);
            GameObject.FindWithTag("Audio").GetComponent<AudioSource>().enabled = true;
        
    }
    void UpdateReceiveCount()
    {
        if (!photonView.IsMine)
        {
            counter.RemaingCount = networkCurrentCount;
        }
    }

    void UpdateReceiveScore() {
        if (!photonView.IsMine)
        {
            foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
                if (p.actorNumber == receiveActorNumber)
                {
                    p.Score = receiveNetworkScore;
                    break;
                }
        }

    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(networkCurrentCount);
            stream.SendNext(networkScore);
            stream.SendNext(actorNumber);
        }
        else if (stream.IsReading)
        {
            networkCurrentCount = (int)stream.ReceiveNext();
            receiveNetworkScore = (int)stream.ReceiveNext();
            receiveActorNumber = (int)stream.ReceiveNext();
            UpdateReceiveCount();
            UpdateReceiveScore();
            counterMethods.ShakeCount();
        }
    }
}
