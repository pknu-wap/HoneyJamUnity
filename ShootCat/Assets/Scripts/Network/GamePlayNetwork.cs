using System.Collections;
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
        ItemView.RPC("_NetworkIce", RpcTarget.All);
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
    }

    void Update()
    {

    }
    #endregion
    void OnGUI()

    
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
            Debug.Log(ItemView + "  " + ItemView.ViewID);

    }
}
