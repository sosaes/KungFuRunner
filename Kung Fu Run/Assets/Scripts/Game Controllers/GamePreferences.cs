using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {

    //Players
    public static string player = "Player";

    public static string Ninja = "CNinja";
    public static string Krotana = "Krotana";
    public static string MasterGukan = "MasterGukan";
    public static string Hood = "Hood";
    public static string QTownie = "QTownie";

    //Purchased characters ----------------------------- 0 = false; 1 = true
    public static string characterPurchased = "characterPurchased";

    public static string ninjaPurchased = "NinjaPurchased";
    public static string krotanaPurchased = "KrotanaPurchased";
    public static string gukanPurchased = "GukanPurchased";
    public static string hoodPurchased = "HoodPurchased";
    public static string qtowniePurchased = "QTowniePurchased";


    //Characters Index
    public static string characterIndex = "CharacterIndex";


    //LifeCapacity
    public static string lifeCapacity = "lifeCapacity";

    public static string ninjaLifeCapacity = "NinjaLifeCapacity";
    public static string krotanaLifeCapacity = "KrotanaLifeCapacity";
    public static string gukanLifeCapacity = "GukanLifeCapacity";
    public static string hoodLifeCapacity = "HoodLifeCapacity";
    public static string qtownieLifeCapacity = "QTownieLifeCapacity";

    //AttackCooldown
    public static string attackCooldown = "attackCooldown";

    public static string ninjaAttackCooldown = "NinjaAttackCooldown";
    public static string krotanaAttackCooldown = "KrotanaAttackCooldown";
    public static string gukanAttackCooldown = "GukanAttackCooldown";
    public static string hoodAttackCooldown = "HoodAttackCooldown";
    public static string qtownieAttackCooldown = "QTownieAttackCooldown";

    //SuperPowerDuration
    public static string superDuration = "superDuration";

    public static string ninjaSuperDuration = "NinjaSuperDuration";
    public static string krotanaSuperDuration = "KrotanaSuperDuration";
    public static string gukanSuperDuration = "GukanSuperDuration";
    public static string hoodSuperDuration = "HoodSuperDuration";
    public static string qtownieSuperDuration = "QTownieSuperDuration";

    //CharLives
    public static string charLives = "charLives";

    public static string ninjaCharLives = "NinjaCharLives";
    public static string krotanaCharLives = "KrotanaCharLives";
    public static string gukanCharLives = "GukanCharLives";
    public static string hoodCharLives = "HoodCharLives";
    public static string qtownieCharLives = "QTownieCharLives";

    //CharAttack
    public static string charAttack = "charAttack";

    public static string ninjaCharAttack = "NinjaCharAttack";
    public static string krotanaCharAttack = "KrotanaCharAttack";
    public static string gukanCharAttack = "GukanCharAttack";
    public static string hoodCharAttack = "HoodCharAttack";
    public static string qtownieCharAttack = "QTownieCharAttack";

    //CharSuper
    public static string charSuper = "charSuper";

    public static string ninjaCharSuper = "NinjaCharSuper";
    public static string krotanaCharSuper = "KrotanaCharSuper";
    public static string gukanCharSuper = "GukanCharSuper";
    public static string hoodCharSuper = "HoodCharSuper";
    public static string qtownieCharSuper = "QTownieCharSuper";

    //High Score
    public static string highScore;

    //Items
    public static string dumplingCount = "dumplingCount";
    public static string specialCoinCount = "specialCoinCount";

    //Music and Sound
    public static string musicState = "musicState";
    public static string soundState = "soundState";

    //GiftCode
    public static string giftCodeTries = "giftCodeTries";
    public static string rightGiftCode = "rightGiftCode";

    //Backgrounds
    public static string background = "background";

    //Times Played
    public static string timesPlayed = "timesPlayed";


    //Player values----------------------------------------------------------------------

    public static void SetPlayer(string name)
    {
        PlayerPrefs.SetString(player, name);

    }

    public static string GetPlayer()
    {
        return PlayerPrefs.GetString(player);
    }

    //Player values--------------------------------------------------------------------------


    //Characters Purchased-------------------------------------------------------------------

    public static void SetCharacterPurchased(int value, string name)
    {
        PlayerPrefs.SetInt(name, value);
    }

    public static int GetCharacterPurchased(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    //Characters Purchased-------------------------------------------------------------------


    //Character Index-------------------------------------------------------------------

    public static void SetCharacterIndex(int value)
    {
        PlayerPrefs.SetInt(characterIndex, value);
    }

    public static int GetCharacterIndex()
    {
        return PlayerPrefs.GetInt(characterIndex);
    }

    //Character Index-------------------------------------------------------------------


    //Life Capacity----------------------------------------------------------------------

    public static void SetLifeCapacity(int lives, string name)
    {
        PlayerPrefs.SetInt(name, lives);
    }

    public static int GetLifeCapacity(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    //Life Capacity----------------------------------------------------------------------


    //AttackCooldown values----------------------------------------------------------------------

    public static void SetAttackCooldown(float value, string name)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    public static float GetAttackCooldown(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    //AttackCooldown values----------------------------------------------------------------------


    //SuperDuration values----------------------------------------------------------------------

    public static void SetSuperDuration(float value, string name)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    public static float GetSuperDuration(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    //SuperDuration values----------------------------------------------------------------------


    //Character Lives Bar-----------------------------------------------------------------------

    public static void SetCharLives(int value, string name)
    {
        //string temp = GetPlayerStringAidMethod(charLives, name);
        //PlayerPrefs.SetInt(temp, value);
        PlayerPrefs.SetInt(name, value);
    }

    public static int GetCharLives(string name)
    {
        //string temp = GetPlayerStringAidMethod(charLives, name);
        //return PlayerPrefs.GetInt(temp);
        return PlayerPrefs.GetInt(name);
    }

    //Character Lives Bar-----------------------------------------------------------------------


    //Character Attack Bar-----------------------------------------------------------------------

    public static void SetCharAttack(int value, string name)
    {
        PlayerPrefs.SetInt(name, value);
    }

    public static int GetCharAttack(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    //Character Attack Bar-----------------------------------------------------------------------


    //Character Super Bar------------------------------------------------------------------------

    public static void SetCharSuper(int value, string name)
    {
        PlayerPrefs.SetInt(name, value);
    }

    public static int GetCharSuper(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    //Character Super Bar------------------------------------------------------------------------


    //High Score Values------------------------------------------------------------------------------------

    public static void SetHighScore(int value)
    {
        PlayerPrefs.SetInt(highScore, value);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(highScore);
    }

    //High Score Values------------------------------------------------------------------------------------


    //Dumpling Values------------------------------------------------------------------------------------

    public static void SetDumplingCount(int value)
    {
        PlayerPrefs.SetInt(dumplingCount, value);
    }

    public static int GetDumplingCount()
    {
        return PlayerPrefs.GetInt(dumplingCount);
    }

    //Dumpling Values------------------------------------------------------------------------------------


    //Special Coin Values------------------------------------------------------------------------------------

    public static void SetSpecialCoinCount(int value)
    {
        PlayerPrefs.SetInt(specialCoinCount, value);
    }

    public static int GetSpecialCoinCoint()
    {
        return PlayerPrefs.GetInt(specialCoinCount);
    }

    //Special Coin Values------------------------------------------------------------------------------------



    //Music and Sound----------------------------------------------------------------------------------------

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(musicState);
    }
    public static void SetMusicState(int value)
    {
        PlayerPrefs.SetInt(musicState, value);
    }

    public static int GetSoundState()
    {
        return PlayerPrefs.GetInt(soundState);
    }
    public static void SetSoundState(int value)
    {
        PlayerPrefs.SetInt(soundState, value);
    }

    //Music and Sound----------------------------------------------------------------------------------------


    //GiftCode

    public static int GetGiftCodeTries()
    {
        return PlayerPrefs.GetInt(giftCodeTries);
    }

    public static void SetGiftCodeTries(int value)
    {
        PlayerPrefs.SetInt(giftCodeTries, value);
    }

    public static int GetRightGiftCode()
    {
        return PlayerPrefs.GetInt(rightGiftCode);
    }

    public static void SetRightGiftCode(int value)
    {
        PlayerPrefs.SetInt(rightGiftCode, value);
    }

    //GiftCode

    //Background
    public static int GetBackground()
    {
        return PlayerPrefs.GetInt(background);
    }

    public static void SetBackground(int value)
    {
        PlayerPrefs.SetInt(background, value);
    }

    //Times played
    public static int GetTimesPlayed()
    {
        return PlayerPrefs.GetInt(timesPlayed);
    }

    public static void SetTimesPlayed(int value)
    {
        PlayerPrefs.SetInt(timesPlayed, value);
    }


}
