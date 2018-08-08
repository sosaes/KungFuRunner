using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBar : MonoBehaviour {

    public static PointsBar pointsBarInstance;

    //private DeathCollisions deathCollisions;
    //private bool increasePoints;

    //KillBar Variables
    public static int hitPoint;
    private int maxHitPoint;
    

    private RectTransform myRect;

    
    // Use this for initialization
    void Start () {

        //deathCollisions = GameObject.Find("DeathDetector").GetComponent<DeathCollisions>();
        //increasePoints = deathCollisions.increasePoints;

        myRect = GetComponent<RectTransform>();

        //KillBar
        hitPoint = 0;
        maxHitPoint = 10;
        //UpdateKillBar();

        MakeInstance();
    }
	
	// Update is called once per frame
	void Update () {

        //GameplayController.instance.UpdateKillBar();
        //increasePoints = deathCollisions.increasePoints;
        //if(increasePoints)
        //IncreaseKillBar();
	}

    void MakeInstance()
    {
        if (pointsBarInstance == null)
            pointsBarInstance = this;
    }

    /*

    //Update KillBar
    public void UpdateKillBar()
    {
        float ratio = hitPoint / maxHitPoint;
        //current.localScale = new Vector3(1, ratio, 1);
        myRect.localScale = new Vector3(1, ratio, 1);
    }

    public void IncreaseKillBar()
    {
        if (hitPoint < maxHitPoint)
            hitPoint += 1;
        UpdateKillBar();
    }

    /*private void RestartKillBar()
    {
        hitPoint = 0;
        UpdateKillBar();
    }*/

    

}
