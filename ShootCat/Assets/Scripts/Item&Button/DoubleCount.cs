using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoubleCount : MonoBehaviour {
    public CounterMethods CounterMethods;//카운터 메소드 가져옴
    public EventTrigger pushBtnEventTrigger;
    public GameObject doubleCount;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    [Range(2.0f, 4.0f)]
    public float doubleTime;//아이템 지속시간
    public void ActiveDoubleCount()//아이템 사용시 고양이 손 두개가 그려진 이미지로 바뀌면서 카운트를 2씩 깎음.
    {
        Invoke("ButtonNormal", doubleTime);
        CounterMethods.CountDouble();
        pushBtnEventTrigger.enabled = false;

    }

    public void ButtonNormal()
    {
        doubleCount.SetActive(false);
        Debug.Log("사용 끝");
        pushBtnEventTrigger.enabled = true;
    }
}
