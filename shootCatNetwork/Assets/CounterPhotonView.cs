using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CounterPhotonView : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject counterUI;
    Counter counter;

   public int networkCurrentCount;
    int networkMyScore;


    void Start () {
     
     counterUI = GameObject.FindWithTag("CounterMethods");
     counter = counterUI.GetComponent<Counter>();
        counterUI.GetComponent<CounterMethods>().Init();
    }
	
	
	void Update () {
       
     
    }

    

    void UpdateReceiveCount() {
        if (!photonView.IsMine)
        {
            counter.RemaingCount = networkCurrentCount;
            Debug.Log(networkCurrentCount);
        }
    }
          void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
     
        if (stream.IsWriting)
        {
            Debug.Log("전송 중");
          
            stream.SendNext(networkCurrentCount);
        }
        else if (stream.IsReading)
        {
            Debug.Log("수신 중");
            networkCurrentCount = (int)stream.ReceiveNext();
            UpdateReceiveCount();
        }
    }
}
