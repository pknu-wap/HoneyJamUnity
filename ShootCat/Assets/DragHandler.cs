using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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





    void positionCheck()
    {

        RectTransform trans = transform.gameObject.GetComponent<RectTransform>();



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





    }

}

