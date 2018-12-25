 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMethods : MonoBehaviour
{
    public GameObject PushButton;//pushButton
    public CounterMethods counterActor;
    
    //Image image;
    //Image Image
    //{
    //    get
    //    {
    //        if (image == null)
    //            image = GetComponent<Image>();
    //        return image;
    //    }
    //}
   
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
        SceneManager.LoadScene("Lobby");//수정해야함
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

    public void ImageChange(GameObject obj,Image image)
    {
        obj.GetComponent<Image>().sprite = image.sprite;
    }

    public void PushButtonEnable() {
        PushButton.SetActive(true);
        PushButton.GetComponent<EventTrigger>().enabled = true;
    }

    public void PushButtonShake() {

       

    }


    #region Item
    
    #endregion
}
