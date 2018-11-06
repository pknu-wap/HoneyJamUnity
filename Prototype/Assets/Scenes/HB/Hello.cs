using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour {
    
    string log = "";
    PhotonView view;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    public void Attack()
    {
        Debug.Log("Attack!");
        view.RPC(nameof(Attack_), RpcTarget.All, PhotonNetwork.LocalPlayer.UserId);
    }

    [PunRPC]
    private void Attack_(string id) => log += $"Attack {id}\n";

    private void OnGUI()
    {
        foreach (var id in PhotonNetwork.CurrentRoom.Players.Keys)
            GUILayout.Label(id.ToString());

        if (GUILayout.Button("Attack"))
            Attack();

        GUILayout.Label(log);
    }

    private void Update()
    { 
        if(log != null)
            Debug.Log(log);
    }
}
