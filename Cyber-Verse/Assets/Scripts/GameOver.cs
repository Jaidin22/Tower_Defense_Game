using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class GameOver : MonoBehaviour
{
    public string menuScene = "Main Menu";
    public void Retry()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
