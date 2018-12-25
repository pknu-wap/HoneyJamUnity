using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownText : MonoBehaviour
{

    public TMPro.TextMeshProUGUI CountDownTxt;
    public GameObject CountDownPanel;

    [Range(-5, 10)]
    public float countDown;


    public float CountDown
    {
        get { return countDown; }
        set
        {
            CountDownTxt.text = "" + (int)countDown;
            this.countDown = value;
            if (countDown <= 0)
                GameStart();


        }
    }


    void Start()
    {

    }

    void Update()
    {
        CountDown -= Time.deltaTime;
       

    }

    void GameStart()
    {
        CountDownPanel.transform.position += new Vector3(0, 20, 0);
     
        if (countDown < -3)
            Destroy(CountDownPanel);
    }
}