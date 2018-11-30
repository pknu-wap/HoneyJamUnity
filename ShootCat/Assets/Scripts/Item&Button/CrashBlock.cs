using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class CrashBlock : MonoBehaviour {

    public Counter counter;
    public CounterMethods CounterMethods;//카운터 메소드 가져옴

    private int RemainBlockCount = 20;
    public GameObject block;
    public EventTrigger pushBtnEventTrigger;

    public void BlockInit()
    {
        RemainBlockCount = 20;
    }

    public void ActiveBlockCrash()//블록 부수기 함수
    {
        Debug.Log(RemainBlockCount);
        RemainBlockCount -= 1;
        if (RemainBlockCount < 0)
        {
            block.SetActive(false);
            pushBtnEventTrigger.enabled = true;
        }
        else
        {
            pushBtnEventTrigger.enabled = false;
        }
    }
}
