using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour {
    public int count;


    public Text CountText;

	void Start () {
        count = 100;
        UpdateCountText();

    }
	
	void Update () {
		
	}

    public void CountSub() {
        count -= 1;
    }

    public void UpdateCountText()
    {
        CountText.text = $"Count :{count}";//포맷팅 달러
    }
}
