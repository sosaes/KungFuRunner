using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour {

	//private float speed = -6f;
	private Rigidbody2D myBody;

	private float speed;


    public Sprite forest;
    public Sprite spaceMountain;
    //private SpriteRenderer spriteRenderer;

	//private GameSpeedCtr gameSpeed;

	//public GameObject platform;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();

        SelectSprite();

        //spriteRenderer = GetComponent<SpriteRenderer>();

        //gameSpeed = myBody.GetComponent<GameSpeedCtr> ();
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



    public void SelectSprite()
    {
        if(GamePreferences.GetBackground() == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spaceMountain;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forest;
        }
    }

}
