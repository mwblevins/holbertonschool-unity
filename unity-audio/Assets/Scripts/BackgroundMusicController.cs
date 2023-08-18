using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    private bool stopMusic;

    private void Awake()
    {
        bgmAudioSource = GetComponent<AudioSource>();
        bgmAudioSource.Play();
        bgmAudioSource.loop = true;

        stopMusic = false;
    }

    private void Update()
    {
        if (stopMusic)
        {
            bgmAudioSource.Stop();
        }
    }

    public void StopMusic()
    {
        stopMusic = true;
    }

    private void OnDestroy()
    {
        StopMusic();
    }
}
