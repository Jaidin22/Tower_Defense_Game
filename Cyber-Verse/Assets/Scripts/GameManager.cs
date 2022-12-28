using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded;
    public GameObject gameoverUI;
    public GameObject levelCompleteUI;

    private void Start()
    {
        gameEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame(); 
            
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameoverUI.SetActive(true);
    }

    public void LevelWon()
    {
        gameEnded = true;
        levelCompleteUI.SetActive(true);
    }
}
