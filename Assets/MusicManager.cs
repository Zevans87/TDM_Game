using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Music Clips")]
    [Tooltip("Music for the Title Screen")]
    public AudioClip titleMusic;
    [Tooltip("Music for Gameplay")]
    public AudioClip gameMusic;

    [Range(0f, 1f)]
    public float volume = 0.5f;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = volume;
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        PlayTitleMusic();
    }

    public void PlayTitleMusic()
    {
        if (audioSource.clip == titleMusic && audioSource.isPlaying) return;
        audioSource.clip = titleMusic;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        if (audioSource.clip == gameMusic && audioSource.isPlaying) return;
        audioSource.clip = gameMusic;
        audioSource.Play();
    }
}
