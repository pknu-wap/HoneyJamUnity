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
    public DragHandler dragHandler;
    Counter counter;
    PhotonView ItemView;
    #endregion

    PlayerInfo[] playerInfo;
    List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();
    List<string> TagList = new List<string>();
    string[] playerTag;
    public TMPro.TextMeshProUGUI[] PlayerNickname;
    public TMPro.TextMeshProUGUI[] PlayerScore;
    public GameObject[] PlayerCat;
    GameObject CounterViewPrefab;

    #region ViewInstantiate

    void CounterViewInst()
    {
        if (CounterPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color>카운터 프리팹 설정 안됬음 ", this);
        }
        else
        {
             CounterViewPrefab = PhotonNetwork.Instantiate("CounterPhotonView", new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            counter = CounterViewPrefab.GetComponent<Counter>();
         
            CounterView = CounterViewPrefab.GetComponent<PhotonView>();
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
            PhotonNetwork.Instantiate("ItemPhotonView", new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }
    }
    #endregion

   
    void PlayerInfoSet() {

        
        int i = 0;
        int j = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Debug.Log("i : " +i +" player : "+p.ActorNumber);
            if (p.UserId != PhotonNetwork.LocalPlayer.UserId)
                PlayerCat[j].tag = p.ActorNumber+"";
            PlayerNickname[i].text = p.NickName;
            PlayerScore[i].text = p.score+"";
            i++;
        }
        i = 0;
        j = 0;

    }
  
    #region RPCs
    public void UpdateCount()//다른 플레이어 카운트 숫자 동기화
    {
        int getCount = 0;
        

        getCount = counter.RemaingCount;
        Debug.Log("CounterView: " + CounterView + "GetCount" + getCount);
        CounterView.RPC("_UpdateCount", RpcTarget.Others, getCount);

           
      
     
    }
    public void NetworkIce()//Ice 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkIce", RpcTarget.Others, dragHandler.target);
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
    public void UpdatePlayerScore()
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(CounterView + "  " + CounterView.ViewID);
        CounterView.RPC("_UpdatePlayerScore", RpcTarget.Others);
    }
    

    [PunRPC]
    void _UpdatePlayerScore()
    {
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            PlayerScore[i].text = p.score + "";
            i++;
        }
        i = 0;
    }
    public void _UpdatePlayerScore1()
    {
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            PlayerScore[i].text = p.score + "";
            i++;
        }
        i = 0;
    }
    #endregion




    #region Behaviour
    void Awake()
    {
        Screen.SetResolution(1080 / 5, 1920 / 5, false);
     
    }


    void Start(
)
    {
        CounterViewInst();
        ItemViewInst();
        SetTag();


        ItemView = ItemPrefab.GetComponent<PhotonView>();
      
        playerInfo = new PlayerInfo[4];
        PlayerInfoSet();

    
    }

    #endregion
    public void SetTag() {

        playerTag = new string[3];
        playerTag[0] = "Player1";
        playerTag[1] = "Player2";
        playerTag[2] = "Player3";


    }
    
   
    public void UpdateNetworkScore(int score)
    {
        PhotonNetwork.LocalPlayer.score = score;


    }

}
class PlayerInfo{
   public string playerNickname;
    int score;

    public PlayerInfo(string getName) {
        this.playerNickname = getName;
    }
        

}