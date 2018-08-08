using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollisions : MonoBehaviour {

    public static DeathCollisions deathCollisionsInstance;
    //private bool increaseEnemies;

    private Animator anim;
    private GameObject enemy;

    public bool increasePoints;


    public static int enemiesKilled;

    public int killBarPoints;


    // Use this for initialization
    void Start () {
        enemy = transform.parent.gameObject;
        anim = enemy.GetComponent<Animator>();
        increasePoints = false;

        enemiesKilled = 0;
        //increaseEnemies = false;

        killBarPoints = 0;

    }
	
	// Update is called once per frame
	void Update () {


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 19)
        {
            anim.SetTrigger("Dying");
            Destroy(gameObject);
            increasePoints = true;
            enemiesKilled += 100;
            PlayerScore.enemiesKilledPS += 50;

            //KillBar
            GameplayController.instance.IncreaseKillBar();
            //GameplayController.instance.SetEnemiesKilled(enemiesKilled);

            //Sound Effect------------------------------------
            SoundController.instance.EnemyDying();
        }

        else if(collision.gameObject.layer == 29)
        {
            anim.SetTrigger("Burn");
            Destroy(gameObject);
            increasePoints = true;
            enemiesKilled += 100;
            PlayerScore.enemiesKilledPS += 50;

            //KillBar
            GameplayController.instance.IncreaseKillBar();

            //Sound Effect------------------------------------
            SoundController.instance.EnemyDying();
        }


    }
}
