 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button PushButton;//pushButton
    public CounterActor counterActor;
    public SpriteRenderer catPawIce;
    Image image_;
    Image image
    {
        get
        {
            if (image_ == null)
                image_ = GetComponent<Image>();
            return image_;
        }
    }
    public SpriteRenderer catPawNormal;
    #region Behavior
    void Start()
    {
       
    }

    void Update()
    {

    }
    #endregion
    public void GotoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Exit()
    {
        Application.Quit();
    }
    #region Item


    

    private void IceEffective() {
      image.sprite = catPawIce.sprite;


        PushButton.interactable = false;


        image.sprite = catPawIce.sprite;

    }
    public void WaitingTime
    #endregion
}
