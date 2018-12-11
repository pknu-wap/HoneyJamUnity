using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviourPunCallbacks, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDragged;
    enum Target { none, player1, player2, player3 };
    public string target;
    Vector3 startPos = new Vector3(-400, -100, 10);
    #region Unity
    void Start()
    {

    }
    void Update()
    {
        //positionCheck();
    }
    #endregion

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
        if (target == "")
            gameObject.transform.position = startPos;
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy!!!");
        }
        beingDragged = null;
    }
    #endregion

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("TriggerEnter");
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            if (col.tag.Equals(p.ActorNumber))
                target = p.ActorNumber+"";
        }
     
    }
    void OnTriggerExit(Collider col)
    {
        target = "";
    }
}

