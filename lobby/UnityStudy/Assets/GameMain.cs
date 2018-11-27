using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    /// <summary>
    /// 아이템으로 사용할 오브젝트(프리팹)
    /// </summary>
    public GameObject ItemObject;
    /// <summary>
    /// 아이템이 추가될 오브젝트
    /// </summary>
    public Transform Content;

    /// <summary>
    /// 바인딩할 리스트
    /// </summary>
    public List<Item> ItemList;


    // Use this for initialization
    void Start()
    {
        this.Binding();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 아이템 리스트를 지정된 프리팹으로 변환하여 추가합니다.
    /// </summary>
    private void Binding()
    {
        GameObject btnItemTemp;
        ItemObject itemobjectTemp;

        foreach (Item item in this.ItemList)
        {
            //추가할 오브젝트를 생성한다.
            btnItemTemp = Instantiate(this.ItemObject) as GameObject;
            //오브젝트가 가지고 있는 'ItemObject'를 찾는다.
            itemobjectTemp = btnItemTemp.GetComponent<ItemObject>();

            //각 속성 입력
            itemobjectTemp.Title.text = item.Title;
            itemobjectTemp.Confirm.SetActive(item.Confirm);
            itemobjectTemp.Item.onClick = item.OnItemClick;

            //화면에 추가
            btnItemTemp.transform.SetParent(this.Content, false);
        }
    }


    /// <summary>
    /// 아이템 클릭
    /// </summary>
    public void ItemClick_Result()
    {
        Debug.Log("아이템이 클릭 되었다.");
    }
}
