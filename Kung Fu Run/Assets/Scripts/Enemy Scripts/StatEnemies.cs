using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatEnemies : MonoBehaviour {

	private float speed;
	private Rigidbody2D myBody;
	private Animator anim;

	//private GameSpeedCtr gameSpeed;
    

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        //gameSpeed = GameObject.Find("Spawner").GetComponent<GameSpeedCtr>();
        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
        
	}

    
	
	// Update is called once per frame
	void Update () {

        //speed = gameSpeed.gameSpeed;
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

		myBody.velocity = new Vector2 (speed, 0f);

       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 12)
        {
            anim.SetTrigger("EAttack");
        }
    }
    

}
