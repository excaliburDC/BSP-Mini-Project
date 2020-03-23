using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonManager<AudioManager>
{
    public List<Sounds> sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        foreach (Sounds s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play(string name)
    {
        
    }
}
