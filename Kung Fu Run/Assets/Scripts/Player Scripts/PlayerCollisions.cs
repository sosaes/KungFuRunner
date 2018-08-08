using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    private PlayerScore playerScore;
    private Collider2D myCollider;
    private Rigidbody2D myBody;

	// Use this for initialization
	void Start () {

        playerScore = GameObject.Find("Player").GetComponent<PlayerScore>();
        myCollider = GetComponent<Collider2D>();
        myBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 22 || collision.gameObject.layer == 23)
            myBody.isKinematic = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 22 || collision.gameObject.layer == 23)
            myBody.isKinematic = false;
    }

}
