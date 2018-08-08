using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;


	//Platforms
	public GameObject[] platforms;
	private float yMin = -2f;
	private float yMax = 0.75f;
	private float spawnTime;
	private int platformSelector;

	//StaticEnemies
	public GameObject[] staticEnemies;
	private float staticEnemiesSpawnTime;
	private int statEnemySelctor;

	private float yEnemyMin = -2.5f;
	private float yEnemyMax = 2f;


    private float minPSpawnTime; // = 0.5f;
    private float maxPSpawnTime; // = 2f;
    private float minESpawnTime; // = 0.5f;
    private float maxESpawnTime; // = 2.5f;
	private bool isPlatformSpawning = false;
	private bool isEnemySpawning = false;



    //private GameSpeedCtr gameSpeed;
    public float letsSpawn;


    //Items
    //Life
    public GameObject life;
    private float lifeTimeStamp;// = 10f;

    //Coins
    public GameObject dumpling;
    private float coinTimeStamp;// = 6f;


    //Try variables
    public float startTime;
    public float elapsedTime;


	void Start() {
        MakeInstance();
        //gameSpeed = GetComponent<GameSpeedCtr>();
        //GameSpeedCtr.gameSpeedCtrInstance.RestartGameSpeed();
        //letsSpawn = GameSpeedCtr.gameSpeedCtrInstance.gameSpeed;
        letsSpawn = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

        lifeTimeStamp = Random.Range(20f, 30f);
        coinTimeStamp = Random.Range(15f, 25f);


        startTime = Time.time;

	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

	void Update() {

        elapsedTime = Time.time - startTime;

        if (GameplayController.instance.startSpawner)
        {
            //letsSpawn = GameSpeedCtr.gameSpeedCtrInstance.gameSpeed;
            letsSpawn = GameSpeedCtr.gameSpeedCtrInstance.GetGameSpeed();

            if (!isPlatformSpawning)
            {
                isPlatformSpawning = true;
                int platIndex = Random.Range(0, platforms.Length);

                minPSpawnTime = (0.75f / -letsSpawn) * 10;
                maxPSpawnTime = (2.5f / -letsSpawn) * 10;

                StartCoroutine(spawnPlatform(platIndex, Random.Range(minPSpawnTime, maxPSpawnTime)));
            }

            if (!isEnemySpawning)
            {
                isEnemySpawning = true;
                int enemyIndex = Random.Range(0, staticEnemies.Length);

                minESpawnTime = (0.55f / -letsSpawn) * 10;
                maxESpawnTime = (1.75f / -letsSpawn) * 10;

                StartCoroutine(spawnEnemies(enemyIndex, Random.Range(minESpawnTime, maxESpawnTime)));
            }

            if (elapsedTime >= lifeTimeStamp)
            {
                Instantiate(life, new Vector3(transform.position.x, 0, -3), transform.rotation);
                lifeTimeStamp = lifeTimeStamp + Random.Range(10f, 30f);
            }

            if (elapsedTime >= coinTimeStamp)
            {
                Instantiate(dumpling, new Vector3(transform.position.x, 0, -3), transform.rotation);
                coinTimeStamp = coinTimeStamp + Random.Range(10f, 30f);
            }

        }

	}

	IEnumerator spawnPlatform(int index, float seconds) {
		yield return new WaitForSeconds (seconds);
		float y = Random.Range (yMin, yMax);
		Vector3 pos = new Vector3 (transform.position.x, y, -2);
		Instantiate (platforms [index], pos, transform.rotation);
		isPlatformSpawning = false;
	}

	IEnumerator spawnEnemies(int index, float seconds) {
		yield return new WaitForSeconds (seconds);
		float y = Random.Range (yEnemyMin, yEnemyMax);
		Vector3 pos = new Vector3 (transform.position.x, y, -2);
		Instantiate (staticEnemies [index], pos, transform.rotation);
		isEnemySpawning = false;
	}



	void platformSpawn() {
		//yield return new WaitForSeconds (Random.Range(0.5f, 2f));
		float y = Random.Range (yMin, yMax);
		Vector3 pos = new Vector3 (transform.position.x, y, -2);
		platformSelector = Random.Range (0, platforms.Length);
		Instantiate (platforms [platformSelector], pos, transform.rotation);
	}

	void staticEnemiesSpawn() {
		//yield return new WaitForSeconds (Random.Range(0.5f, 2.5f));
		float y = Random.Range (yEnemyMin, yEnemyMax);
		Vector3 pos = new Vector3 (transform.position.x, y, -2);
		statEnemySelctor = Random.Range (0, staticEnemies.Length);
		Instantiate (staticEnemies [statEnemySelctor], pos, transform.rotation);
	}

	void getPlatformSpawnTime() {
		float theSpawnTime = Random.Range (0.5f, 2f);
		spawnTime = theSpawnTime;
		Invoke ("getPlatformSpawnTime", spawnTime);
	}

	void getStaticEnemiesSpawnTime() {
		float theSpawnTime = Random.Range (0.5f, 2.5f);
		staticEnemiesSpawnTime = theSpawnTime;
	}


    public void OnEnable()
    {
        letsSpawn = -8f;
    }


    public void RestartStartTime()
    {
        startTime = Time.time;
    }


}
