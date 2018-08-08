using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static MusicController instance;

    private AudioSource audioSource;

    public AudioClip[] songs;
    //public AudioClip music;

    private int songIndex;

	// Use this for initialization
	void Start () {
        MakeInstance();
        audioSource = GetComponent<AudioSource>();

        songIndex = Random.Range(0, 2);
        audioSource.clip = songs[songIndex];
        UpdateMusicController();

        VolumeUp();
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
	

    public void PlayMusic()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        if(!audioSource.isPlaying && GamePreferences.GetMusicState() == 1)
        {
            songIndex = Random.Range(0, 1);
            audioSource.clip = songs[songIndex];
            audioSource.Play();
        }

        if(GamePreferences.GetMusicState() == 0)
        {
            audioSource.Stop();
        }

    }


    public void UpdateMusicController()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            audioSource.Play();
        }

        else
        {
            audioSource.Stop();
        }
    }

    public void StopMusicController()
    {
        audioSource.Stop();
    }


    public void VolumeDown()
    {
        AudioListener.volume = 0.95f;
    }

    public void VolumeUp()
    {
        AudioListener.volume = 1f;
    }

    public void VolumeReallyDown()
    {
        AudioListener.volume = 0.85f;
    }




}
