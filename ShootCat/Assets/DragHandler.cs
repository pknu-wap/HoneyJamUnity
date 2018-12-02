using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDragged;
    enum Target { none, player1, player2, player3 };
    Target target = Target.none;
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
        if (target == Target.none)
            gameObject.transform.position = startPos;
        else { Destroy(gameObject);
            Debug.Log("Destroy!!!");
        }
        beingDragged = null;
    }
    #endregion
=======

using UnityEngine.EventSystems;



public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{



    public static GameObject beingDragged;



    // Use this for initialization

    void Start()
    {


    }


    // Update is called once per frame

    void Update()
    {

        positionCheck();

    }



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

        beingDragged = null;

    }



>>>>>>> ItemNetwork


    void positionCheck()
    {

        RectTransform trans = transform.gameObject.GetComponent<RectTransform>();



<<<<<<< HEAD
        //좌

        if (trans.anchoredPosition.x - trans.rect.width / 2 < 0)
        {

            Vector3 vector;

            vector = transform.position;

            vector.x = trans.rect.width / 2 + 1f;

            transform.position = vector;

        }



        //상

        if (trans.anchoredPosition.y > 0)
        {

            Vector3 vector;

            vector = trans.anchoredPosition;

            vector.y = -1f;

            trans.anchoredPosition = vector;

        }



        //하

        if (trans.anchoredPosition.y - trans.rect.height < Screen.height * -1)
        {

            Vector3 vector;

            vector = trans.anchoredPosition;

            vector.y = Screen.height * -1 + trans.rect.height;

            trans.anchoredPosition = vector;

        }



        //우

        if (trans.anchoredPosition.x + trans.rect.width / 2 > Screen.width)
        {

            Vector3 vector;

            vector = trans.anchoredPosition;

            vector.x = Screen.width - trans.rect.width / 2;

            trans.anchoredPosition = vector;

        }
=======
        ////좌

        //if (trans.anchoredPosition.x - trans.rect.width / 2 < 0)
        //{

        //    Vector3 vector;

        //    vector = transform.position;

        //    vector.x = trans.rect.width / 2 + 1f;

        //    transform.position = vector;

        //}



        ////상

        //if (trans.anchoredPosition.y > 0)
        //{

        //    Vector3 vector;

        //    vector = trans.anchoredPosition;

        //    vector.y = -1f;

        //    trans.anchoredPosition = vector;

        //}



        ////하

        //if (trans.anchoredPosition.y - trans.rect.height < Screen.height * -1)
        //{

        //    Vector3 vector;

        //    vector = trans.anchoredPosition;

        //    vector.y = Screen.height * -1 + trans.rect.height;

        //    trans.anchoredPosition = vector;

        //}



        ////우

        //if (trans.anchoredPosition.x + trans.rect.width / 2 > Screen.width)
        //{

        //    Vector3 vector;

        //    vector = trans.anchoredPosition;

        //    vector.x = Screen.width - trans.rect.width / 2;

        //    trans.anchoredPosition = vector;

        //}
>>>>>>> ItemNetwork





    }

<<<<<<< HEAD
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("TriggerEnter");
        if (col.tag == "Player1")
            target = Target.player1;
        if (col.tag == "Player2")
            target = Target.player2;
        if (col.tag == "Player3")
            target = Target.player3;
    }
    void OnTriggerExit(Collider col)
    {
        target = Target.none;
    }
=======
>>>>>>> ItemNetwork
}

