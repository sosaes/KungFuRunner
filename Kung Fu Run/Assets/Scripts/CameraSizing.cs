using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizing : MonoBehaviour {

    public float orthographicSize = 5f;
    public float aspect = 1.33333f;


	// Use this for initialization
	void Start () {

        Camera.main.projectionMatrix = Matrix4x4.Ortho(

            -orthographicSize * aspect, orthographicSize * aspect,
            -orthographicSize, orthographicSize,
            Camera.main.nearClipPlane, Camera.main.farClipPlane
            
            );

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
