using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;

public class ItemScript : MonoBehaviour
{
    public Button pushBtn;
    public ButtonMethods ButtonMethods;
    public EventTrigger pushBtnEventTrigger;
    public Image catPawIce;
    public Image catPawNormal;
    #region Behavior
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion





    [Range(0.0f, 5.0f)]
    public float iceTime;//얼릴 시간
    public void ActiveIce()
    {
        pushBtnEventTrigger.enabled = false;
        ButtonMethods.BtnImageChange(pushBtn, catPawIce);
        Debug.Log(Time.time);
        Invoke("ButtonNormal", iceTime);
       
    }
    public void ButtonNormal()
    {
        ButtonMethods.BtnImageChange(pushBtn, catPawNormal);
        Debug.Log(Time.time);
        pushBtnEventTrigger.enabled = true;
    }

      
    #region PunRpc//네트워크 파트라 안봐도 되요 여긴
    [PunRPC]
    public void _NetworkIce()
    {

        Debug.Log(this.GetComponent<PhotonView>().ViewID);
        ActiveIce();
    }
    #endregion
   
}

