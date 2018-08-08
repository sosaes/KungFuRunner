using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private Rigidbody2D myBody;
    public float speed;


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
