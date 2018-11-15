using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public string UserId { get; set; }
    public TMPro.TextMeshProUGUI UserIdInputField; // set in inspector
    public GameObject InputYourId;
    public CreateRoomScript createRoomScript;
    public int maxPlayersPerRoom = 4;

    #region Private Serializable Fields
    [SerializeField]
    //private byte maxPlayersPerRoom = 4; // 받아와야함 토글에서
    #endregion

    #region Private Fields
    string gameVersion = "1";
    #endregion


    #region MonoBehaviour CallBacks
    void Awake()
    {
        Screen.SetResolution(1080/5, 1920/5, false);
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        if (UserId == null)
            InputYourId.SetActive(true);


    }
    #endregion

    #region Button Methods
    public void Connect()
    {
        //if (PhotonNetwork.IsConnected)
        //{
        //    PhotonNetwork.JoinRoom("Checken");
        //    SceneManager.LoadScene("GamePlay");
        //}
        //else

        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }

        UserId = UserIdInputField.text;//ID setting
        InputYourId.SetActive(false);
    }
    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }
    #endregion

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("만들어진 방이 없으니깐 생성 조진다");
      
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }
    public void CreateRoom() {
        createRoomScript.MaxPlayersPerRoom = 0;//나중에 지워줘야지 뭐..
        PhotonNetwork.CreateRoom(createRoomScript.GetRoomName(), new RoomOptions { MaxPlayers = createRoomScript.MaxPlayersPerRoom});
        SceneManager.LoadScene("GamePlay");
    }
}
