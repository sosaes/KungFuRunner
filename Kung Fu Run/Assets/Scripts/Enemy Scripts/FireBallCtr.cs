using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCtr : MonoBehaviour {

	private float speed;
	//public float speed;
	private Rigidbody2D myBody;
    //private Collider2D myCollider;

	//private GameSpeedCtr gameSpeed;
    private bool destroyFire;
    

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();

        //gameSpeed = myBody.GetComponent<GameSpeedCtr> ();
        //gameSpeed = GameObject.Find("Spawner").GetComponent<GameSpeedCtr>();

        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

		myBody.velocity = new Vector2(speed, 0f);

        //myCollider = GetComponent<Collider2D>();

        //destroyFire = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

		myBody.velocity = new Vector2(speed, 0f);
		transform.Rotate (Vector3.forward * Time.deltaTime * 40);

        //destroyFire = Physics2D.IsTouchingLayers(myCollider, 19);

        

	}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 19)
            Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 19 || collision.gameObject.layer == 29)
            Destroy(gameObject);
    }

}
