
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public bool loop;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(.1f, 3f)]
    public float pitch = 1f;

    private AudioSource audioSource;

    public void SetUpSource(AudioSource source)
    {
        audioSource = source;

        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.loop = loop;
    }

    public void Play()
    {
        audioSource.Play();
    }
}
