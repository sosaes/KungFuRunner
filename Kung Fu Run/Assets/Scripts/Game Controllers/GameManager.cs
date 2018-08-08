using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private float attackCooldown = 0.75f;
    private float superDuration = 6f;

    private void Awake()
    {
        MakeSingleton();
    }

    // Use this for initialization
    void Start () {
        InitializeVariables();

        Screen.SetResolution(1280, 720, false);


        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
                Debug.Log("Sign-in successful");
            else
                Debug.Log("Sign-in failes");
        });
        //Social.localUser.Authenticate(ProcessAuthentication);

	}

    /*void ProcessAuthentication(bool success)
    {
        if (success)
            Debug.Log("Success signing in");
        else
            Debug.Log("Sign in unsuccessful");
    }*/
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeSingleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }



    void InitializeVariables()
    {
        //Select ninja as default
        if(!PlayerPrefs.HasKey(GamePreferences.player))
            GamePreferences.SetPlayer(GamePreferences.Ninja);

        //Purchased players
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaPurchased))
            GamePreferences.SetCharacterPurchased(1, GamePreferences.ninjaPurchased);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaPurchased))
            GamePreferences.SetCharacterPurchased(0, GamePreferences.krotanaPurchased);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanPurchased))
            GamePreferences.SetCharacterPurchased(0, GamePreferences.gukanPurchased);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodPurchased))
            GamePreferences.SetCharacterPurchased(0, GamePreferences.hoodPurchased);
        if (!PlayerPrefs.HasKey(GamePreferences.qtowniePurchased))
            GamePreferences.SetCharacterPurchased(0, GamePreferences.qtowniePurchased);

        //Character index
        if (!PlayerPrefs.HasKey(GamePreferences.characterIndex))
            GamePreferences.SetCharacterIndex(0);

        //Life capacity
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaLifeCapacity))
            GamePreferences.SetLifeCapacity(4, GamePreferences.ninjaLifeCapacity);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaLifeCapacity))
            GamePreferences.SetLifeCapacity(4, GamePreferences.krotanaLifeCapacity);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanLifeCapacity))
            GamePreferences.SetLifeCapacity(4, GamePreferences.gukanLifeCapacity);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodLifeCapacity))
            GamePreferences.SetLifeCapacity(4, GamePreferences.hoodLifeCapacity);
        if (!PlayerPrefs.HasKey(GamePreferences.qtownieLifeCapacity))
            GamePreferences.SetLifeCapacity(4, GamePreferences.qtownieLifeCapacity);

        //AttackCooldown
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaAttackCooldown))
            GamePreferences.SetAttackCooldown(attackCooldown, GamePreferences.ninjaAttackCooldown);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaAttackCooldown))
            GamePreferences.SetAttackCooldown(attackCooldown, GamePreferences.krotanaAttackCooldown);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanAttackCooldown))
            GamePreferences.SetAttackCooldown(attackCooldown, GamePreferences.gukanAttackCooldown);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodAttackCooldown))
            GamePreferences.SetAttackCooldown(attackCooldown, GamePreferences.hoodAttackCooldown);
        if (!PlayerPrefs.HasKey(GamePreferences.qtownieAttackCooldown))
            GamePreferences.SetAttackCooldown(attackCooldown, GamePreferences.qtownieAttackCooldown);

        //SuperPower duration
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaSuperDuration))
            GamePreferences.SetSuperDuration(superDuration, GamePreferences.ninjaSuperDuration);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaSuperDuration))
            GamePreferences.SetSuperDuration(superDuration, GamePreferences.krotanaSuperDuration);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanSuperDuration))
            GamePreferences.SetSuperDuration(superDuration, GamePreferences.gukanSuperDuration);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodSuperDuration))
            GamePreferences.SetSuperDuration(superDuration, GamePreferences.hoodSuperDuration);
        if (!PlayerPrefs.HasKey(GamePreferences.qtownieSuperDuration))
            GamePreferences.SetSuperDuration(superDuration, GamePreferences.qtownieSuperDuration);

        //Character Lives Bar
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaCharLives))
            GamePreferences.SetCharLives(0, GamePreferences.ninjaCharLives);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaCharLives))
            GamePreferences.SetCharLives(0, GamePreferences.krotanaCharLives);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanCharLives))
            GamePreferences.SetCharLives(0, GamePreferences.gukanCharLives);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodCharLives))
            GamePreferences.SetCharLives(0, GamePreferences.hoodCharLives);
        if (!PlayerPrefs.HasKey(GamePreferences.qtownieCharLives))
            GamePreferences.SetCharLives(0, GamePreferences.qtownieCharLives);

        //Character Attack Bar
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaCharAttack))
            GamePreferences.SetCharAttack(0, GamePreferences.ninjaCharAttack);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaCharAttack))
            GamePreferences.SetCharAttack(0, GamePreferences.krotanaCharAttack);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanCharAttack))
            GamePreferences.SetCharAttack(0, GamePreferences.gukanCharAttack);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodCharAttack))
            GamePreferences.SetCharAttack(0, GamePreferences.hoodCharAttack);
        if (!PlayerPrefs.HasKey(GamePreferences.qtownieCharAttack))
            GamePreferences.SetCharAttack(0, GamePreferences.qtownieCharAttack);

        //Character SuperPower Bar
        if (!PlayerPrefs.HasKey(GamePreferences.ninjaCharSuper))
            GamePreferences.SetCharSuper(0, GamePreferences.ninjaCharSuper);
        if (!PlayerPrefs.HasKey(GamePreferences.krotanaCharSuper))
            GamePreferences.SetCharSuper(0, GamePreferences.krotanaCharSuper);
        if (!PlayerPrefs.HasKey(GamePreferences.gukanCharSuper))
            GamePreferences.SetCharSuper(0, GamePreferences.gukanCharSuper);
        if (!PlayerPrefs.HasKey(GamePreferences.hoodCharSuper))
            GamePreferences.SetCharSuper(0, GamePreferences.hoodCharSuper);
        if (!PlayerPrefs.HasKey(GamePreferences.qtownieCharSuper))
            GamePreferences.SetCharSuper(0, GamePreferences.qtownieCharSuper);

        //HighScore
        if (!PlayerPrefs.HasKey(GamePreferences.highScore))
            GamePreferences.SetHighScore(0);

        //Dumpling Count
        if (!PlayerPrefs.HasKey(GamePreferences.dumplingCount))
            GamePreferences.SetDumplingCount(0);

        //Special Coin Count
        if (!PlayerPrefs.HasKey(GamePreferences.specialCoinCount))
            GamePreferences.SetSpecialCoinCount(0);

        //Music State
        if (!PlayerPrefs.HasKey(GamePreferences.musicState))
            GamePreferences.SetMusicState(1);
        //Sound State
        if (!PlayerPrefs.HasKey(GamePreferences.soundState))
            GamePreferences.SetSoundState(1);

        //GiftCode Tries
        if (!PlayerPrefs.HasKey(GamePreferences.giftCodeTries))
            GamePreferences.SetGiftCodeTries(0);
        if (!PlayerPrefs.HasKey(GamePreferences.rightGiftCode))
            GamePreferences.SetRightGiftCode(0);

        //Background
        if (!PlayerPrefs.HasKey(GamePreferences.background))
            GamePreferences.SetBackground(0);

        //Times Played
        if (!PlayerPrefs.HasKey(GamePreferences.timesPlayed))
            GamePreferences.SetTimesPlayed(0);


    }
    


}
