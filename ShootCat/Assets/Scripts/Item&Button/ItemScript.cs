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
    public CounterMethods CounterMethods;//카운터 메소드 가져옴
    public EventTrigger pushBtnEventTrigger;
    public Image catPawIce;
    public Image catPawNormal;

    public Image countUp; // 남은 숫자를 늘리는 아이템


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

    public void ActiveCountUp()//남은 숫자를 100 만큼 올리는 아이템
    {
        CounterMethods.CounterPlus(100);
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

