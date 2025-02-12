using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    [SerializeField]
    private AudioSource soundEffect;

    [SerializeField]
    private AudioSource soundMusic;

    [SerializeField]
    private SoundType[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(global::Sounds.MUSIC);
    }
    public void PlaySound(Sounds sound)
    {
        SoundType type = GetSoundType(sound);
        if (type != null)
        {
            soundEffect.volume = type.volume / 100f;
            soundEffect.PlayOneShot(type.soundClip);
 
        }
        else
        {
            Debug.LogWarning("Sound Couldn't be laoded");
        }

    }

    public void PlayMusic(Sounds sound)
    {
        SoundType type = GetSoundType(sound);
        if (type != null)
        {
            soundMusic.clip = type.soundClip;
            soundMusic.volume = type.volume / 100f;
            soundMusic.Play();
        }
        else
        {
            Debug.LogWarning("Sound Couldn't be laoded");
        }


    }


    private SoundType GetSoundType(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);

        if (item != null)
            return item;
        return null;

    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;

    [Range(1, 100)]
    public int volume;
}


public enum Sounds
{
    MUSIC,
    SHOT,
    TANK_EXPLOSION,

}