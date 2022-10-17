using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManafer : MonoBehaviour
{

    public Sonido[] sounds;
    public static AudioManafer instance;

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

        foreach(Sonido s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("musicaJuego"); 
    }

    public void Play(string name)
    {
        Sonido s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }
}
