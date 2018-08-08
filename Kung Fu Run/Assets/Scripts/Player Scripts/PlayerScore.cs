using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    public static PlayerScore playerScoreInstance;
    
    //private GameplayController gameplayCtr;
    //private GameObject gameplay;

    private float timestamp;

    private float increaseScoreTime = 0.05f;

    public static int score;

    public static int lifeCapacity;
    public GameObject[] livesCount;
    public GameObject[] fullHearts;
    public Vector3 emptyLivesPosition;
    public Vector3 fullHeartsPosition;
    //private List<GameObject> fullHeartArray;
    private int numberOfHearts;

    public static int lives;
    public int testLives;


    //EnemiesKilled
    private DeathCollisions deathCollisions;
    public static int enemiesKilledPS;

    //Dumlping Count
    public static int dumplingScore;

    //Color variables

    //Blood
    public GameObject blood;
    public GameObject bloodOutline;

    public GameObject livesPosition;

    //private Transform lifeDetector;
    

    // Use this for initialization
    void Start () {
        MakeInstance();

        //Blood
        //blood = GameObject.Find("Blood");
        blood.SetActive(false);
        //bloodOutline = GameObject.Find("BloodOutline");
        bloodOutline.SetActive(false);


        //gameplay = GameObject.Find("Gameplay Controller");
        //gameplayCtr = gameplay.GetComponent<GameplayController>();
        score = 0;

        //Change lifeCapacity to PlayerPrefs
        //lifeCapacity = 4;
        //lifeCapacity = CharSelectionController.instance.GetPlayerLifeCapacity(); //------------------------------------------------
        SetPlayerLifeCapacity();

        //emptyLivesPosition = new Vector3(-12f, 4f, -3f);

        //------------------------------------------------------------------------------------
        //emptyLivesPosition = new Vector3(GameObject.Find("Lives").transform.position.x,
        //    GameObject.Find("Lives").transform.position.y, -3f);
        //----------------------------------------------------------------------------------
        emptyLivesPosition = new Vector3(livesPosition.transform.position.x, livesPosition.transform.position.y, -3f);

        /* -------------------------------------------------------------------------------------------------------
        if (lifeCapacity == 4)
            Instantiate(livesCount[0], emptyLivesPosition, Quaternion.identity);
        else if(lifeCapacity == 5)
            Instantiate(livesCount[1], emptyLivesPosition, Quaternion.identity);
        else if(lifeCapacity == 6)
            Instantiate(livesCount[2], emptyLivesPosition, Quaternion.identity);
        else if(lifeCapacity == 7)
            Instantiate(livesCount[3], emptyLivesPosition, Quaternion.identity);
        else if(lifeCapacity == 8)
            Instantiate(livesCount[4], emptyLivesPosition, Quaternion.identity);
        --------------------------------------------------------------------------------------------------------*/


        //Create the fullHeartArray and Instantiate accordingly
        lives = lifeCapacity;
        //fullHeartArray = new List<GameObject>();
        numberOfHearts = lifeCapacity;

        //MakeArray(lifeCapacity);


        //LifeDetector
        //lifeDetector = transform.Find("LifeDetector");

        //Color variables

        ChooseFullHeartsCount(lives);


        //EnemiesKilled
        //deathCollisions = GameObject.Find("DeathDetector").GetComponent<DeathCollisions>();
        //enemiesKilled = deathCollisions.enemiesKilled;
        //enemiesKilled = 0;

        enemiesKilledPS = 0;// = DeathCollisions.enemiesKilled;

        dumplingScore = 0;


        testLives = lives;
    }

    public void SetPlayerLifeCapacity()
    {
        lifeCapacity = CharSelectionController.instance.GetPlayerLifeCapacity();
    }

    public void UpdatPlayerScoreStuff()
    {
        lifeCapacity = CharSelectionController.instance.GetPlayerLifeCapacity();
        lives = lifeCapacity;
        numberOfHearts = lifeCapacity;
        ChooseFullHeartsCount(lives);
        testLives = lives;
    }
	
	// Update is called once per frame
	void Update () {

		if(Time.time >= timestamp)
        {
            score += 5;
            //enemiesKilled += 5;
            timestamp = Time.time + increaseScoreTime;
        }

        GameplayController.instance.SetScore(score);


        //enemiesKilledPS = DeathCollisions.enemiesKilled;
        GameplayController.instance.SetEnemiesKilled(enemiesKilledPS);
        //gameplayCtr.SetScore(score);

        GameplayController.instance.SetDumplingScore(dumplingScore);

        //EnemiesKilled
        //enemiesKilled = deathCollisions.enemiesKilled;

        //GameplayController.instance.SetEnemiesKilled(enemiesKilled);
        //gameplayCtr.SetEnemiesKilled(enemiesKilled);

        //enemiesKilled = DeathCollisions.deathCollisionsInstance.enemiesKilled;
        //GameplayController.instance.SetEnemiesKilled(enemiesKilled);

	}

    void MakeInstance()
    {
        if (playerScoreInstance == null)
            playerScoreInstance = this;
    }

    public void InstantiateEmptyHearts()
    {
        if (lifeCapacity == 4)
            Instantiate(livesCount[0], emptyLivesPosition, Quaternion.identity);
        else if (lifeCapacity == 5)
            Instantiate(livesCount[1], emptyLivesPosition, Quaternion.identity);
        else if (lifeCapacity == 6)
            Instantiate(livesCount[2], emptyLivesPosition, Quaternion.identity);
        else if (lifeCapacity == 7)
            Instantiate(livesCount[3], emptyLivesPosition, Quaternion.identity);
        else if (lifeCapacity == 8)
            Instantiate(livesCount[4], emptyLivesPosition, Quaternion.identity);
    }


    public void ChooseFullHeartsCount(int num)
    {
        if (GameplayController.instance.instantiateHearts)
        {
            //fullHeartsPosition = new Vector3(-12f, 4f, -4f);
            fullHeartsPosition = new Vector3(GameObject.Find("Lives").transform.position.x,
                GameObject.Find("Lives").transform.position.y, -4f);

            if (num == 0)
            {

            }

            for (int i = 1; i <= 8; i++)
            {
                if (num == i)
                {
                    Instantiate(fullHearts[i], fullHeartsPosition, Quaternion.identity);
                }
            }
        }


    }

    void DestroyFullHearts()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("FullHeartBar"));
    }

    public void RestartLives()
    {
        lives = lifeCapacity;
        ChooseFullHeartsCount(lives);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 22 || collision.gameObject.layer == 23) //Sword and Fire
        {
            if(lives > 1) //Originally 0
            {
                DestroyFullHearts();
                lives--;
                ChooseFullHeartsCount(lives);

                StartCoroutine(TimeAfterLoss());
            }

            else if(lives == 1)
            {
                DestroyFullHearts();
                lives--;
                //ChooseFullHeartsCount(lives);
                GameplayController.instance.SetRevivePanel();
                //Time.timeScale = 1f;
                //StartCoroutine(ReviveCountdown());
                //GameplayController.startReviveCountDown = true;
            }


            StartCoroutine(BloodOutline());
            StartCoroutine(Blood());

            //Sound Effect------------------------------------
            SoundController.instance.EnemyAttacks();


        }

        if(collision.gameObject.layer == 20) //Enemy
        {
            if (lives > 1)
            {
                DestroyFullHearts();
                lives--;
                ChooseFullHeartsCount(lives);
                //Destroy(GameObject.FindGameObjectWithTag("DeathDetector"));

                StartCoroutine(TimeAfterLoss());
            }

            else if (lives == 1)
            {
                DestroyFullHearts();
                lives--;
                ChooseFullHeartsCount(lives);
                GameplayController.instance.SetRevivePanel();
                //Time.timeScale = 1f;
                //StartCoroutine(ReviveCountdown());
                //GameplayController.startReviveCountDown = true;
            }


            StartCoroutine(BloodOutline());
            StartCoroutine(Blood());

            //Sound Effect------------------------------------
            SoundController.instance.EnemyAttacks();

        }

        if (collision.gameObject.layer == 26) //GrabHeart
        {
            if(lives < lifeCapacity)
            {
                SoundController.instance.PlayEat();

                DestroyFullHearts();
                lives++;
                ChooseFullHeartsCount(lives);
                Destroy(GameObject.FindGameObjectWithTag("GrabHeart"));

                //Sound Effect----------------------------
                //SoundController.instance.PlayEat();
            }
        }

        if(collision.gameObject.layer == 27) //GrabDumpling
        {
            SoundController.instance.PlayEat();
            dumplingScore += 25;
            Destroy(GameObject.FindGameObjectWithTag("GrabDumpling"));

            //Sound Effect--------------------------------
            //SoundController.instance.PlayEat();
        }
    }

    IEnumerator TimeAfterLoss()
    {
        Physics2D.IgnoreLayerCollision(21, 20, true);
        Physics2D.IgnoreLayerCollision(21, 22, true);
        Physics2D.IgnoreLayerCollision(21, 23, true);
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Physics2D.IgnoreLayerCollision(21, 20, false);
        Physics2D.IgnoreLayerCollision(21, 22, false);
        Physics2D.IgnoreLayerCollision(21, 23, false);
    }

    IEnumerator Blood()
    {
        blood.SetActive(true);
        float time = 0f;
        while(time < 0.1f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        blood.SetActive(false);
    }

    IEnumerator BloodOutline()
    {
        bloodOutline.SetActive(true);
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        bloodOutline.SetActive(false);
    }

    /*IEnumerator ReviveCountdown()
    {
        float temp = 5f;
        if(GameplayController.instance.revivePanel.activeInHierarchy)
        {
            while(temp > 0)
            {
                GameplayController.instance.reviveCount.text = "" + temp;
                temp--;
                yield return new WaitForSeconds(1);
            }
        }
    }*/

    public void RestartScores()
    {
        score = 0;
        enemiesKilledPS = 0;
        dumplingScore = 0;
    }

    

}
