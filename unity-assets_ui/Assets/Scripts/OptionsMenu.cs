using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private int previousSceneIndex;

    private void Start()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void Back()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}

