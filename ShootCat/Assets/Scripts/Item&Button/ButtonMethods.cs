 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMethods : MonoBehaviour
{
    public Button PushButton;//pushButton
    public CounterMethods counterActor;
    public SpriteRenderer catPawIce;
    Image image;
    Image Image
    {
        get
        {
            if (image == null)
                image = GetComponent<Image>();
            return image;
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
    public void BtnInteractable(Button btn, string state)
    {
        if (state == "on") btn.interactable = true;
        if (state == "off")
        {
            btn.interactable = false;
            Debug.Log("Off");
        }
        if (state == "switch")
            btn.interactable = btn.interactable ? false : true;
    }

    public void BtnImageChange(Button btn,Image image)
    {

        btn.GetComponent<Image>().sprite = image.GetComponent<Image>().sprite;
    
    }
    #region Item
  
    #endregion
}
