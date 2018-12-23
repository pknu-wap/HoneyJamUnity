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
    public GameObject pushBtn;
    public ButtonMethods ButtonMethods;
    public CounterMethods CounterMethods;//카운터 메소드 가져옴
    public EventTrigger pushBtnEventTrigger;
    public Image catPawIce;
    public Image catPawNormal;

    public Image countUp; // 남은 숫자를 늘리는 아이템
    public Transform centerPosition;

    #region Behavior
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion



    #region ActiveItem

    [Range(0.0f, 5.0f)]
    public float iceTime;//얼릴 시간
    public void ActiveIce()
    {
        pushBtnEventTrigger.enabled = false;
        pushBtn.GetComponent<Image>().sprite = catPawIce.sprite;
       
        Debug.Log(Time.time);
        Invoke("ButtonNormal", iceTime);
    }
 

    public GameObject block;
    public void ActiveCrashBlock()
    {
        Instantiate(block).transform.SetParent(centerPosition);
        pushBtnEventTrigger.enabled = false;
    }

    [Range(0, 100)]
    public int plusCount;
    public void ActiveCounterPump()
    {
        ActiveCountUp(plusCount);
    }

    [Range(2.0f, 4.0f)]
    public float doubleTime;//아이템 지속시간
    public void ActiveDoubleCount()//아이템 사용시 고양이 손 두개가 그려진 이미지로 바뀌면서 카운트를 2씩 깎음.
    {
        CounterMethods.DoubleCount();

        Invoke("ButtonNormal", doubleTime);
        Invoke("CountSizeNormal", doubleTime);

    }
    #endregion



    #region ActiveMethod
    public void ButtonNormal()
    {
        pushBtn.GetComponent<Image>().sprite = catPawNormal.sprite;
        pushBtn.GetComponent<EventTrigger>().enabled = true;
    }
    public void CountSizeNormal()
    {
        Debug.Log(Time.time);
        CounterMethods.InitCount();
    }
    public void ActiveCountUp(int count)//남은 숫자를 int count 만큼 올리는 아이템
    {
        CounterMethods.CounterPlus(count);
    }

    #endregion

   

}

