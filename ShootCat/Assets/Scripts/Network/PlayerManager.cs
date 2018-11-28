using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    private GameObject playerUiPrefab;

    public int playerCount;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        if (playerUiPrefab != null)
        {
            GameObject _uiGo = Instantiate(playerUiPrefab);
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
        }
        else
        {
            Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
