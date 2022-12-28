using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level Select";
    public SceneTransition transition;
    public void Play()
    {
        transition.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}