using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpShapeCtr : MonoBehaviour {

    private Rigidbody2D myBody;
    private float speed;
    //private GameSpeedCtr gameSpeed;

	// Use this for initialization
	void Start () {

        myBody = GetComponent<Rigidbody2D>();
        //  gameSpeed = GameObject.Find("Spawner").GetComponent<GameSpeedCtr>();
        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

    }
	
	// Update is called once per frame
	void Update () {

        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
        myBody.velocity = new Vector2(speed, myBody.velocity.y);

	}
}
