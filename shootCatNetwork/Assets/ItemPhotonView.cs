using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ItemPhotonView : MonoBehaviour {

    ItemScript itemScript;
    GameObject GamePlayNetwork;
    GamePlayNetwork gamePlayNetwork;
	void Start () {
        itemScript = GameObject.Find("ItemScript").GetComponent<ItemScript>();
        GamePlayNetwork = GameObject.FindWithTag("Network");
        gamePlayNetwork = GamePlayNetwork.GetComponent<GamePlayNetwork>();
	}
	
    #region PunRpc
    [PunRPC]
    public void _NetworkIce(int targetID)
    {
     
        if (gamePlayNetwork.LocalPlayer.actorNumber==targetID)
            itemScript.ActiveIce();
      
    }
    [PunRPC]
    public void _NetworkCrashBlock(int targetID)
    {
        if (gamePlayNetwork.LocalPlayer.actorNumber == targetID)
        itemScript.ActiveCrashBlock();
    }

    
    [PunRPC]
    public void NetworkDoubleCount()
    {
        itemScript.ActiveDoubleCount();
    }
    #endregion
}
