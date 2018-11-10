using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RPCs : MonoBehaviourPunCallbacks
{
    public CounterManager Counter;
    int count;
    GameObject CounterPun;
    public PhotonView photonView;
    #region RPC
    public void CountSend()
    {
        photonView.RPC(nameof(_CountSend), RpcTarget.All);
    }

    [PunRPC]
    void _CountSend()
    {
        Counter.count = this.count;
       Counter.UpdateCountText();
    }
    public void Inst()
    {
        if (PhotonNetwork.IsMasterClient)
            CounterPun = PhotonNetwork.Instantiate("Counter2", Vector3.zero, Quaternion.identity);
    }
    #endregion


    #region Start, Update
    void Start()
    {
        this.count = Counter.count;
    }

    void Update()
    {

    }
    #endregion
}
