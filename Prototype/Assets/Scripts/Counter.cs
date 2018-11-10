using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour//Counter 네트워크 떄문에 프리팹으로 적용
{

    public int yourCount;//플레이어가 누른 카운터 

    public Text yourCountText; //플레이어가 누른 카운터 수를 나타내는 텍스트

   public int remainingCount;//카운터의 남은 수

    public Text remainingCountText; //카운터의 남은 수를 나타내는 텍스트

    public int RemaingCount
    {
        get { return remainingCount; }
        set
        {
            if (remainingCount < 0) Debug.Log("카운터가 0 이하로 내려갈 일이 뭐가 있을까");
            this.remainingCount = value;
        }
    }

    public int CountSize { get; set; } //카운터 가감 양(기본 1 , 아이템 따라 다름)

    public int YourCount { get; set; } //플레이어가 지금까지 누른 수

    public int YourCountSize { get; set; } //플레이어 지금까지 누른 수에 가감할 양(기본 1, 아이템 적용에 따라 다름)
    void Awake() {
        RemaingCount = 300;
        remainingCountText = GameObject.Find("RemainingCount").GetComponent<UnityEngine.UI.Text>();
        remainingCountText.text = GameObject.Find("RemainingCount").GetComponent<UnityEngine.UI.Text>().text;
        yourCountText = GameObject.Find("YourCount").GetComponent<UnityEngine.UI.Text>();
        yourCountText.text = GameObject.Find("YourCount").GetComponent<UnityEngine.UI.Text>().text;
        

    }
    void Start()
    {
       
        UpdateRemainingCountText();
        UpdateYourCountText();
    }

    void Update()
    {

    }

    public void UpdateRemainingCountText()
    {
        remainingCountText.text = "Count : " + RemaingCount;
    }

    public void UpdateYourCountText()
    {
        yourCountText.text = "Your Count : " + YourCount;
    }


}
