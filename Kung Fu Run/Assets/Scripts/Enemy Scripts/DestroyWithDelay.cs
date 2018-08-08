using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour {

    //public static DestroyWithDelay destroyWithDelayInstance;

	public float delay;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, delay);
	}
    

}
