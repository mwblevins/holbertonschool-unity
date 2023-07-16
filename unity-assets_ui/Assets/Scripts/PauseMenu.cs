using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        pauseCanvas.SetActive(true); // Activate the PauseCanvas
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseCanvas.SetActive(false); 
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        Time.timeScale = 1f; 
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        Time.timeScale = 1f;
    }
}
