using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodShadeCtr : MonoBehaviour {

    public static GoodShadeCtr goodShadeCtrInstance;

    //private Collider2D myCollider;
    private Rigidbody2D myBody;
    private DestroyWithDelay destroyWithDelay;
    public float destroyTime;
    public static float temp;


    // Use this for initialization
    void Start () {

        MakeInstance();

        SoundController.instance.PlayAttack();

        //myCollider = GetComponent<Collider2D>();
        myBody = GetComponent<Rigidbody2D>();
        destroyWithDelay = GetComponent<DestroyWithDelay>();
        destroyTime = 0.2f; //0.25f; //0.15f; //Get from player preferences;
        temp = destroyTime;
        destroyWithDelay.delay = temp; ;
        
    }
	
	// Update is called once per frame
	void Update () {
        myBody.velocity = new Vector2(10f, 0f);
        //destroyWithDelay.delay = temp;
    }

    void MakeInstance()
    {
        if (goodShadeCtrInstance == null)
            goodShadeCtrInstance = this;
    }

    public void IncreaseDestroyTime()
    {
        temp = 10f;
        destroyWithDelay.delay = temp;
    }

    public void ResetDestroyTime()
    {
        temp = destroyTime;
        destroyWithDelay.delay = temp;
    }

}
