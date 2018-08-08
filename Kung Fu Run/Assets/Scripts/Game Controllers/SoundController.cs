using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static SoundController instance;


    private AudioSource audioSource;

    public AudioClip run;

    /*public AudioClip ninjaAttack;
    public AudioClip krotanaAttack;
    public AudioClip gukanAttack;
    public AudioClip hoodAttack;
    public AudioClip qtownieAttack;*/

    public AudioClip attack;
    public AudioClip gun;

    public AudioClip enemySlash;
    public AudioClip enemyBurn;
    public AudioClip enemyHurtsPlayer;

    public AudioClip buttonClick;

    public AudioClip eat;

    // Use this for initialization
    void Start () {
        MakeInstance();
        audioSource = GetComponent<AudioSource>();
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }


    public void RunSound()
    {
        if (GamePreferences.GetSoundState() == 1)
        {
            audioSource.PlayOneShot(run);
        }
    }

    public void PlayAttack()
    {
        if (GamePreferences.GetSoundState() == 1)
        {
            if (GamePreferences.GetCharacterIndex() == 3)
                audioSource.PlayOneShot(gun);
            else
                audioSource.PlayOneShot(attack);
        }
    }

    public void EnemyDying()
    {
        if (GamePreferences.GetSoundState() == 1)
        {
            if (GamePreferences.GetCharacterIndex() == 2 || GamePreferences.GetCharacterIndex() == 4)
            {
                audioSource.PlayOneShot(enemyBurn);
            }

            else
            {
                audioSource.PlayOneShot(enemySlash);
            }
        }
    }

    public void EnemyAttacks()
    {
        if (GamePreferences.GetSoundState() == 1)
        {
            audioSource.PlayOneShot(enemyHurtsPlayer);
        }
    }


    public void ButtonClick()
    {
        if(GamePreferences.GetSoundState() == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
    }


    public void Silence()
    {
        audioSource.Stop();
    }

    public void PlayEat()
    {
        if(GamePreferences.GetSoundState() == 1)
            audioSource.PlayOneShot(eat);
    }

}
