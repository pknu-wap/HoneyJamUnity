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
    void Start()
    {

    }

    void Update()
    {
        countDown -= Time.deltaTime;
        CountDownTxt.text = "" + (int)countDown;
        if (countDown <= 0)
            GameStart();

    }

    void GameStart()
    {
        CountDownPanel.transform.position += new Vector3(0, 20, 0);
        Debug.Log("CountDown == 0");
        if (countDown < -3)
            Destroy(CountDownPanel);
    }
}