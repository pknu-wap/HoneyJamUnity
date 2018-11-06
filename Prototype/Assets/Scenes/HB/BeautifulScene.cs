using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using Photon.Pun.UtilityScripts;

public class BeautifulScene : MonoBehaviourPunCallbacks
{

    string log = "";

    GameObject hello;

    private void Awake()
    {
        if(PhotonNetwork.IsMasterClient)
            hello = PhotonNetwork.Instantiate("Hello", Vector3.zero, Quaternion.identity);
    }

    public void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        hello.transform.position += new Vector3(hor, ver) / 100;
    }




}
