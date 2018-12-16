using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviourPunCallbacks, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDragged;
    public string target;
    Vector3 startPos = new Vector3(-400, -375, 10);
    
   

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

