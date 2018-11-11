using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour {

    public static audiomanager instance;

    public int soundCount = 5;
    public AudioClip[] clip;

    public AudioClip debugMusic;
    public AudioClip debugSound;

    AudioSource musicSource;
    AudioSource[] soundSources;

    bool useVibrate;
    float soundVolume;
    float musicVolume;

    private void Awake()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        soundSources = new AudioSource[soundCount];
        for (int i = 0; i < soundCount; i++)
            soundSources[i] = gameObject.AddComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();

    }


    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = volume;

    }

    public void SetSoundVolume(float volume)
    {
        soundVolume = volume;
        for (int i = 0; i < soundCount; i++)
            soundSources[i].volume = volume;
    }

    public void PlaySound(AudioClip clip)
    {
        for (int i=0; i<soundCount; i++)
        {
            AudioSource source = soundSources[i];
            if (source.isPlaying)
                continue;
            source.clip = clip;
            source.pitch = Random.Range(0.95f, 1.05f);
            source.Play();
            break;
        }
    }

    public void Vibrate()
    {
        Handheld.Vibrate();
    }
    private void OnGUI()
    {
        if (GUILayout.Button("Play Music"))
            PlayMusic(debugMusic);

        if (GUILayout.Button("Stop Music"))
            StopMusic();

        if (GUILayout.Button("Play Sound"))
            PlaySound(debugSound);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
