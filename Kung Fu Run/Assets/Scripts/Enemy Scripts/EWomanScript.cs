using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EWomanScript : MonoBehaviour {

	public GameObject sword;
	Transform swordPos;

	private float speed;
	private Rigidbody2D woman;
	private Animator anim;
	private Collider2D myCollider;

	//private GameSpeedCtr gameSpeed;

    private Rigidbody2D swordBody;

    private bool grounded;
    public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		swordPos = transform.Find ("SwordThrower");
		InvokeRepeating ("Throw", 0, 1.5f); //1.75

		myCollider = GetComponent<Collider2D> ();
		woman = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		InvokeRepeating ("Animate", 0, 1.5f); //1.75

        //gameSpeed = woman.GetComponent<GameSpeedCtr> ();
        //gameSpeed = GameObject.Find("Spawner").GetComponent<GameSpeedCtr>();
        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

        swordBody = swordPos.GetComponent<Rigidbody2D>();
        swordBody.isKinematic = true;

	}
	
	// Update is called once per frame
	void Update () {
        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
		woman.velocity = new Vector2 (speed, 0f);

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

	}

	void Throw() {
        if(grounded)
            Instantiate (sword, swordPos.position, Quaternion.identity);
	}

	void Animate() {
        if(grounded)
            anim.SetTrigger ("EAttack");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 19 || collision.gameObject.layer == 29)
        {
            //swordBody.isKinematic = false;
            CancelInvoke();
        }
    }

}
