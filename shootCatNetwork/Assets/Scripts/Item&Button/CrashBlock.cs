using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CrashBlock : MonoBehaviour {


    public bool isBlock;
    private int remainBlockCount;
    public TMPro.TextMeshProUGUI remainBlockCountText;
    ButtonMethods buttonMethods;
    [Range(10, 100)]
    public int remainBlockCountInit;
    public void Start()
    {
    buttonMethods = GameObject.FindGameObjectWithTag("ButtonMethods").GetComponent<ButtonMethods>();
        remainBlockCountText.text = ""+remainBlockCountInit;
    
        isBlock = true;
        RemainBlockCountInit();
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            remainBlockCount--;
            remainBlockCountText.text = "" + remainBlockCount;

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
        buttonMethods.PushButtonEnable();
        Destroy(gameObject);
    }




}
