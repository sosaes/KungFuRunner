using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedCtr : MonoBehaviour {

    public static GameSpeedCtr gameSpeedCtrInstance = null;

	//private float prvSpeed;

	public float gameSpeed;
    private float gameSpeedStart = -8f;


    private bool timeToSpeedUp;
    private float betweenSpeeding = 5f;
    private float timestamp;

    public static bool restartGameSpeed;


    //Try variables
    public float startTime;
    public float elapsedTime;


	// Use this for initialization
	void Start () {
        //prvSpeed = -6f;
        //gameSpeed = prvSpeed;
		gameSpeed = -8f;

        timestamp = 0f;

        //Try variables
        startTime = Time.time;
        //MakeInstance();
	}

    private void Awake()
    {
        MakeInstance();
    }

    // Update is called once per frame
    void Update () {

        elapsedTime = Time.time - startTime;

        if (GameplayController.instance.increaseGameSpeed)
        {

            if (elapsedTime >= timestamp)
            {
                //timeToSpeedUp = true;
                timestamp = timestamp + betweenSpeeding;
                gameSpeed = gameSpeed - 0.2f;
            }
        }
		//gameSpeed = -6f;
		//gameSpeed = prvSpeed;
	}

    void MakeInstance()
    {
        if(gameSpeedCtrInstance == null)
        {
            gameSpeedCtrInstance = this;
        }
    }
    
    public void RestartStartTime()
    {
        startTime = Time.time;
    }

    public void RestartGameSpeed()
    {
        gameSpeed = -8f;
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    public static void RestartGameSpeedBool()
    {
        restartGameSpeed = false;
    }

    public static void SetGameSpeedBoolTrue()
    {
        restartGameSpeed = true;
    }

    public void OnEnable()
    {
        gameSpeed = -8f;
    }
    

}
