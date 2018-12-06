using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;
public class GameManager : MonoBehaviourPunCallbacks
{

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
