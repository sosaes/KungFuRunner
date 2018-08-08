using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLooper : MonoBehaviour {

    public float speed;
    private Vector2 offset = Vector2.zero;
    private Material mat;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");

        speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
	}
	
	// Update is called once per frame
	void Update () {
        speed = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
		if(GameplayController.instance.moveBackGround)
        {
            offset.x += speed;
            mat.SetTextureOffset("_MainTex", offset);
        }
	}
}
