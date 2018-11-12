using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemScript : MonoBehaviour
{
    public Button pushBtn;
    public ButtonManager ButtonManager;
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
    public float iceTime;
    public void ActiveIce()
    {
        ButtonManager.BtnInteractable(pushBtn,"off");
        ButtonManager.BtnImageChange(pushBtn, catPawIce);
        //pushBtnEventTrigger.
        //Debug.Log(Time.time);
        StartCoroutine(WaitTime(iceTime));
        Debug.Log(Time.time);
       
    }


    IEnumerator WaitTime(float second)//이 코루틴을 쓰면 second초 만큼 잠시 동작을 멈춥니다.
    {
        yield return new WaitForSeconds(second); ButtonManager.BtnImageChange(pushBtn, catPawNormal);
        ButtonManager.BtnInteractable(pushBtn, "on");
    }

}

