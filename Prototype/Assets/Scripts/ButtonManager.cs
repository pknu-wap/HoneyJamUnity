using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public CounterActor counterActor;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Shoot() {//버튼 이름 뭐할까 하다가 그냥 성주형이 말한 총쏘는 고양이 생각나서ㅋㅋㅋ
        counterActor.CounterSub();
        counterActor.YourCountPlus();
    }
}
