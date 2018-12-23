using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviourPunCallbacks, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDragged;
    public int target;
    Vector3 startPos = new Vector3(-400, -375, 10);
    GameObject GamePlayNetwork;
    GamePlayNetwork gamePlayNetwork;
    void Start() {
        GamePlayNetwork = GameObject.FindWithTag("Network");
        gamePlayNetwork = GamePlayNetwork.GetComponent<GamePlayNetwork>();
    }

    #region DragEvent
    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDragged = gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (target == 0)
            gameObject.GetComponent<RectTransform>().localPosition = startPos;
       
        else
        {
            //Destroy(gameObject);
            gameObject.GetComponent<RectTransform>().localPosition = startPos;
            Debug.Log("Destroy!!!");
        }
        beingDragged = null;
    }
    #endregion

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("TriggerEnter");
        foreach (PlayerInfo p in gamePlayNetwork.PlayerInfos)
        {
            if (col.tag.Equals(p.tag))
            {
                target = p.actorNumber;
                Debug.Log(target);
                break;
            }
        }
     
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("TriggerExit");
        target = 0;
    }
}

