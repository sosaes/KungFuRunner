using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    public float speed;
	private Vector2 offset = Vector2.zero;
	private Material mat;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameplayController.instance.moveBackGround)
        {
            offset.x += speed * Time.deltaTime;
            mat.SetTextureOffset("_MainTex", offset);
        }
	}


    public int SetSpeedOfPlanes()
    {
        if(gameObject.tag == "Plane1")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 7.7f;
        }

        else if(gameObject.tag == "Plane2")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 7.75f;
        }

        else if(gameObject.tag == "Plane3")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 7.8f;
        }

        else if(gameObject.tag == "Plane4")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 7.85f;
        }

        else if(gameObject.tag == "Plane5")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 7.9f;
        }

        else if(gameObject.tag == "Plane6")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed() - 7.95f;
        }

        else if(gameObject.tag == "Floor")
        {
            speed = -GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();
        }

        return 0;

    }


}
