using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GamePlayNetwork : MonoBehaviourPunCallbacks
{
    #region Variable
    PhotonView CounterView;
    public GameObject CounterPrefab;
    public GameObject ItemPrefab;

    PhotonView ItemView;
    PlayerInfo[] playerInfo;
    public PlayerInfo LocalPlayer;
    public List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();
    List<string> TagList = new List<string>();
    string[] playerTag;
    public TMPro.TextMeshProUGUI[] PlayerNickname;
    public TMPro.TextMeshProUGUI[] PlayerScore;
    public GameObject[] PlayerCat;
    GameObject CounterViewPrefab;
    #endregion

    #region ItemVariable
    public GameObject IceBtn;
    public GameObject BlockBtn;


    #endregion

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

    #region PlayerSet & Info
    void PlayerInfoSet()
    {

        foreach (Player p in PhotonNetwork.PlayerList)
        {
            PlayerInfos.Add(new PlayerInfo(p));
        }
        int i = 0;
        int j = 0;
        foreach (PlayerInfo p in PlayerInfos)
        {
            if (p.isLocal)
                LocalPlayer = p;


            if (!p.isLocal)
            {
                Debug.Log(p.playerNickname + " " + p.isLocal);
                PlayerCat[j].tag = playerTag[j];
                p.tag = playerTag[j];
                p.PlayerCat = PlayerCat[j];
                j++;
            }
            p.playerNicknameText = PlayerNickname[i];
            p.SetNickname();
            p.scoreText = PlayerScore[i];

            i++;
        }
        i = 0;
    }
    public void SetTag()
    {
        playerTag = new string[3];
        playerTag[0] = "Player1";
        playerTag[1] = "Player2";
        playerTag[2] = "Player3";
    }

    #endregion
    #region RPCs
    public void UpdateLoser()//플레이어들에게 누가 패배자인지 확실히 알려주지
    {
        GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().StartRankingPanel();
        CounterView.RPC("_UpdateLoser", RpcTarget.Others, LocalPlayer.actorNumber);
    }
    public void ReadyToMaster()
    {
       CounterView.RPC("_ReadyToMaster", RpcTarget.MasterClient, LocalPlayer.actorNumber);
        
    }
    public void Ready() {

       
        GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().LoadingPanel.SetActive(false);
        GameObject.FindWithTag("CounterMethods").GetComponent<CounterMethods>().CountdownText.SetActive(true);
        GameObject.FindWithTag("Audio").GetComponent<AudioSource>().enabled = true;
        CounterView.RPC("_Ready", RpcTarget.Others, LocalPlayer.actorNumber);
    }

  



    public void NetworkIce()//Ice 아이템 적용
    {
        Debug.Log(IceBtn.GetComponent<DragHandler>().target);
        ItemView.RPC("_NetworkIce", RpcTarget.Others, IceBtn.GetComponent<DragHandler>().target);
    }

    public void NetworkCrashBlock()//CrashBlock 아이템 적용
    {
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkCrashBlock", RpcTarget.Others, BlockBtn.GetComponent<DragHandler>().target);
    }

    public void NetworkDoubleCount()//CrashBlock 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkDoubleCount", RpcTarget.Others);
    }
    #endregion

    #region Behaviour
    
    void Awake() {
       

    }
    void Start()
    {
        CounterViewInst();
        ItemViewInst();
        SetTag();

        playerInfo = new PlayerInfo[4];
        PlayerInfoSet();
        ItemView = ItemPrefab.GetComponent<PhotonView>();



        
        Invoke("Ready", 3); 


    }
    #endregion



}
public class PlayerInfo
{
    public string playerNickname;
    public TMPro.TextMeshProUGUI playerNicknameText;
    public TMPro.TextMeshProUGUI scoreText;
    public bool isLocal = false;
    public bool isLoser = false;
    public bool isReady = false;
    public int actorNumber;
    int score;
    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
            scoreText.text = score + "";
        }
    }

    public GameObject PlayerCat;

    public string tag;

    public PlayerInfo(Player p)
    {
        Debug.Log(p.NickName + " " + p.UserId + " " + PhotonNetwork.LocalPlayer.UserId);
        playerNickname = p.NickName;
        if (p.UserId == PhotonNetwork.LocalPlayer.UserId)
        {
            this.isLocal = true;
            this.isReady = true;
           
        }
        actorNumber = p.ActorNumber;
    }
    public void SetNickname()
    {
       
        playerNicknameText.text = playerNickname;
    }

}