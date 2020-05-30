using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private Sound[] sounds;
    private IDictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>();

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.SetUpSource(gameObject.AddComponent<AudioSource>());
            soundsDictionary.Add(sound.name, sound);
        }
    }

    void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        if (soundsDictionary.TryGetValue(name, out Sound sound))
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
    }
}
