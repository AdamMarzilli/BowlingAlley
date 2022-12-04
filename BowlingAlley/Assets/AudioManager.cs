using UnityEngine.Audio;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{


    public Sound[] sounds;
    public static AudioManager instance;
    public AudioMixerGroup audioMixer;
    // Start is called before the first frame update
    Scene m_Scene;
    string sceneName;
    public AudioSource mainAudioTrack;
    public AudioSource basementAudioSource;

    public bool reachedBasement = false;
    public bool reachedUpstairs = false;

    public AudioClip upstairsTheme;
    public AudioClip downstairsTheme;
    public AudioClip mainMenuTheme;
    

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }



        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
           
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = audioMixer;
        }



    }

    public static class AudioFadeOut
    {

        public static IEnumerator FadeOutAudio(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }

    }

        public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "is not found!");
            return;
        }
      
        s.source.Play();
    }

    public void PlayPitch(string name, float min, float max)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "is not found!");
            return;
        }
        s.source.Play();
        s.source.pitch = UnityEngine.Random.Range(min, max);
    }


    public void PlayMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "is not found!");
            return;
        }
        s.source.Play();
        s.source.playOnAwake = true;
        s.source.loop = true;

    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "is not found!");
            return;
        }
        s.source.Stop();
    }

}
