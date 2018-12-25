using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class catPawIce : MonoBehaviour {
    Transform InitTransform;

    void Start () {
        gameObject.GetComponent<AudioSource>().Play();
        InitTransform = gameObject.transform;
    }

    public void Shake() {
        gameObject.transform.position = InitTransform.position;
        gameObject.transform.DOPunchPosition(new Vector3(50, 0, 0), 1);
    }
}
