using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderboardsCtr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }
}
