using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GamePlayNetwork : MonoBehaviourPunCallbacks
{
    PhotonView View;
    public GameObject CounterPrefab;
    Counter CounterScript;
    
    void CounterInst()
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

    #region RPCs
    public void UpdateCount()//다른 플레이어 카운트 숫자 동기화
    {
        
        int getCount=0;
        if (View.IsMine)
        {
            getCount = CounterScript.RemaingCount;

            View.RPC("_UpdateCount", RpcTarget.All, getCount);
        }
    }

    [PunRPC]
    void _UpdateCount(int getCount)
    {
        CounterScript.RemaingCount = getCount;
        CounterScript.UpdateRemainingCountText();//Update text
        Debug.Log("스크립트에 붙어 있는 변수 : " + CounterScript.RemaingCount + "지금 네트워크에 달려있는 변수 : " + getCount);

    }



    #endregion




    #region Behaviour
    void Awake() {
        Screen.SetResolution(1080/5, 1920/5, false);
    }



    void Start()
    {
        CounterScript = CounterPrefab.GetComponent<Counter>();
        View = CounterPrefab.GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
            CounterInst();

    }

    void Update()
    {

    }
    #endregion
}
