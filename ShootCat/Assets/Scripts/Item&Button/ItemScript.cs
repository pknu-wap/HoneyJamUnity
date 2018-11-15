using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    public float iceTime;
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

    IEnumerator WaitTime(float second)//이 코루틴을 쓰면 second초 만큼 잠시 동작을 멈춥니다.
    {
        yield return new WaitForSeconds(second); ButtonMethods.BtnImageChange(pushBtn, catPawNormal);
      
    }

}

