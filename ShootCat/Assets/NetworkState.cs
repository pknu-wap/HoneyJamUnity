using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Photon.Pun.Demo.Asteroids
{
    public class NetworkState : MonoBehaviour
    {

        private readonly string connectionStatusMessage = "    Connection Status: ";

        [Header("UI References")]
        public TMPro.TextMeshProUGUI ConnectionStatusText;

        #region UNITY

        public void Update()
        {
            ConnectionStatusText.text = connectionStatusMessage + PhotonNetwork.NetworkClientState;
        }

        #endregion
    }
}