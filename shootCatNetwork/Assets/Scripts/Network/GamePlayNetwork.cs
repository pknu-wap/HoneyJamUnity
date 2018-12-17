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
    PhotonView ItemView;
    PlayerInfo[] playerInfo;
    public List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();
    List<string> TagList = new List<string>();
    string[] playerTag;
    public TMPro.TextMeshProUGUI[] PlayerNickname;
    public TMPro.TextMeshProUGUI[] PlayerScore;
    public GameObject[] PlayerCat;
    GameObject CounterViewPrefab;
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
        foreach (PlayerInfo p in PlayerInfos)
        {
            if (!p.isLocal)
            {
                PlayerCat[i].tag = playerTag[i];
                p.tag = playerTag[i];
                p.PlayerCat = PlayerCat[i];
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
    public void UpdatePlayerScore()
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log("아니 왜 점수 오르는게 안되냐고 왜 대체");

        CounterView.RPC("_UpdatePlayerScore", RpcTarget.All);
    }
    public void NetworkIce()//Ice 아이템 적용
    {
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkIce", RpcTarget.Others, dragHandler.target);
    }

    public void NetworkCrashBlock()//CrashBlock 아이템 적용
    {
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkCrashBlock", RpcTarget.Others);
    }

    public void NetworkDoubleCount()//CrashBlock 아이템 적용
    {
        //ItemView.ViewID = ItemViewID;
        Debug.Log(ItemView + "  " + ItemView.ViewID);
        ItemView.RPC("_NetworkDoubleCount", RpcTarget.Others);
    }




    public void _UpdatePlayerScore1()
    {
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Debug.Log(PlayerScore[i].text);
            PlayerScore[i].text = p.score + "";
            i++;
        }
        i = 0;
    }
    #endregion

    #region Behaviour
    void Awake()
    {
        //Screen.SetResolution(1080 / 5, 1920 / 5, false);
    }


    void Start()
    {
        CounterViewInst();
        ItemViewInst();
        SetTag();


        ItemView = ItemPrefab.GetComponent<PhotonView>();

        playerInfo = new PlayerInfo[4];
        PlayerInfoSet();


    }
    #endregion



}
public class PlayerInfo
{
    public string playerNickname;
    public TMPro.TextMeshProUGUI playerNicknameText;
    public TMPro.TextMeshProUGUI scoreText;
    public bool isLocal = false;
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
        playerNickname = p.NickName;
        if (p.UserId == PhotonNetwork.LocalPlayer.UserId)
            isLocal = true;
        actorNumber = p.ActorNumber;
    }
    public void SetNickname()
    {

        playerNicknameText.text = playerNickname;
    }

}