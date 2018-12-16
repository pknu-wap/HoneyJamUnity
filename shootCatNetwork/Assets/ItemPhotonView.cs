using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ItemPhotonView : MonoBehaviour {

    ItemScript itemScript;

	void Start () {
        itemScript = GameObject.Find("ItemScript").GetComponent<ItemScript>();
	}
	
    #region PunRpc
    [PunRPC]
    public void _NetworkIce(string targetID)
    {
        if (!PhotonNetwork.LocalPlayer.ActorNumber.Equals(targetID))
            itemScript.ActiveIce();
        Debug.Log(PhotonNetwork.LocalPlayer.UserId);
    }
    [PunRPC]
    public void _NetworkCrashBlock()
    {
        Debug.Log(this.GetComponent<PhotonView>().ViewID);
        itemScript.ActiveCrashBlock();
    }

    
    [PunRPC]
    public void NetworkDoubleCount()
    {
        Debug.Log(this.GetComponent<PhotonView>().ViewID);
        itemScript.ActiveDoubleCount();
    }
    #endregion
}
