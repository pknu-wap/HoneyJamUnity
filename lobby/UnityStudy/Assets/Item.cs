using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item
{
    public string Title;
    public Sprite Face;
    public bool Confirm;

    /// <summary>
    /// 아이템을 클릭했을때 발생할 이벤트
    /// </summary>
    public Button.ButtonClickedEvent OnItemClick;
}
