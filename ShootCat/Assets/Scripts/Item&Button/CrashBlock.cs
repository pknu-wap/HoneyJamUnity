using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CrashBlock : MonoBehaviour {


    public EventTrigger pushBtnEventTrigger;
    public bool isBlock;
    private int remainBlockCount;

    [Range(10, 100)]
    public int remainBlockCountInit;
    public void Start()
    {
        isBlock = true;
        RemainBlockCountInit();
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            remainBlockCount--;

            if (remainBlockCount <= 0)
            {
                isBlock = false;
                DestoryBlock();
            }
        });
    }


   
    public void RemainBlockCountInit()
    {
        remainBlockCount = remainBlockCountInit;
    }
    public void DestoryBlock() {

        pushBtnEventTrigger.enabled = true;
        Destroy(gameObject);

    }




}
