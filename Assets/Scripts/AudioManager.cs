using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [Header("Playlist")]
    public AudioClip[] playlist;       // Drag all your songs in here
    public bool shuffle = true;        // Toggle shuffle in Inspector

    private AudioSource audioSource;
    private int currentTrack = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            if (shuffle) ShufflePlaylist();
            PlayTrack(0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // When a track finishes, play the next one
        if (!audioSource.isPlaying)
        {
            currentTrack = (currentTrack + 1) % playlist.Length;
            PlayTrack(currentTrack);
        }
    }

    void PlayTrack(int index)
    {
        audioSource.clip = playlist[index];
        audioSource.loop = false;   // Don't loop individual tracks
        audioSource.Play();
    }

    void ShufflePlaylist()
    {
        for (int i = playlist.Length - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            AudioClip temp = playlist[i];
            playlist[i] = playlist[rand];
            playlist[rand] = temp;
        }
    }
}

