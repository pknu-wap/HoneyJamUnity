using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateRoomScript : MonoBehaviour
{

    public string roomName;
    public TMPro.TextMeshProUGUI InputTitle;

    public byte MaxPlayersPerRoom { get; set; }  //토글에게 받아와야함 



    void Start()
    {

    }

    void Update()
    {

    }

    public string GetRoomName()
    {
        roomName = InputTitle.text;

        return roomName;
    }
    void GotoGame() {

        SceneManager.LoadScene("GamePlay");

    }
}
