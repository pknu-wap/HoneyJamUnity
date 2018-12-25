using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
/*이 스크립트에서 카운터 안에 있는 숫자들 텍스트로 나타내고 덧셈 뺼샘등의 메소드를 관리한다*/
public class CounterMethods : MonoBehaviour
{
    [SerializeField]
    GameObject CounterPrefab;
    public Counter counter;

    GameObject GamePlayNetwork;
    GamePlayNetwork gamePlayNetwork;
    public Text yourCountText; //플레이어가 누른 카운터 수를 나타내는 텍스트
    public GameObject CountdownText;
    public GameObject LoadingPanel;
    public Text remainingCountText; //카운터의 남은 수를 나타내는 텍스트
    public Text hideCountText;//카운터 가리고 이제 ???로보여줌
    public GameObject block;
    public GameObject thread;
    public GameObject RankingPanel;
    public Image thread50Img;
    public Image thread10Img;
    public Image thread100Img;
    Vector3 InitTransform ;
    void Start()
    {   InitTransform = gameObject.transform.position;
        hideCountText.enabled = false;
        GamePlayNetwork = GameObject.FindWithTag("Network");
        gamePlayNetwork = GamePlayNetwork.GetComponent<GamePlayNetwork>();

    }

    public void Init()
    {
        CounterPrefab = GameObject.FindWithTag("CounterPhotonView");
    }
    public void CounterSub()
    {
        counter.RemaingCount -= counter.CountSize;
        UpdateSendCount();

    }

    public void CounterPlus(int plusSize)
    {
        counter.RemaingCount += plusSize;
        UpdateSendCount();
    }

    public void DoubleCount()//카운트 두배 함수
    {
        counter.CountSize = counter.CountSize * 2;
        counter.YourCountSize = counter.YourCountSize * 2;

    }
    public void DivideCount()//카운트 2분의 1 함수
    {
        counter.CountSize = counter.CountSize / 2;
        counter.YourCountSize = counter.YourCountSize / 2;
    }
    public void InitCount()//카운트사이즈 초기화
    {
        counter.CountSize = 1;

    }
    public void YourCountPlus()
    {

        counter.YourCount += counter.YourCountSize; //버튼 누르면 이 함수를 호출 시켜서 더해줌

    }
    public void UpdateRemainingCountText()
    {
        remainingCountText.text = "" + counter.RemaingCount;
    }

    public void UpdateYourCountText()
    {
        yourCountText.text = "Score : "+ counter.YourCount;
    }

    public void UpdateLocalScoreText()
    {
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
            if (p.isLocal)
            {
                p.Score = counter.YourCount;
                break;
            }
    }

    public void StartRankingPanel() {
        RankingPanel.SetActive(true);
    }


    public void UpdateSendCount()
    {
        if (CounterPrefab.GetComponent<PhotonView>().IsMine)
            CounterPrefab.GetComponent<CounterPhotonView>().networkCurrentCount = counter.RemaingCount;

    }
    public void UpdateSendScore()
    {
        if (CounterPrefab.GetComponent<PhotonView>().IsMine)
            CounterPrefab.GetComponent<CounterPhotonView>().networkScore = counter.YourCount;

    }
    public void HideCount()
    {
        remainingCountText.enabled = false;
        hideCountText.enabled = true;
    }
    public void ActiveCount()
    {
        hideCountText.enabled = false;
        remainingCountText.enabled = true;
    }
    public void Changeimg(int num) {

        if (num == 100)
        {
            thread.GetComponent<Image>().sprite = thread100Img.sprite;
        }
        if (num ==50) {
            thread.GetComponent<Image>().sprite = thread50Img.sprite;
        }
        if (num == 10)
        {
            thread.GetComponent<Image>().sprite = thread10Img.sprite;
        }
    }
 
    public void ShakeCount() {
        gameObject.transform.position = InitTransform;
        //Debug.Log(InitTransform);
        gameObject.transform.DOPunchPosition(new Vector3(30,0,0),1);
        gameObject.transform.position = InitTransform;

    }

}
