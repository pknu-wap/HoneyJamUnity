using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    public TMPro.TextMeshProUGUI playerNameText;

    private PlayerManager target;

    public int playerCount;

    [SerializeField]
    private GameObject playerUiPrefab;

    void Start () {

	}
	
	// Update is called once per framecccc
	void Update () {

        if (playerCount != null) {

            playerCount = target.playerCount;

        }

        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    public void SetTarget(PlayerManager _target)
    {
        if (_target == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }
        target = _target;
        if (playerNameText != null)
        {
            playerNameText.text = target.photonView.Owner.NickName;
        }
    }
}
