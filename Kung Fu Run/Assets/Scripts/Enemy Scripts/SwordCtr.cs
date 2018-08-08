using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtr : MonoBehaviour {

	private float speed;
	Rigidbody2D myBody;
    //private Collider2D myCollider;

	//private GameSpeedCtr gameSpeed;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
        //myCollider = GetComponent<Collider2D>();

        //gameSpeed = myBody.GetComponent<GameSpeedCtr> ();
        //gameSpeed = GameObject.Find("Spawner").GetComponent<GameSpeedCtr>();
        //speed = gameSpeed.gameSpeed - 4f;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 4f;

		myBody.velocity = new Vector2(speed, 0f);
	}
	
	// Update is called once per frame
	void Update () {

        //speed = gameSpeed.gameSpeed - 4f;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 4f;

        myBody.velocity = new Vector2(speed, 0f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 19 || collision.gameObject.layer == 29)
            Destroy(gameObject);
    }

}
