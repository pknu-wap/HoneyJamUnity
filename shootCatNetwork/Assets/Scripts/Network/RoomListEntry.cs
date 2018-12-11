using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
    public class RoomListEntry : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI RoomNameText;
        public TMPro.TextMeshProUGUI RoomPlayersText;
        public Button JoinRoomButton;

        private string roomName;

        public void Start()
        {
            JoinRoomButton.onClick.AddListener(() =>
            {

                {
                    PhotonNetwork.LeaveLobby();
                }

                PhotonNetwork.JoinRoom(roomName);
            });
        }

        public void Initialize(string name, byte currentPlayers, byte maxPlayers)
        {
            roomName = name;

            RoomNameText.text = name;
            RoomPlayersText.text = currentPlayers + " / " + maxPlayers;
        }
    }
}