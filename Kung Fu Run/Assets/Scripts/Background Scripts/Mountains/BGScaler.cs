using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var height = Camera.main.orthographicSize * 2f;
		var width = height * Screen.width / Screen.height;

        if(gameObject.name == "BackgroundForest" || gameObject.name == "SMBack" || gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, height, 0);
        }

        else if(gameObject.name == "Floor" || gameObject.name == "SMFloor" || gameObject.name == "ForestFloor")
        {
            transform.localScale = new Vector3(width + 50f, 5f, 0);
        }
        
        else
        {
            transform.localScale = new Vector3(width, height, 0);
        }

	}

}
