using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour {

	public GameObject fireBall;
	Transform firePos;
    private bool isDying;
    //private Animator anim;
    private bool isDead;
    private Rigidbody2D myBody;
    //private Collider2D myCollider;


    private Rigidbody2D firePosBody;

    public bool destroyFire;

    private float gameSpeed;

    //private GameSpeedCtr gamespeed;
    

    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        //gameSpeed = GameSpeedCtr.gameSpeedCtrInstance.gameSpeed;
        gameSpeed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

		firePos = transform.Find ("FireBall");
		InvokeRepeating ("Fire", 0.5f, 2f);

        firePosBody = firePos.GetComponent<Rigidbody2D>();
        firePosBody.isKinematic = true;

        destroyFire = false;
	}
	
	// Update is called once per frame
	void Update () {

        //gameSpeed = GameSpeedCtr.gameSpeedCtrInstance.gameSpeed;
        gameSpeed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
        myBody.velocity = new Vector2(gameSpeed, 0f);

	}

	void Fire() {
        Instantiate(fireBall, firePos.position, Quaternion.identity);
	}
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 19 || collision.gameObject.layer == 29)
        {
            //firePosBody.isKinematic = false;
            CancelInvoke();
            destroyFire = true;
        }
    }
    


}
