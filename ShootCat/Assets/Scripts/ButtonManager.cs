 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{

    public CounterActor counterActor;

    void Start()
    {

    }

    void Update()
    {

    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
