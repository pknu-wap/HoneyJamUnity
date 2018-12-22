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
        }
    }
}
