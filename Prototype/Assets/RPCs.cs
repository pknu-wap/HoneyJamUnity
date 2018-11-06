using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RPCs : MonoBehaviourPunCallbacks
{
     public CounterManager Counter;
    int count;

    #region RPC
    public void CountSend() {

        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC(nameof(_CountSend), RpcTarget.All);

    }

    [PunRPC]
    void _CountSend()
    {
        Counter.count = this.count;
    }


    #endregion


    #region Start, Update
    void Start () {
       this.count = Counter.count;
	}
	
	void Update () {
		
	}
    #endregion
}
