using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShadeCtr : MonoBehaviour {

	private float speed;
	//private GameSpeedCtr gameSpeed;
	Rigidbody2D myBody;


	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
        //gameSpeed = myBody.GetComponent<GameSpeedCtr> ();
        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
		myBody.velocity = new Vector2(speed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
        myBody.velocity = new Vector2(speed, 0f);
	}
}
