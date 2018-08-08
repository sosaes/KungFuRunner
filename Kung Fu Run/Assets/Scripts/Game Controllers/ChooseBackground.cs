using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBackground : MonoBehaviour {

    public static ChooseBackground instance;


    public GameObject forest;
    public GameObject spaceMountains;

    private int index;


    public int score;
    public Text sHighScore;

	// Use this for initialization
	void Start () {
        MakeInstance();

        SetStartHighScore();
        //index = Random.Range(0, 1);
        ChooseTheBackground();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void ChooseTheBackground()
    {
        //index = Random.Range(0, 1);
        index = GamePreferences.GetBackground();

        if(index == 0)
        {
            forest.gameObject.SetActive(false);
            spaceMountains.gameObject.SetActive(true);

            index = 1;
        }

        else
        {
            spaceMountains.gameObject.SetActive(false);
            forest.gameObject.SetActive(true);

            index = 0;
        }

        GamePreferences.SetBackground(index);

    }


    public int GetBackgroundIndex()
    {
        return index;
    }


    public void SetStartHighScore()
    {
        score = GamePreferences.GetHighScore();
        sHighScore.text = "" + score;
    }

}
