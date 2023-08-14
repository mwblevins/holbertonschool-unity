using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private void Start() 
    {
        bgmAudioSource = GameObject.Find("BackgroundMusicManager").GetComponent<AudioSource>();
        bgmAudioSource.Play();
    }
    public void LevelSelect(int level)
    {
        string sceneName = "Level" + level.ToString("D2");
        bgmAudioSource.Stop();

        SceneManager.LoadScene(sceneName);
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
