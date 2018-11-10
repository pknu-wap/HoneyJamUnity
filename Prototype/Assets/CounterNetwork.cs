using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CounterNetwork : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public int remaingCount;
    GameObject Counter;
    Counter CounterScript;
    
    public void CounterInst()
    {
        Counter = PhotonNetwork.Instantiate("Counter", Vector3.zero, Quaternion.identity);
        CounterScript = Counter.GetComponent<Counter>();
    }

    public void CountUpdate()
    {
        if (photonView.IsMine)
            remaingCount = CounterScript.RemaingCount;
        else remaingCount = 340;
        photonView.RPC(nameof(_CountUpdate), RpcTarget.All, remaingCount);

    }

    #region PUN RPC

    [PunRPC]
    public void _CountUpdate(int getremaingCount)
    {
        CounterScript.RemaingCount = getremaingCount;
        CounterScript.UpdateRemainingCountText();//Update text
        Debug.Log("스크립트에 붙어 있는 변수 : "+ CounterScript.RemaingCount+ "지금 네트워크에 달려있는 변수 : "+remaingCount);
    }
    #endregion

    #region Behaviour
    void Awake()
    {

    }
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
            CounterInst();
        photonView = this.GetComponent<PhotonView>();
        Debug.Log("카운터 받아왔다 counter count: " + CounterScript.RemaingCount+ "전해줄 카운터 : ");
    }
    void Update()
    {

    }
    #endregion

}
