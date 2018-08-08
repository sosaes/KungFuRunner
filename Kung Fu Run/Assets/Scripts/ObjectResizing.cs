using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizing : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.transform.localScale = (gameObject.transform.localScale / (Camera.main.orthographicSize / 2)) * 1.6f;

	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.localScale = gameObject.transform.localScale / Camera.main.orthographicSize;
    }
}
