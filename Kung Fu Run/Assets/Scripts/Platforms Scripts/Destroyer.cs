using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public GameObject destroyer;

	// Use this for initialization
	void Start () {
		destroyer = GameObject.Find ("Collector");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < destroyer.transform.position.x) {
			Destroy (gameObject);
		}
	}
}
