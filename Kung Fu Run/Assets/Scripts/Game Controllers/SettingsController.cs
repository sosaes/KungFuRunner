using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public Image settingsPanel;
    public Image infoPanel;
    public Image giftCodePanel;

    public Button musicButton;
    public Text musicText;
    public Sprite musicButtonOn;
    public Sprite musicButtonOff;

    public Button soundButton;
    public Text soundText;
    public Sprite soundButtonOn;
    public Sprite soundButtonOff;

    public Button giftCodeButton;
    public Sprite giftCodeOn;
    public Sprite giftCodeOff;
    public Text giftCodeButtonText;
    public InputField giftCodeInputField;


	// Use this for initialization
	void Start () {

        SetSettingsPanel();
        SetTheButtons();
        SetGiftCodeButton(GamePreferences.GetGiftCodeTries());

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetSettingsPanel()
    {
        infoPanel.gameObject.SetActive(false);
        giftCodePanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(true);
    }

    public void SetInfoPanel()
    {
        giftCodePanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        infoPanel.gameObject.SetActive(true);
    }

    public void SetGiftCodePanel()
    {
        infoPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        giftCodePanel.gameObject.SetActive(true);
    }

    //Buttons

    public void ChangeMusicState()
    {
        int temp = GamePreferences.GetMusicState();  // 0 - Music Off........ 1 - Music On

        if(temp == 0)
            temp = 1;

        else if(temp == 1)
            temp = 0;

        ChangeMusicStateAid(temp);
        //Set music with MusicController
        GamePreferences.SetMusicState(temp);
    }
    public void ChangeMusicStateAid(int value)
    {
        if(value == 0)
        {
            musicButton.image.sprite = musicButtonOff;
            musicText.text = "OFF";
        }

        else if(value == 1)
        {
            musicButton.image.sprite = musicButtonOn;
            musicText.text = "ON";
        }
    }

    public void ChangeSoundState()
    {
        int temp = GamePreferences.GetSoundState(); // 0 - Sound Off.......... 1 - Sound On

        if (temp == 0)
            temp = 1;

        else if (temp == 1)
            temp = 0;

        ChangeSoundStateAid(temp);
        //Set sound with MusicController
        GamePreferences.SetSoundState(temp);
        
    }
    public void ChangeSoundStateAid(int value)
    {
        if(value == 0)
        {
            soundButton.image.sprite = soundButtonOff;
            soundText.text = "OFF";
        }

        else if(value == 1)
        {
            soundButton.image.sprite = soundButtonOn;
            soundText.text = "ON";
        }
    }

    
    public void SetTheButtons()
    {
        ChangeMusicStateAid(GamePreferences.GetMusicState());
        ChangeSoundStateAid(GamePreferences.GetSoundState());
    }

    //Buttons


    //GiftCode

    public void GetGiftCode()
    {
        int temp = GamePreferences.GetGiftCodeTries();

        if(giftCodeInputField.text == "XyBCnvUPxxX0391470")
        {
            GamePreferences.SetCharacterPurchased(1, GamePreferences.krotanaPurchased);
            GamePreferences.SetCharacterPurchased(1, GamePreferences.gukanPurchased);
            GamePreferences.SetCharacterPurchased(1, GamePreferences.hoodPurchased);
            GamePreferences.SetCharacterPurchased(1, GamePreferences.qtowniePurchased);

            GamePreferences.SetRightGiftCode(1);
        }

        else
        {
            giftCodeInputField.text = "Invalid...";
            temp++;
            GamePreferences.SetGiftCodeTries(temp);
        }

        SetGiftCodeButton(temp);
    }

    public void SetGiftCodeButton(int value)
    {
        if(GamePreferences.GetRightGiftCode() == 1)
        {
            giftCodeButton.image.sprite = giftCodeOff;
            giftCodeButtonText.text = "Accepted!";
            giftCodeButton.interactable = false;
            giftCodeInputField.text = "Accepted!";
        }

        else if(value >= 3)
        {
            giftCodeButton.image.sprite = giftCodeOff;
            giftCodeButtonText.text = "Invalid";
            giftCodeButton.interactable = false;
        }

        else
        {
            giftCodeButton.image.sprite = giftCodeOn;
            giftCodeButtonText.text = "Submit";
        }
    }

    //GiftCode

}
