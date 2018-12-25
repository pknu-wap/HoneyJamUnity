using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class catPawIce : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<AudioSource>().Play();
            
    }

    public void Shake() {
        gameObject.transform.DOShakePosition(duration: 1f, strength: 20f, vibrato: 10);
    }
}
