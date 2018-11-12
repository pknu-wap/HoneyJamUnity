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
    public void IceEffective(float iceTime) {

     image.sprite = catPawIce.sprite;
       
     PushButton.interactable = false;
        WaitTime(iceTime);
     PushButton.interactable = true;

     image.sprite = catPawIce.sprite;

    }
        IEnumerator WaitTime(float second)//이 코루틴을 쓰면 second초 만큼 잠시 동작을 멈춥니다.
    {
        yield return new WaitForSeconds(second);
    }
    #endregion
}
