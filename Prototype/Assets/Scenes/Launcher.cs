using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{


    public class Launcher : MonoBehaviourPunCallbacks
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
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        void Start()
        {
        }
        #endregion

        #region Public Method 버튼들
        public void Connect()
        {
            if (PhotonNetwork.IsConnected)
            {
                //PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }


        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom("chicken");
            Debug.Log("Chicken 방 개설");
        }
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom("chicken");
            Debug.Log("Chicken 방 입장");
        }
        #endregion

        #region MonoBehaviourPunCallbacks Callbacks

        public override void OnConnectedToMaster()
        {
            //PhotonNetwork.JoinRandomRoom();
            Debug.Log("OnConnectedToMaster 실행 중 " );
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }
        #endregion

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            SceneManager.LoadScene("BeautifulScene");
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }

        private void OnGUI()
        {
            //GUI.skin.label.fontSize = 15;
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());

            if (GUILayout.Button("Button Name"))
                Debug.Log("chicken");

        }
    }
}