using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelectionController : MonoBehaviour {

    public static CharSelectionController instance;

    //Previous and Next Buttons
    public Button nextButton;
    public Button prevButton;

    //Select Buttons
    public Button ninjaSelectButton;
    public Text ninjaSelectText;
    public Button krotanaSelectButton;
    public Text krotanaSelectText;
    public Button gukanSelectButton;
    public Text gukanSelectText;
    public Button hoodSelectButton;
    public Text hoodSelectText;
    public Button qtownieSelectButton;
    public Text qtownieSelectText;

    //Purchase Buttons
    public Button krotanaPurchaseButton;
    public Button gukanPurchaseButton;
    public Button hoodPurchaseButton;
    public Button qtowniePurchaseButton;

    //Character Panels
    public GameObject[] characters;

    //Lives
    public Text livesCountText;
    public Text livesUpgradeText;
    public Image[] livesLights;

    //AttackCooldown
    public Text attackCountText;
    public Text attackUpgradeText;
    public Image[] attackLights;

    //SuperPower
    public Text superCountText;
    public Text superUpgradeText;
    public Image[] superLights;

    //Bars strings
    public string livesString = "livesString";
    public string attackString = "attackString";
    public string superString = "superString";


    //Player prices
    private int krotanaPrice = 8500;
    private int gukanPrice = 3500;
    private int hoodPrice = 7;
    private int qtowniePrice = 8;


    //Variables for next and prev button to select character on display
    private int characterIndex;

    //Upgrade Buttons
    public Button livesUpgradeButton;
    public Text livesUpgradeButtonText;
    public Button attackUpgradeButton;
    public Text attackUpgradeButtonText;
    public Button superUpgradeButton;
    public Text superUpgradeButtonText;

    //CoinTexts
    public Text dumplingCountStart;
    public Text dumplingCountChar;
    public Text rubyCountStart;
    public Text rubyCountChar;


    //Test lives
    public int testLives;

    


    private void Awake()
    {
        MakeInstance();
    }

    // Use this for initialization
    void Start ()
    {

        SetCount();
        //testLives = GamePreferences.GetLifeCapacity(GamePreferences.ninjaLifeCapacity);
        //GamePreferences.SetCharLives(0, GamePreferences.ninjaCharLives);
        //GamePreferences.SetCharAttack(0, GamePreferences.ninjaCharAttack);
        //GamePreferences.SetCharSuper(0, GamePreferences.ninjaCharSuper);
        //GamePreferences.SetCharLives(0, GamePreferences.krotanaCharLives);
        //GamePreferences.SetCharLives(0, GamePreferences.gukanCharLives);
        //GamePreferences.SetCharacterPurchased(0, GamePreferences.krotanaPurchased);

        //GamePreferences.SetDumplingCount(53000);

        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteAll();



        characterIndex = GamePreferences.GetCharacterIndex();
        InitializedVariables();

        //Coin Count
        SetCoinCount();
        SetCountTexts();
	}


    //Get CharacterIndex
    public int GetCharacterIndex()
    {
        return characterIndex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }


    //Initialized variables
    public void InitializedVariables()
    {
        string characterName;
        string characterLivesName;
        string characterAttackName;
        string characterSuperName;

        int index = GamePreferences.GetCharacterIndex();

        characterName = GetNameFromIndex(index);
        characterLivesName = GetCharLivesNameFromIndex(index);
        characterAttackName = GetCharAttackNameFromIndex(index);
        characterSuperName = GetCharSuperNameFromIndex(index);


        //Set character
        SetCharacter(index);

        //Reset bars
        ResetBar(livesString);
        ResetBar(attackString);
        ResetBar(superString);

        //Set bars
        SetLivesBar(characterLivesName);
        SetAttackBar(characterAttackName);
        SetSuperPowerBar(characterSuperName);
        
        //Set purchase and select buttons
        SetPurchaseButtons(characterIndex);
        SetSelectButtons(characterIndex);

        /*
        //Erase and Set Upgrade Buttons
        EraseAllUpgradeButtons();
        SetUpgradeButtons(characterIndex);*/

        //Set Upgrade Buttons
        SetTheUpgradeButtons(characterIndex);
    }

    public void SetCount()
    {
        dumplingCountStart.text = "" + GamePreferences.GetDumplingCount();
        dumplingCountChar.text = "" + GamePreferences.GetDumplingCount();
        rubyCountStart.text = "" + GamePreferences.GetSpecialCoinCoint();
        rubyCountChar.text = "" + GamePreferences.GetSpecialCoinCoint();
    }


    //Restart bars
    public void ResetBar(string type)
    {
        if (type == livesString)
            for (int i = 0; i < livesLights.Length; i++)
                livesLights[i].enabled = false;

        else if (type == attackString)
            for (int i = 0; i < attackLights.Length; i++)
                attackLights[i].enabled = false;

        else if (type == superString)
            for (int i = 0; i < superLights.Length; i++)
                superLights[i].enabled = false;
    }//Restart Bars------------------------------------------


    //Set lives bar
    public void SetLivesBar(string name)
    {
        int temp = 0;
        temp = GamePreferences.GetCharLives(name);
        for(int i = 0; i < temp; i ++)
        {
            livesLights[i].enabled = true;
        }
    }
    //Set lives bar


    //Set attack bar
    public void SetAttackBar(string name)
    {
        int temp = 0;
        temp = GamePreferences.GetCharAttack(name);
        for (int i = 0; i < temp; i++)
        {
            attackLights[i].enabled = true;
        }
    }
    //Set attack bar


    //Set superpower bar
    public void SetSuperPowerBar(string name)
    {
        int temp = 0;
        temp = GamePreferences.GetCharSuper(name);
        for(int i = 0; i < temp; i ++)
        {
            superLights[i].enabled = true;
        }
    }
    //Set superpower bar


    //Set character anim
    public void SetCharacter(int value)
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[value].SetActive(true);
    }


    //Get name from index
    public string GetNameFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.Ninja;
        else if (index == 1)
            return GamePreferences.Krotana;
        else if (index == 2)
            return GamePreferences.MasterGukan;
        else if (index == 3)
            return GamePreferences.Hood;
        else if (index == 4)
            return GamePreferences.QTownie;

        return "";
    }
    //Get charLives from index
    public string GetCharLivesNameFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaCharLives;
        else if (index == 1)
            return GamePreferences.krotanaCharLives;
        else if (index == 2)
            return GamePreferences.gukanCharLives;
        else if (index == 3)
            return GamePreferences.hoodCharLives;
        else if (index == 4)
            return GamePreferences.qtownieCharLives;

        return "";
    }
    //Get lifeCapacity of player from index
    public string GetLifeCapacityFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaLifeCapacity;
        else if (index == 1)
            return GamePreferences.krotanaLifeCapacity;
        else if (index == 2)
            return GamePreferences.gukanLifeCapacity;
        else if (index == 3)
            return GamePreferences.hoodLifeCapacity;
        else if (index == 4)
            return GamePreferences.qtownieLifeCapacity;

        return "";
    }
    //Get charAttack from index
    public string GetCharAttackNameFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaCharAttack;
        else if (index == 1)
            return GamePreferences.krotanaCharAttack;
        else if (index == 2)
            return GamePreferences.gukanCharAttack;
        else if (index == 3)
            return GamePreferences.hoodCharAttack;
        else if (index == 4)
            return GamePreferences.qtownieCharAttack;

        return "";
    }
    //get attackCooldown of player from index
    public string GetAttackCoolDownFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaAttackCooldown;
        else if (index == 1)
            return GamePreferences.krotanaAttackCooldown;
        else if (index == 2)
            return GamePreferences.gukanAttackCooldown;
        else if (index == 3)
            return GamePreferences.hoodAttackCooldown;
        else if (index == 4)
            return GamePreferences.qtownieAttackCooldown;

        return "";
    }
    //Get charSuper from index
    public string GetCharSuperNameFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaCharSuper;
        else if (index == 1)
            return GamePreferences.krotanaCharSuper;
        else if (index == 2)
            return GamePreferences.gukanCharSuper;
        else if (index == 3)
            return GamePreferences.hoodCharSuper;
        else if (index == 4)
            return GamePreferences.qtownieCharSuper;

        return "";
    }
    //Get superDuration of player from index
    public string GetSuperDurationFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaSuperDuration;
        else if (index == 1)
            return GamePreferences.krotanaSuperDuration;
        else if (index == 2)
            return GamePreferences.gukanSuperDuration;
        else if (index == 3)
            return GamePreferences.hoodSuperDuration;
        else if (index == 4)
            return GamePreferences.qtownieSuperDuration;

        return "";
    }
    //Get charPurchase from index
    public string GetCharPurchaseNameFromIndex(int index)
    {
        if (index == 0)
            return GamePreferences.ninjaPurchased;
        else if (index == 1)
            return GamePreferences.krotanaPurchased;
        else if (index == 2)
            return GamePreferences.gukanPurchased;
        else if (index == 3)
            return GamePreferences.hoodPurchased;
        else if (index == 4)
            return GamePreferences.qtowniePurchased;

        return "";
    }


    //Next Button
    public void NextButton()
    {
        //Increase index
        /*int temp = GamePreferences.GetCharacterIndex();
        temp++;
        if (temp == characters.Length)
            temp = 0;*/
        characterIndex++;
        if (characterIndex == characters.Length)
            characterIndex = 0;

        string characterName;
        string characterLivesName;
        string characterAttackName;
        string characterSuperName;

        characterName = GetNameFromIndex(characterIndex);
        characterLivesName = GetCharLivesNameFromIndex(characterIndex);
        characterAttackName = GetCharAttackNameFromIndex(characterIndex);
        characterSuperName = GetCharSuperNameFromIndex(characterIndex);


        //Set character
        SetCharacter(characterIndex);

        //Reset bars
        ResetBar(livesString);
        ResetBar(attackString);
        ResetBar(superString);

        //Set bars
        SetLivesBar(characterLivesName);
        SetAttackBar(characterAttackName);
        SetSuperPowerBar(characterSuperName);

        //Set purchase and select buttons
        SetPurchaseButtons(characterIndex);
        SetSelectButtons(characterIndex);

        /*
        //Erase and Set Upgrade Buttons
        EraseAllUpgradeButtons();
        SetUpgradeButtons(characterIndex);*/

        //Set Upgrade Buttons
        SetTheUpgradeButtons(characterIndex);
        SetCountTexts();
        
        
    }


    //Previous Button
    public void PrevButton()
    {
        //Decrease index
        /*int temp = GamePreferences.GetCharacterIndex();
        temp--;
        if (temp == -1)
            temp = characters.Length - 1;*/
        characterIndex--;
        if (characterIndex == -1)
            characterIndex = characters.Length - 1;

        string characterName;
        string characterLivesName;
        string characterAttackName;
        string characterSuperName;

        characterName = GetNameFromIndex(characterIndex);
        characterLivesName = GetCharLivesNameFromIndex(characterIndex);
        characterAttackName = GetCharAttackNameFromIndex(characterIndex);
        characterSuperName = GetCharSuperNameFromIndex(characterIndex);


        //Set character
        SetCharacter(characterIndex);

        //Reset bars
        ResetBar(livesString);
        ResetBar(attackString);
        ResetBar(superString);

        //Set bars
        SetLivesBar(characterLivesName);
        SetAttackBar(characterAttackName);
        SetSuperPowerBar(characterSuperName);

        //Set purchase and select buttons
        SetPurchaseButtons(characterIndex);
        SetSelectButtons(characterIndex);

        /*
        //Erase and Set Upgrade Buttons
        EraseAllUpgradeButtons();
        SetUpgradeButtons(characterIndex);*/

        //Set Upgrade Buttons
        SetTheUpgradeButtons(characterIndex);

        SetCountTexts();

    }


    //Set purchase buttons
    public void SetPurchaseButtons(int index)
    {
        //krotanaPurchaseButton.interactable = false;
        krotanaPurchaseButton.gameObject.SetActive(false);
        //gukanPurchaseButton.interactable = false;
        gukanPurchaseButton.gameObject.SetActive(false);
        hoodPurchaseButton.gameObject.SetActive(false);
        qtowniePurchaseButton.gameObject.SetActive(false);

        if(index == 1 && GamePreferences.GetCharacterPurchased(GamePreferences.krotanaPurchased) == 0)
        {
            //krotanaPurchaseButton.interactable = true;
            krotanaPurchaseButton.gameObject.SetActive(true);
        }

        else if(index == 2 && GamePreferences.GetCharacterPurchased(GamePreferences.gukanPurchased) == 0)
        {
            //gukanPurchaseButton.interactable = true;
            gukanPurchaseButton.gameObject.SetActive(true);
        }

        else if(index == 3 && GamePreferences.GetCharacterPurchased(GamePreferences.hoodPurchased) == 0)
        {
            hoodPurchaseButton.gameObject.SetActive(true);
        }

        else if(index == 4 && GamePreferences.GetCharacterPurchased(GamePreferences.qtowniePurchased) == 0)
        {
            qtowniePurchaseButton.gameObject.SetActive(true);
        }
    }

    //Set select buttons
    public void SetSelectButtons(int index)
    {
        //ninjaSelectButton.interactable = false;
        ninjaSelectButton.gameObject.SetActive(false);
        //krotanaSelectButton.interactable = false;
        krotanaSelectButton.gameObject.SetActive(false);
        //gukanSelectButton.interactable = false;
        gukanSelectButton.gameObject.SetActive(false);

        hoodSelectButton.gameObject.SetActive(false);
        qtownieSelectButton.gameObject.SetActive(false);

        if(index == 0)
        {
            //ninjaSelectButton.interactable = true;
            ninjaSelectButton.gameObject.SetActive(true);
            if(GamePreferences.GetPlayer() == GamePreferences.Ninja)
            {
                ninjaSelectText.text = "Selected";
            }

            else
            {
                ninjaSelectText.text = "Select";
            }
        }

        else if(index == 1 && GamePreferences.GetCharacterPurchased(GamePreferences.krotanaPurchased) == 1)
        {
            //krotanaSelectButton.interactable = true;
            krotanaSelectButton.gameObject.SetActive(true);
            if(GamePreferences.GetPlayer() == GamePreferences.Krotana)
            {
                krotanaSelectText.text = "Selected";
            }

            else
            {
                krotanaSelectText.text = "Select";
            }
        }

        else if(index == 2 && GamePreferences.GetCharacterPurchased(GamePreferences.gukanPurchased) == 1)
        {
            //gukanSelectButton.interactable = true;
            gukanSelectButton.gameObject.SetActive(true);
            if(GamePreferences.GetPlayer() == GamePreferences.MasterGukan)
            {
                gukanSelectText.text = "Selected";
            }

            else
            {
                gukanSelectText.text = "Select";
            }
        }

        else if(index == 3 && GamePreferences.GetCharacterPurchased(GamePreferences.hoodPurchased) == 1)
        {
            hoodSelectButton.gameObject.SetActive(true);
            if(GamePreferences.GetPlayer() == GamePreferences.Hood)
            {
                hoodSelectText.text = "Selected";
            }

            else
            {
                hoodSelectText.text = "Select";
            }
        }

        else if(index == 4 && GamePreferences.GetCharacterPurchased(GamePreferences.qtowniePurchased) == 1)
        {
            qtownieSelectButton.gameObject.SetActive(true);
            if(GamePreferences.GetPlayer() == GamePreferences.QTownie)
            {
                qtownieSelectText.text = "Selected";
            }

            else
            {
                qtownieSelectText.text = "Select";
            }
        }
    }


    //Set Upgrade Buttons
    public void SetTheUpgradeButtons(int index)
    {
        livesUpgradeButton.interactable = true;
        attackUpgradeButton.interactable = true;
        superUpgradeButton.interactable = true;

        if (index == 0)
        {
            if(GamePreferences.GetCharLives(GamePreferences.ninjaCharLives) < 14)
                livesUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharLives(GamePreferences.ninjaCharLives));
            if(GamePreferences.GetCharLives(GamePreferences.ninjaCharLives) == 14)
            {
                livesUpgradeButtonText.text = "Full";
                livesUpgradeButton.interactable = false;
            }

            if(GamePreferences.GetCharAttack(GamePreferences.ninjaCharAttack) < 14)
                attackUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharAttack(GamePreferences.ninjaCharAttack));
            if(GamePreferences.GetCharAttack(GamePreferences.ninjaCharAttack) == 14)
            {
                attackUpgradeButtonText.text = "Full";
                attackUpgradeButton.interactable = false;
            }

            if(GamePreferences.GetCharSuper(GamePreferences.ninjaCharSuper) < 14)
                superUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharSuper(GamePreferences.ninjaCharSuper));
            if(GamePreferences.GetCharSuper(GamePreferences.ninjaCharSuper) == 14)
            {
                superUpgradeButtonText.text = "Full";
                superUpgradeButton.interactable = false;
            }
        }

        else if(index == 1)
        {
            if (GamePreferences.GetCharacterPurchased(GamePreferences.krotanaPurchased) == 0)
            {
                livesUpgradeButton.interactable = false;
                attackUpgradeButton.interactable = false;
                superUpgradeButton.interactable = false;
            }

            else
            {

                if (GamePreferences.GetCharLives(GamePreferences.krotanaCharLives) < 14)
                    livesUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharLives(GamePreferences.krotanaCharLives));
                if (GamePreferences.GetCharLives(GamePreferences.krotanaCharLives) == 14)
                {
                    livesUpgradeButtonText.text = "Full";
                    livesUpgradeButton.interactable = false;
                }

                if (GamePreferences.GetCharAttack(GamePreferences.krotanaCharAttack) < 14)
                    attackUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharAttack(GamePreferences.krotanaCharAttack));
                if (GamePreferences.GetCharAttack(GamePreferences.krotanaCharAttack) == 14)
                {
                    attackUpgradeButtonText.text = "Full";
                    attackUpgradeButton.interactable = false;
                }

                if (GamePreferences.GetCharSuper(GamePreferences.krotanaCharSuper) < 14)
                    superUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharSuper(GamePreferences.krotanaCharSuper));
                if (GamePreferences.GetCharSuper(GamePreferences.krotanaCharSuper) == 14)
                {
                    superUpgradeButtonText.text = "Full";
                    superUpgradeButton.interactable = false;
                }
            }

            SetCountTexts();

        }

        else if(index == 2)
        {
            if (GamePreferences.GetCharacterPurchased(GamePreferences.gukanPurchased) == 0)
            {
                livesUpgradeButton.interactable = false;
                attackUpgradeButton.interactable = false;
                superUpgradeButton.interactable = false;
            }
            else
            {
                if(GamePreferences.GetCharLives(GamePreferences.gukanCharLives) < 14)
                    livesUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharLives(GamePreferences.gukanCharLives));
                if(GamePreferences.GetCharLives(GamePreferences.gukanCharLives) == 14)
                {
                    livesUpgradeButtonText.text = "Full";
                    livesUpgradeButton.interactable = false;
                }

                if(GamePreferences.GetCharAttack(GamePreferences.gukanCharAttack) < 14)
                    attackUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharAttack(GamePreferences.gukanCharAttack));
                if(GamePreferences.GetCharAttack(GamePreferences.gukanCharAttack) == 14)
                {
                    attackUpgradeButtonText.text = "Full";
                    attackUpgradeButton.interactable = false;
                }

                if(GamePreferences.GetCharSuper(GamePreferences.gukanCharSuper) < 14)
                    superUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharSuper(GamePreferences.gukanCharSuper));
                if(GamePreferences.GetCharSuper(GamePreferences.gukanCharSuper) == 14)
                {
                    superUpgradeButtonText.text = "Full";
                    superUpgradeButton.interactable = false;
                }
            }
        }

        else if (index == 3)
        {
            if (GamePreferences.GetCharacterPurchased(GamePreferences.hoodPurchased) == 0)
            {
                livesUpgradeButton.interactable = false;
                attackUpgradeButton.interactable = false;
                superUpgradeButton.interactable = false;
            }
            else
            {
                if (GamePreferences.GetCharLives(GamePreferences.hoodCharLives) < 14)
                    livesUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharLives(GamePreferences.hoodCharLives));
                if (GamePreferences.GetCharLives(GamePreferences.hoodCharLives) == 14)
                {
                    livesUpgradeButtonText.text = "Full";
                    livesUpgradeButton.interactable = false;
                }

                if (GamePreferences.GetCharAttack(GamePreferences.hoodCharAttack) < 14)
                    attackUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharAttack(GamePreferences.hoodCharAttack));
                if (GamePreferences.GetCharAttack(GamePreferences.hoodCharAttack) == 14)
                {
                    attackUpgradeButtonText.text = "Full";
                    attackUpgradeButton.interactable = false;
                }

                if (GamePreferences.GetCharSuper(GamePreferences.hoodCharSuper) < 14)
                    superUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharSuper(GamePreferences.hoodCharSuper));
                if (GamePreferences.GetCharSuper(GamePreferences.hoodCharSuper) == 14)
                {
                    superUpgradeButtonText.text = "Full";
                    superUpgradeButton.interactable = false;
                }
            }
        }

        else if (index == 4)
        {
            if (GamePreferences.GetCharacterPurchased(GamePreferences.qtowniePurchased) == 0)
            {
                livesUpgradeButton.interactable = false;
                attackUpgradeButton.interactable = false;
                superUpgradeButton.interactable = false;
            }
            else
            {
                if (GamePreferences.GetCharLives(GamePreferences.qtownieCharLives) < 14)
                    livesUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharLives(GamePreferences.qtownieCharLives));
                if (GamePreferences.GetCharLives(GamePreferences.qtownieCharLives) == 14)
                {
                    livesUpgradeButtonText.text = "Full";
                    livesUpgradeButton.interactable = false;
                }

                if (GamePreferences.GetCharAttack(GamePreferences.qtownieCharAttack) < 14)
                    attackUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharAttack(GamePreferences.qtownieCharAttack));
                if (GamePreferences.GetCharAttack(GamePreferences.qtownieCharAttack) == 14)
                {
                    attackUpgradeButtonText.text = "Full";
                    attackUpgradeButton.interactable = false;
                }

                if (GamePreferences.GetCharSuper(GamePreferences.qtownieCharSuper) < 14)
                    superUpgradeButtonText.text = "" + GetPriceFromLights(GamePreferences.GetCharSuper(GamePreferences.qtownieCharSuper));
                if (GamePreferences.GetCharSuper(GamePreferences.qtownieCharSuper) == 14)
                {
                    superUpgradeButtonText.text = "Full";
                    superUpgradeButton.interactable = false;
                }
            }
        }
    }



    //Get price for upgrades from lights
    public int GetPriceFromLights(int lights)
    {
        if (lights == 0)
            return 200;
        else if (lights == 1)
            return 300;
        else if (lights == 2)
            return 400;
        else if (lights == 3)
            return 500;
        else if (lights == 4)
            return 600;
        else if (lights == 5)
            return 700;
        else if (lights == 6)
            return 800;
        else if (lights == 7)
            return 900;
        else if (lights == 8)
            return 1000;
        else if (lights == 9)
            return 1100;
        else if (lights == 10)
            return 1200;
        else if (lights == 11)
            return 1300;
        else if (lights == 12)
            return 1400;
        else if (lights == 13)
            return 1500;
        else if (lights == 14)
            return 1600;

        return 100;
    }



    //Select Button
    public void SelectButton()
    {
        GamePreferences.SetCharacterIndex(characterIndex);
        string charName = GetNameFromIndex(characterIndex);
        GamePreferences.SetPlayer(charName);
        SetSelectButtons(characterIndex);
    }

    //Purchase Krotana Button
    public void PurchaseKrotanaButton()
    {
        int temp = GamePreferences.GetDumplingCount();
        if (temp >= krotanaPrice)
        {
            temp -= krotanaPrice;
            GamePreferences.SetCharacterPurchased(1, GamePreferences.krotanaPurchased);
            GamePreferences.SetDumplingCount(temp);
            SetPurchaseButtons(characterIndex);
            SetSelectButtons(characterIndex);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
        }
        else
        {
            //SET PURCHASE COINS PANEL
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetDumplingStore();
        }
    }

    //Purchase Gukan Button
    public void PurchaseGukanButton()
    {
        int temp = GamePreferences.GetDumplingCount();
        if (temp >= gukanPrice)
        {
            temp -= gukanPrice;
            GamePreferences.SetCharacterPurchased(1, GamePreferences.gukanPurchased);
            GamePreferences.SetDumplingCount(temp);
            SetPurchaseButtons(characterIndex);
            SetSelectButtons(characterIndex);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
        }
        else
        {
            //SET PURCHASE COINS PANEL
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetDumplingStore();
        }
    }

    //Purchase Hood Button
    public void PurchaseHoodButton()
    {
        int temp = GamePreferences.GetSpecialCoinCoint();
        if (temp >= hoodPrice)
        {
            temp -= hoodPrice;
            GamePreferences.SetCharacterPurchased(1, GamePreferences.hoodPurchased);
            GamePreferences.SetDumplingCount(temp);
            SetPurchaseButtons(characterIndex);
            SetSelectButtons(characterIndex);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
        }
        else
        {
            //SET PURCHASE COINS PANEL
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetRubyStore();
        }
    }

    //Purchase QTownie Button
    public void PurchaseQTownieButton()
    {
        int temp = GamePreferences.GetSpecialCoinCoint();
        if (temp >= qtowniePrice)
        {
            temp -= qtowniePrice;
            GamePreferences.SetCharacterPurchased(1, GamePreferences.qtowniePurchased);
            GamePreferences.SetDumplingCount(temp);
            SetPurchaseButtons(characterIndex);
            SetSelectButtons(characterIndex);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
        }
        else
        {
            //SET PURCHASE COINS PANEL
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetRubyStore();
        }
    }


    //LivesUpgrade Button
    public void UpgradeLivesButton()
    {
        string lifeCapacityName = GetLifeCapacityFromIndex(characterIndex);
        int charLifeCapacity = GamePreferences.GetLifeCapacity(lifeCapacityName);

        int dumplings = GamePreferences.GetDumplingCount();
        string name = GetCharLivesNameFromIndex(characterIndex);
        int temp = 0;
        temp = GamePreferences.GetCharLives(name);

        if(dumplings >= GetPriceFromLights(temp)) //Check to see if user has enough coins
        {
            //temp++;
            dumplings -= GetPriceFromLights(temp);
            temp++;
            GamePreferences.SetDumplingCount(dumplings);

            if(temp == 2)
                charLifeCapacity = 5;

            else if(temp == 5)
                charLifeCapacity = 6;

            else if(temp == 9)
                charLifeCapacity = 7;

            else if(temp == 14)
            {
                charLifeCapacity = 8;
                //DO SOMETHING
            }

            GamePreferences.SetLifeCapacity(charLifeCapacity, lifeCapacityName);

            GamePreferences.SetCharLives(temp, name);
            SetLivesBar(name);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
            SetCountTexts();
        }

        else //Ask the user to buy coins
        {
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetDumplingStore();
        }
    }

    //AttackUpgrade Button
    public void UpgradeAttackButton()
    {
        string attackCooldownName = GetAttackCoolDownFromIndex(characterIndex);
        float charAttackCooldown = GamePreferences.GetAttackCooldown(attackCooldownName);

        int dumplings = GamePreferences.GetDumplingCount();
        string name = GetCharAttackNameFromIndex(characterIndex);
        int temp = 0;
        temp = GamePreferences.GetCharAttack(name);

        if (dumplings >= GetPriceFromLights(temp)) //Check to see if user has enough coins
        {
            //temp++;
            dumplings -= GetPriceFromLights(temp);
            temp++;
            GamePreferences.SetDumplingCount(dumplings);

            if (temp == 2)
                charAttackCooldown = 0.7f;

            else if (temp == 5)
                charAttackCooldown = 0.65f;

            else if (temp == 9)
                charAttackCooldown = 0.6f;
            if (temp == 14)
            {
                charAttackCooldown = 0.55f;
                //DO SOMETHING
            }

            GamePreferences.SetAttackCooldown(charAttackCooldown, attackCooldownName);

            GamePreferences.SetCharAttack(temp, name);
            SetAttackBar(name);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
            SetCountTexts();
        }

        else //Ask the user to buy coins
        {
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetDumplingStore();
        }
    }

    //SuperUpgrade Button
    public void UpgradeSuperButton()
    {
        string superDurationName = GetSuperDurationFromIndex(characterIndex);
        float charSuperDuration = GamePreferences.GetSuperDuration(superDurationName);

        int dumplings = GamePreferences.GetDumplingCount();
        string name = GetCharSuperNameFromIndex(characterIndex);
        int temp = 0;
        temp = GamePreferences.GetCharSuper(name);

        if (dumplings >= GetPriceFromLights(temp)) //Check to see if user has enough coins
        {
            //temp++;
            dumplings -= GetPriceFromLights(temp);
            temp++;
            GamePreferences.SetDumplingCount(dumplings);

            if (temp < 2)
                charSuperDuration = 6;

            else if (temp == 2)
                charSuperDuration = 7;

            else if (temp == 5)
                charSuperDuration = 8;

            else if (temp == 9)
                charSuperDuration = 9;

            if (temp == 14)
            {
                charSuperDuration = 10;
                //DO SOMETHING
            }

            GamePreferences.SetSuperDuration(charSuperDuration, superDurationName);

            GamePreferences.SetCharSuper(temp, name);
            SetSuperPowerBar(name);
            SetTheUpgradeButtons(characterIndex);
            SetCoinCount();
            SetCountTexts();
        }

        else //Ask the user to buy coins
        {
            GameplayController.instance.SetStoreCanvas();
            StoreController.instance.SetDumplingStore();
        }
    }


    public void SetCoinCount()
    {
        dumplingCountChar.text = "" + GamePreferences.GetDumplingCount();
        dumplingCountStart.text = "" + GamePreferences.GetDumplingCount();
        rubyCountChar.text = "" + GamePreferences.GetSpecialCoinCoint();
        rubyCountStart.text = "" + GamePreferences.GetSpecialCoinCoint();
    }


    //Setting Texts
    public void SetCountTexts()
    {
        string charLivesName = GetLifeCapacityFromIndex(characterIndex);
        string charAttackName = GetAttackCoolDownFromIndex(characterIndex);
        string charSuperName = GetSuperDurationFromIndex(characterIndex);

        livesCountText.text = "" + GamePreferences.GetLifeCapacity(charLivesName);
        attackCountText.text = "" + GamePreferences.GetAttackCooldown(charAttackName);
        superCountText.text = "" + GamePreferences.GetSuperDuration(charSuperName);
    }

    

    //Go back to menu screen
    public void GoBackButton()
    {
        SceneManager.LoadScene("Gameplay");
    }



    //Get the AttackCooldown, LifeCapacity, and SuperPowerDuration
    public int GetPlayerLifeCapacity()
    {
        string name = GetLifeCapacityFromIndex(characterIndex);
        return PlayerPrefs.GetInt(name);
    }

    public float GetPlayerAttackCooldown()
    {
        string name = GetAttackCoolDownFromIndex(characterIndex);
        return PlayerPrefs.GetFloat(name);
    }

    public float GetPlayerSuperpowerDuration()
    {
        string name = GetSuperDurationFromIndex(characterIndex);
        return PlayerPrefs.GetFloat(name);
    }
    

}
