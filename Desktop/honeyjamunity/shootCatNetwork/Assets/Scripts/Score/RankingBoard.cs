using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingBoard : MonoBehaviour
{

    public GameObject RankingPanel;
    public GameObject MainPanel;
    GamePlayNetwork gamePlayNetwork;
    public TMPro.TextMeshProUGUI[] PlayerNicknameRanking;
    public TMPro.TextMeshProUGUI LoserNickname;
    public TMPro.TextMeshProUGUI[] PlayerScoreRanking;
    public TMPro.TextMeshProUGUI LoserScore;


    void Start()
    {
        gamePlayNetwork = GameObject.FindWithTag("Network").GetComponent<GamePlayNetwork>();
        RankingSort();
        RankingBoardShow();
    }
 
    void RankingBoardShow()//애니메이션 처리로 바꾸고싶더.
    {
        while (true)
        {
            RankingPanel.transform.position -= new Vector3(0, 1, 0);
            if (RankingPanel.transform.position.y <= MainPanel.transform.position.y)
                break;
        }
    }
    void RankingSort()
    {
       
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
        {
            if (p.isLoser)
            {
                LoserNickname.text = p.playerNicknameText.text;
                LoserScore.text = p.scoreText.text;
                gamePlayNetwork.PlayerInfos.Remove(p);
                break;
            }
        }
        gamePlayNetwork.PlayerInfos.Sort((a, b) => { return b.Score - a.Score; });
        int i = 0;
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
        {
           PlayerNicknameRanking[i].text = p.playerNicknameText.text;
           PlayerScoreRanking[i].text = p.scoreText.text;
            i++;
        }
        i = 0;
    }

}
