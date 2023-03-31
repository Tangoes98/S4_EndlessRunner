using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMg : MonoBehaviour
{
    public static AudioMg Instance;

    public AudioSource _musicSource, _soundEffectSource;

    [Range(0f, 1f)]
    public float _volume;


    [System.Serializable]
    public struct Music
    {
        public string _audioName;
        public AudioClip _audioclip;
    }
    public Music[] music;


    [System.Serializable]
    public struct SoundEffect
    {
        public string _soundName;
        public AudioClip _soundEffectClip;
    }
    public SoundEffect[] soundEffect;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AudioMg.Instance.playMusic(0, true);
    }

    public void playMusic(int index, bool isloop)
    {
        _musicSource.volume = _volume;
        _musicSource.loop = isloop;
        _musicSource.PlayOneShot(music[index]._audioclip);



    }
    public void playSoundEffect(int index)
    {
        _soundEffectSource.volume = _volume;
        _soundEffectSource.PlayOneShot(soundEffect[index]._soundEffectClip);

    }



}
