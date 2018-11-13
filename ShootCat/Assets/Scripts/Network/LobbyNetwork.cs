using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{

    #region Private Serializable Fields
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
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

    }
    #endregion

    #region Button Methods
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom("Checken");
            SceneManager.LoadScene("GamePlay");
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
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
        PhotonNetwork.CreateRoom("Checken", new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        SceneManager.LoadScene("GamePlay");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }
}
