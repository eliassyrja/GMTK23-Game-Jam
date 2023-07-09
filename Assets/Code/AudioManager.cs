using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClip (string name, Transform position, bool loop)
	{
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
            {
				if (loop)
				{
                    sound.source.loop = true;
                    sound.source.Play();
                }
                else
                    sound.source.PlayOneShot(sound.clip);
            }
        }
    }

    public void PlayClip (string name, Transform position)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
            {
                sound.source.PlayOneShot(sound.clip);
            }
        }
    }

    public AudioSource GetSuckingAudio()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == "Sucking")
            {
                return sound.source;
            }
        }
        return null;
    }
}
