using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCtr : MonoBehaviour {

    public static ShieldCtr shieldInstance;

    private Transform player;
    private DestroyWithDelay destroyWithDelay;
    public float destroyTime;

    public static bool destroyShield;
    public static bool instantiateShield;

	// Use this for initialization
	void Start () {
        MakeInstance();

        //player = GameObject.Find("CNinja").transform; //Get with player preferences
        SetCharacter();

        transform.position = player.position;

        transform.parent = player;
        
	}
	
	// Update is called once per frame
	void Update () {
        //myBody.position = new Vector2(player.position.x, player.position.y);
        transform.position = player.position;
	}

    void MakeInstance()
    {
        if (shieldInstance == null)
            shieldInstance = this;
    }

    public void DestroyShield()
    {
        Destroy(gameObject);
    }

    public void SetCharacter()
    {
        string name = GamePreferences.GetPlayer();
        if(name == GamePreferences.Ninja)
        {
            player = GameObject.Find("CNinja").transform;
        }
        else if(name == GamePreferences.Krotana)
        {
            player = GameObject.Find("Krotana").transform;
        }
        else if(name == GamePreferences.MasterGukan)
        {
            player = GameObject.Find("MasterGukan").transform;
        }
        else if(name == GamePreferences.Hood)
        {
            player = GameObject.Find("Hood").transform;
        }
        else if(name == GamePreferences.QTownie)
        {
            player = GameObject.Find("QTownie").transform;
        }
    }
}
