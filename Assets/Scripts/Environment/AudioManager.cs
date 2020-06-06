using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private Sound[] sounds;
    private IDictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>();

    private static AudioManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
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

    public static void Play(string name)
    {
        if (_instance.soundsDictionary.TryGetValue(name, out Sound sound))
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
    }
}
