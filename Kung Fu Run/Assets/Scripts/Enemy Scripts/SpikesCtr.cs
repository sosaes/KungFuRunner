using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCtr : MonoBehaviour {

    public float speed;
    private Rigidbody2D myBody;


	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
	}
	
	// Update is called once per frame
	void Update () {
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
        myBody.velocity = new Vector2(speed, 0f);
	}
}
