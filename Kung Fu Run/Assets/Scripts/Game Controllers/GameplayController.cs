using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;
using UnityEngine.Advertisements;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;
    
    public Text scoreText;
    
    public GameObject pausePanel;

    public Text enemiesKilledText;

    public Text dumplingsCountText;

    public Text superText;
    public Text shieldText;

    //KillBar
    public GameObject killBar;
    private RectTransform kBRect;
    public float hitPoint;
    private float maxHitPoint;
    public bool canIncrease;

    //SpecialButtons
    private Button superButton;
    private Button shieldButton;
    public float superDuration; //Get with player preferences
    public float currentDuration;
    public bool startCountDown;

    //Player
    public static GameObject player;
    private Animator playerAnim;
    private GameObject attackButton;

    //RevivePanel
    public GameObject revivePanel;
    public Text reviveCount;
    public static float reviveCountDown;
    public static bool startReviveCountDown;
    public Text reviveRubyText;

    //Ceiling and Bottom
    private GameObject ceiling;
    private Collider2D ceilingCollider;
    private GameObject bottom;
    private Collider2D bottomCollider;

    //Shield
    public GameObject shield;
    public static float shieldDuration;

    //GameOver panel
    public GameObject gameOverPanel;
    public Text goScore;
    public Text goEnemyCount;
    public Text goCoinCount;
    public Text finalScore;


    private Button homeButton;


    //Players
    public GameObject ninjaPrefab;
    public GameObject krotanaPrefab;
    public GameObject gukanPrefab;
    private GameObject playerToInstantiate;

    
    

    //Countdown
    private bool reviveButtonPressed;

    //START THE GAME ----------------------------------------------------------------------------------------
    public GameObject HUDPanel;
    public GameObject startPanel;
    public GameObject spawner;
    public bool moveBackGround;
    public bool startSpawner;
    public bool increaseGameSpeed;
    private Button startButton;
    //public bool doesButtonWork;
    private Button characterButton;
    public bool instantiateHearts;
    //private Button 
    //START THE GAME ----------------------------------------------------------------------------------------


    //Canvas
    public Canvas canvas;
    public Canvas startCanvas;
    public Canvas charCanvas;
    public Canvas charSelectionCanvas;
    public Canvas settingsCanvas;
    public Canvas storeCanvas;


    //GameOver Characters
    public Image goNinja;
    public Image goGukan;
    public Image goKrotana;
    public Image goHood;
    public Image goQTownie;


    //Times revived counter
    public int timesRevived;
    public int rubiesToRevive;
    public Text rubiesToReviveText;
    public bool pauseCountdown;
    public int timesVideoWatched;
    public Button watchVideoButton;
    public Sprite watchVideoOn;
    public Sprite watchVideoOff;


    //Times played
    public int timesPlayed;

    public Text newHighText;


    //Instructions
    public GameObject instructions;


    private void Awake()
    {
        MakeInstance();
    }

    // Use this for initialization
    void Start () {

        //PausePanel
        //pausePanel.SetActive(false);

        //RevivePanel
        //revivePanel.SetActive(false);

        //KillBar
        kBRect = killBar.GetComponent<RectTransform>();
        hitPoint = 0;
        maxHitPoint = 10;
        UpdateKillBar();
        canIncrease = true;

        //SpecialButtons
        superButton = GameObject.Find("SuperPowerButton").GetComponent<Button>();
        superButton.onClick.AddListener(() => SuperButton());
        superButton.interactable = false;
        shieldButton = GameObject.Find("ShieldButton").GetComponent<Button>();
        shieldButton.onClick.AddListener(() => ShieldButton());
        shieldButton.interactable = false;

        //superDuration = 6f; //Get with player preferences------------------------------------------------
        superDuration = CharSelectionController.instance.GetPlayerSuperpowerDuration();
        currentDuration = 0f;
        startCountDown = false;

        //Player

        //player = GameObject.Find(GamePreferences.GetPlayer());
        //Instantiate(player, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -2), Quaternion.identity);
        //GameObject.Find("CNinja").gameObject.SetActive(false);
        //player.name = GamePreferences.GetPlayer();
        //player = GameObject.Find("CNinja"); //Get with player preferences
        //player = SetCharacterActive();
        SetCharacterActive();
        //playerAnim = player.GetComponent<Animator>();
        //playerAnim = player.GetComponent<Animator>();
        attackButton = GameObject.Find("Attack Button");
        //ChooseCharacter();

        //Ceiling and Bottom
        ceiling = GameObject.Find("Ceiling");
        ceilingCollider = ceiling.GetComponent<Collider2D>();
        ceilingCollider.enabled = false;
        bottom = GameObject.Find("Bottom");
        bottomCollider = bottom.GetComponent<Collider2D>();
        bottomCollider.enabled = false;

        //Shield
        shieldDuration = superDuration + 3f;

        //GameOver Panel

        //gameOverPanel.SetActive(false);

        startReviveCountDown = false;

        //Countdown
        reviveButtonPressed = false;


        //homeButton = GameObject.Find("Home").GetComponent<Button>();
        //homeButton.onClick.AddListener(() => HomeButton());


        //START THE GAME ----------------------------------------------------------------------------------------
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => StartTheGame());
        startButton.interactable = true;
        //characterButton = GameObject.Find("CharacterButton").GetComponent<Button>();
        //characterButton.onClick.AddListener(() => StartGame());
        BeforeGameStarts();
        //StartTheGame();
        //START THE GAME ----------------------------------------------------------------------------------------



        //Canvas
        InitializeCanvas();


        //Times Revived Counter
        timesRevived = 0;
        rubiesToRevive = 1;
        pauseCountdown = false;
        timesVideoWatched = 0;

    } //-----------------------START----------------------------

    // Update is called once per frame
    void Update () {

        //enemy = Physics2D.GetIgnoreLayerCollision(20, 21);
        //sword = Physics2D.GetIgnoreLayerCollision(21, 22);
        //fire = Physics2D.GetIgnoreLayerCollision(23, 21);
        
        
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SuperButton()
    {
        hitPoint = 0;
        UpdateKillBar();
        superButton.interactable = false;
        shieldButton.interactable = false;
        //startCountDown = true;
        DisableColliders();
        StartCoroutine(FinishSuperPower());
        //PlayerAnim
        playerAnim.SetBool("SuperPower", true);
        player.GetComponent<Player_Jump>().SuperPower();
        attackButton.GetComponent<Button>().interactable = false;
        ceilingCollider.enabled = true;
        bottomCollider.enabled = true;

        //Gravity
        Player_Jump.gravityOn = false;

        StartCoroutine(SpecialCountdown(superDuration, superText));
    }

    public void ShieldButton()
    {
        hitPoint = 0;
        UpdateKillBar();
        superButton.interactable = false;
        shieldButton.interactable = false;
        DisableColliders();
        Shield();
        //ShieldCtr.instantiateShield = true;
        //ShieldCtr.shieldInstance.InstantiateShield();
        StartCoroutine(FinishShield());

        StartCoroutine(SpecialCountdown(shieldDuration, shieldText));
    }

    private void EnableColliders()
    {

        Physics2D.IgnoreLayerCollision(20, 21, false);
        Physics2D.IgnoreLayerCollision(21, 22, false);
        Physics2D.IgnoreLayerCollision(21, 23, false);
    }

    private void DisableColliders()
    {
        Physics2D.IgnoreLayerCollision(20, 21, true);
        Physics2D.IgnoreLayerCollision(21, 22, true);
        Physics2D.IgnoreLayerCollision(21, 23, true);
    }

    IEnumerator FinishSuperPower()
    {
        player.transform.localScale = player.transform.localScale * 1.75f;
        canIncrease = false;
        startCountDown = true;
        float time = 0f;
        while(time < superDuration)
        {
            DisableColliders();
            time += Time.deltaTime;
            yield return null;
        }

        EnableColliders();
        startCountDown = false;
        canIncrease = true;

        //Player
        playerAnim.SetBool("SuperPower", false);
        player.GetComponent<Player_Jump>().AfterSuperPower();

        attackButton.GetComponent<Button>().interactable = true;

        player.transform.localScale = player.transform.localScale / 1.75f;

        //Ceiling and Bottom
        ceilingCollider.enabled = false;
        bottomCollider.enabled = false;

        //Gravity
        Player_Jump.gravityOn = true;
    }

    IEnumerator FinishShield()
    {
        canIncrease = false;
        startCountDown = true;
        float time = 0f;
        while(time < shieldDuration)
        {
            DisableColliders();
            time += Time.deltaTime;
            yield return null;
        }
        EnableColliders();
        //Destroy(shield.gameObject);
        //DestroyShield();
        ShieldCtr.shieldInstance.DestroyShield();
        startCountDown = false;
        canIncrease = true;
    }

    IEnumerator ReviveShield()
    {
        superButton.GetComponent<Button>().interactable = false;
        shieldButton.GetComponent<Button>().interactable = false;
        canIncrease = false;
        startCountDown = true;
        float time = 0f;
        while (time < 3f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        EnableColliders();
        if(hitPoint == maxHitPoint)
        {
            superButton.GetComponent<Button>().interactable = true;
            shieldButton.GetComponent<Button>().interactable = true;
        }
        //Destroy(shield.gameObject);
        //DestroyShield();
        ShieldCtr.shieldInstance.DestroyShield();
        startCountDown = false;
        canIncrease = true;
    }

    public void Shield()
    {
        Instantiate(shield);
        //shield.transform.parent = player.transform;
    }

    public void DestroyShield()
    {
        Destroy(shield);
    }

    IEnumerator SpecialCountdown(float duration, Text theText)
    {
        float temp = duration;
        while(temp > 0)
        {
            theText.text = "" + temp;
            temp--;
            DisableColliders();
            yield return new WaitForSeconds(1);
        }
        theText.text = "";
    }

    public void UpdateKillBar()
    {
        
        float ratio = hitPoint / maxHitPoint;
        //current.localScale = new Vector3(1, ratio, 1);
        kBRect.localScale = new Vector3(1, ratio, 1);
    }

    public void IncreaseKillBar()
    {
        if (canIncrease)
        {
            if (hitPoint < maxHitPoint)
                hitPoint++;
            UpdateKillBar();
            if (hitPoint == maxHitPoint)
            {
                superButton.interactable = true;
                shieldButton.interactable = true;
            }
        }
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        //Application.LoadLevel("MainMenu");
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void SetDumplingScore(int dumplingScore)
    {
        dumplingsCountText.text = "" + dumplingScore;
    }

    public void SetEnemiesKilled(int enemies)
    {
        enemiesKilledText.text = "" + enemies;
    }

    public void SetReviveRubyCount()
    {
        reviveRubyText.text = "" + GamePreferences.GetSpecialCoinCoint();
    }


    public void SetRevivePanel()
    {
        if(timesVideoWatched < 1)
        {
            watchVideoButton.image.sprite = watchVideoOn;
        }

        else if(timesVideoWatched >= 1)
        {
            watchVideoButton.image.sprite = watchVideoOff;
        }

        StoreController.instance.SetCount();
        CharSelectionController.instance.SetCount();

        pauseCountdown = false;
        //reviveRubyText.text = "" + GamePreferences.GetSpecialCoinCoint();
        SetReviveRubyCount();
        rubiesToReviveText.text = "" + rubiesToRevive;

        Time.timeScale = 0f;
        revivePanel.SetActive(true);
        StartCoroutine(ReviveToGameOver(reviveCount));
        
    }

    public void Revive()
    {
        if (rubiesToRevive > GamePreferences.GetSpecialCoinCoint())
        {
            pauseCountdown = true;
            storeCanvas.gameObject.SetActive(true);
        }

        else
        {

            timesRevived++;
            rubiesToRevive++;

            int temp = GamePreferences.GetSpecialCoinCoint();
            temp--;
            GamePreferences.SetSpecialCoinCount(temp);

            reviveButtonPressed = true;
            //StopCoroutine(countdownCoroutine);
            PlayerScore.lives = PlayerScore.lifeCapacity;
            PlayerScore.playerScoreInstance.ChooseFullHeartsCount(PlayerScore.lives);
            Time.timeScale = 1f;
            revivePanel.SetActive(false);
            DisableColliders();
            Shield();
            StartCoroutine(ReviveShield());
        }
    }

    IEnumerator ReviveToGameOver(Text theText)
    {
        float temp;
        if (timesRevived >= 2)
            temp = 0;
        else
            temp = 5;

        while(temp > 0 && !reviveButtonPressed)
        {
            //if (pauseCountdown)
            //    temp = 5;
            theText.text = "" + temp;
            //temp--;
            yield return new WaitForSecondsRealtime(1);
            temp--;
            if (pauseCountdown)
                temp = 5;
        }

        reviveButtonPressed = false;

        if(temp == 0)
        {

            DisableColliders();

            SetGameOverPanel();
            SetGameOverScores(PlayerScore.score, PlayerScore.enemiesKilledPS, PlayerScore.dumplingScore);
            int dumplingsTemp;
            int scoreTemp = PlayerScore.score + PlayerScore.enemiesKilledPS + PlayerScore.dumplingScore;

            dumplingsTemp = GamePreferences.GetDumplingCount() + PlayerScore.dumplingScore;
            GamePreferences.SetDumplingCount(dumplingsTemp);


            newHighText.gameObject.SetActive(false);
            if(scoreTemp > GamePreferences.GetHighScore())
            {
                GamePreferences.SetHighScore(scoreTemp);
                newHighText.gameObject.SetActive(true);

                Social.ReportScore(scoreTemp, "CgkItryzx64UEAIQAQ", (bool success) =>
                {
                    if (success)
                        Debug.Log("Score uploaded successfully");
                    else
                        Debug.Log("Score failed to upload");
                });
                //long scoreLong = scoreTemp;
                //Social.ReportScore(scoreLong, "leaderboardsID", HighScoreCheck);
            }


        }
    }

    static void HighScoreCheck(bool result)
    {
        if (result)
            Debug.Log("Score submission successful");
        else
            Debug.Log("Score submission failed");
    }

    public void SetGameOverPanel()
    {
        //newHighText.gameObject.SetActive(false);
        //Time.timeScale = 0f;
        //Time.timeScale = 1f;
        //canvas.gameObject.SetActive(false);

        Time.timeScale = 0f;
        revivePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 1f;
        moveBackGround = false;
        startSpawner = false;
        increaseGameSpeed = false;
        instantiateHearts = false;

        SetGameOverCharacter();

    }

    //Set GameOver Character
    public void SetGameOverCharacter()
    {
        int temp = CharSelectionController.instance.GetCharacterIndex();

        goNinja.gameObject.SetActive(false);
        goGukan.gameObject.SetActive(false);
        goKrotana.gameObject.SetActive(false);
        goHood.gameObject.SetActive(false);
        goQTownie.gameObject.SetActive(false);

        if (temp == 0)
            goNinja.gameObject.SetActive(true);
        else if (temp == 1)
            goKrotana.gameObject.SetActive(true);
        else if (temp == 2)
            goGukan.gameObject.SetActive(true);
        else if (temp == 3)
            goHood.gameObject.SetActive(true);
        else if (temp == 4)
            goQTownie.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        PlayerScore.lives = PlayerScore.lifeCapacity;
        PlayerScore.playerScoreInstance.ChooseFullHeartsCount(PlayerScore.lives);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //GameSpeedCtr.gameSpeedCtrInstance.RestartGameSpeed();
        PlayerScore.playerScoreInstance.RestartScores();
        hitPoint = 0f;
        UpdateKillBar();
        Time.timeScale = 1f;

        
    }

    //GameOver Set Scores ----------------------------------------------------------------------------------
    public void SetGameOverScores(float firstScore, float goEnemyScore, float goCoinScore)
    {
        goScore.text = "" + firstScore;
        goEnemyCount.text = "" + goEnemyScore;
        goCoinCount.text = "" + goCoinScore;
        float goFinalScore = firstScore + goEnemyScore + goCoinScore;
        finalScore.text = "" + goFinalScore;
    }
    //GameOver Set Scores ----------------------------------------------------------------------------------




    //START THE GAME ----------------------------------------------------------------------------------------

    public void BeforeGameStarts()
    {
        EnableButtons();

        Player_Jump.playerJumpInstance.SetTimeBetweenAttacks();
        PlayerScore.playerScoreInstance.SetPlayerLifeCapacity();
        superDuration = CharSelectionController.instance.GetPlayerSuperpowerDuration();

        Time.timeScale = 1f;

        //Player
        PlayerScore.score = 0;
        PlayerScore.enemiesKilledPS = 0;
        PlayerScore.dumplingScore = 0;


        startPanel.SetActive(true);
        HUDPanel.SetActive(false);
        pausePanel.SetActive(false);
        revivePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        //spawner.SetActive(false);
        startSpawner = false;
        moveBackGround = false;
        //GameSpeedCtr.gameSpeedCtrInstance.gameSpeed = -8f;
        increaseGameSpeed = false;

        instantiateHearts = false;

        
        GameSpeedCtr.gameSpeedCtrInstance.RestartGameSpeed();

        instructions.SetActive(false);

    }

    public void DisableButtons()
    {
        GameObject.Find("CharacterButton").GetComponent<Button>().interactable = false;
        GameObject.Find("InfoButton").GetComponent<Button>().interactable = false;
        GameObject.Find("LeaderBoardsButton").GetComponent<Button>().interactable = false;
    }

    public void EnableButtons()
    {
        GameObject.Find("CharacterButton").GetComponent<Button>().interactable = true;
        GameObject.Find("InfoButton").GetComponent<Button>().interactable = true;
    }

    public void StartTheGame()
    {
        DisableButtons();
        //Player
        playerAnim.SetTrigger("Bored-BoredEnd");

        //UIButtons
        GameObject.Find("CharacterButton").GetComponent<Animator>().SetTrigger("Start");
        GameObject.Find("LeaderBoardsButton").GetComponent<Animator>().SetTrigger("Start");
        GameObject.Find("InfoButton").GetComponent<Animator>().SetTrigger("Start");
        GameObject.Find("AddDumpling").GetComponent<Animator>().SetTrigger("Start");
        GameObject.Find("AddRuby").GetComponent<Animator>().SetTrigger("Start");
        
        StartCoroutine(StartTheGameAid());
        
        Physics2D.IgnoreLayerCollision(21, 20, false);
        Physics2D.IgnoreLayerCollision(21, 22, false);
        Physics2D.IgnoreLayerCollision(21, 23, false);


        //Update PlayerScore and Player_Jump Stuff
        PlayerScore.playerScoreInstance.UpdatPlayerScoreStuff();
        Player_Jump.playerJumpInstance.SetTimeBetweenAttacks();

        GameSpeedCtr.gameSpeedCtrInstance.RestartStartTime();
        Spawner.instance.RestartStartTime();


        int temp = GamePreferences.GetTimesPlayed();
        temp++;
        GamePreferences.SetTimesPlayed(temp);

        //instructions.SetActive(true);

    }

    //GetPlayerAttackCooldown
    public float GetPlayerAttackCooldownFromCharSelection()
    {
        string name = CharSelectionController.instance.GetAttackCoolDownFromIndex(GamePreferences.GetCharacterIndex());
        return PlayerPrefs.GetFloat(name);
    }

    //START THE GAME ----------------------------------------------------------------------------------------

    IEnumerator StartTheGameAid()
    {
        float time = 0f;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        startPanel.SetActive(false);
        HUDPanel.SetActive(true);

        revivePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        revivePanel.SetActive(false);
        pausePanel.SetActive(false);
        //instructions.SetActive(false);

        //spawner.SetActive(true);
        startSpawner = true;
        moveBackGround = true;
        increaseGameSpeed = true;

        instantiateHearts = true;
        PlayerScore.playerScoreInstance.ChooseFullHeartsCount(PlayerScore.lifeCapacity);
        PlayerScore.playerScoreInstance.InstantiateEmptyHearts();

        startCanvas.gameObject.SetActive(false);

        if(GamePreferences.GetTimesPlayed() <= 3)
            instructions.SetActive(true);
        
    }



    public void HomeButton()
    {
        Destroy(player);
        SceneManager.LoadScene("Gameplay");
    }



    public void InitializeCanvas()
    {
        startCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
        charCanvas.gameObject.SetActive(false);
        charSelectionCanvas.gameObject.SetActive(false);

        settingsCanvas.gameObject.SetActive(false);
        storeCanvas.gameObject.SetActive(false);
    }

    public void GoToCharSelect()
    {
        startCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        charCanvas.gameObject.SetActive(true);
        charSelectionCanvas.gameObject.SetActive(true);
    }

    //SetStoreCanvas
    public void SetStoreCanvas()
    {
        storeCanvas.gameObject.SetActive(true);
    }

    //SetSettingsCanvas
    public void SetSettingsCanvas()
    {
        settingsCanvas.gameObject.SetActive(true);
    }

    //GoBackFromStore
    public void GoBackFromStore()
    {
        if(pauseCountdown)
        {
            pauseCountdown = false;
            SetReviveRubyCount();
        }

        storeCanvas.gameObject.SetActive(false);
    }



    //Set Animator
    public void ChooseCharacter()
    {
        string name = GamePreferences.GetPlayer();

        if (name == GamePreferences.Ninja)
        {
            playerToInstantiate = Instantiate(ninjaPrefab, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -2), Quaternion.identity) as GameObject;
            playerAnim = ninjaPrefab.GetComponent<Animator>();
            attackButton = GameObject.Find("Attack Button");
            playerToInstantiate.name = "CNinja";
        }

        else if(name == GamePreferences.Krotana)
        {
            playerToInstantiate = Instantiate(krotanaPrefab, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -2), Quaternion.identity);
            playerAnim = playerToInstantiate.GetComponent<Animator>();
            attackButton = GameObject.Find("Attack Button");
        }

        else if(name == GamePreferences.MasterGukan)
        {
            playerToInstantiate = Instantiate(gukanPrefab, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -2), Quaternion.identity);
            playerAnim = playerToInstantiate.GetComponent<Animator>();
            attackButton = GameObject.Find("Attack Button");
        }

       
    }

    public void SetCharacterActive()
    {
        string name = GamePreferences.GetPlayer();
        if (name == GamePreferences.Ninja)
        {
            GameObject.Find("Krotana").SetActive(false);
            GameObject.Find("MasterGukan").SetActive(false);
            GameObject.Find("Hood").SetActive(false);
            GameObject.Find("QTownie").SetActive(false);
            //player = GameObject.Find("CNinja");
            player = GameObject.Find("CNinja");
            playerAnim = player.GetComponent<Animator>();
            playerAnim.SetBool("Grounded", true);
        }

        else if (name == GamePreferences.Krotana)
        {
            GameObject.Find("CNinja").SetActive(false);
            GameObject.Find("MasterGukan").SetActive(false);
            GameObject.Find("Hood").SetActive(false);
            GameObject.Find("QTownie").SetActive(false);
            //player = GameObject.Find("Krotana");
            player = GameObject.Find("Krotana");
            playerAnim = player.GetComponent<Animator>();
            playerAnim.SetBool("Grounded", true);
        }

        else if (name == GamePreferences.MasterGukan)
        {
            GameObject.Find("CNinja").SetActive(false);
            GameObject.Find("Krotana").SetActive(false);
            GameObject.Find("Hood").SetActive(false);
            GameObject.Find("QTownie").SetActive(false);
            //player = GameObject.Find("MasterGukan");
            player = GameObject.Find("MasterGukan");
            playerAnim = player.GetComponent<Animator>();
            playerAnim.SetBool("Grounded", true);
        }

        else if(name == GamePreferences.Hood)
        {
            GameObject.Find("CNinja").SetActive(false);
            GameObject.Find("Krotana").SetActive(false);
            GameObject.Find("MasterGukan").SetActive(false);
            GameObject.Find("QTownie").SetActive(false);

            player = GameObject.Find("Hood");
            playerAnim = player.GetComponent<Animator>();
            playerAnim.SetBool("Grounded", true);
        }

        else if(name == GamePreferences.QTownie)
        {
            GameObject.Find("CNinja").SetActive(false);
            GameObject.Find("Krotana").SetActive(false);
            GameObject.Find("MasterGukan").SetActive(false);
            GameObject.Find("Hood").SetActive(false);

            player = GameObject.Find("QTownie");
            playerAnim = player.GetComponent<Animator>();
            playerAnim.SetBool("Grounded", true);
        }

        else
        {
            player = GameObject.Find("CNinja");
            playerAnim = player.GetComponent<Animator>();
            playerAnim.SetBool("Grounded", true);
        }

    }


    //Close Settings Panel
    public void CloseSettingsPanel()
    {
        settingsCanvas.gameObject.SetActive(false);
    }




    //ADVERTISEMENTS----------------------------------------------------------------------

    public void ShowRewardedAd()
    {
        if (timesVideoWatched < 1)
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                timesVideoWatched++;
                pauseCountdown = true;
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
            }
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //pauseCountdown = true;
                timesRevived++;
                reviveButtonPressed = true;
                PlayerScore.lives = PlayerScore.lifeCapacity;
                PlayerScore.playerScoreInstance.ChooseFullHeartsCount(PlayerScore.lives);
                Time.timeScale = 1f;
                revivePanel.SetActive(false);
                DisableColliders();
                Shield();
                StartCoroutine(ReviveShield());
                
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown");
                break;

        }
    }
    

    //ADVERTISEMENTS----------------------------------------------------------------------



}
