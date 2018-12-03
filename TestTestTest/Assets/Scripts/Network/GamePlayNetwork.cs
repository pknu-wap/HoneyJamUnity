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
    PlayerInfo[] playerInfo;
    public TMPro.TextMeshProUGUI Player1Nickname;
    public TMPro.TextMeshProUGUI Player2Nickname;
    public TMPro.TextMeshProUGUI Player3Nickname;
    public TMPro.TextMeshProUGUI Player4Nickname;
  
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
            playerInfo[i] = new PlayerInfo(p.NickName);
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

    void Update()
    {
        //Debug.Log("PlayerName" + playerInfo[0].playerNickname);
        //Debug.Log("PlayerName"+playerInfo[2].p/*layerNickname);
    }
    #endregion
   
}
class PlayerInfo{
   public string playerNickname;
    int score;

    public PlayerInfo(string getName) {
        this.playerNickname = getName;
    }
        

}