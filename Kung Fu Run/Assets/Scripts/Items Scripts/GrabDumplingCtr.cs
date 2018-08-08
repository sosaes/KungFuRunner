﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDumplingCtr : MonoBehaviour {

    private Rigidbody2D myBody;
    private float horizontalSpeed;//= -5f;
    private float verticalSpeed;// = 2f;
    private float height = 1f;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        horizontalSpeed = Random.Range(-7f, -3f);
        verticalSpeed = Random.Range(2f, 8f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        float newY = Mathf.Sin(Time.time * verticalSpeed);
        transform.position = new Vector3(position.x, newY, -3) * height;
        myBody.velocity = new Vector2(horizontalSpeed, myBody.velocity.y);
    }



}
