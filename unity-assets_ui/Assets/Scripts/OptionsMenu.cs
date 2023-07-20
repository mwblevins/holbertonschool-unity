using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public static int previousSceneIndex;

    public void Back()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}

