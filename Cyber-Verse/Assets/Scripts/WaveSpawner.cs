using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 3f;
    private int WaveNumber = 0;
    public Text waveCountDownText;
    public GameManager gameManager;

    public Button Continuebtn;
    public bool TimerOn = false;

    
    //When I hit the continue button, the update function will start
    public void Continue()
    {
        TimerOn = true;

        if (TimerOn == true)
        {
            Continuebtn.interactable = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {

        if (EnemiesAlive > 0)
        {
            TimerOn = false;
            Continuebtn.interactable = false;
            //return;
        }
        else
        {
            Continuebtn.interactable = true;
        }

        if (WaveNumber == waves.Length)
        {
            gameManager.LevelWon();
            this.enabled = false;//Disable this script
        }

        if (TimerOn == true)
        {

            if (countdown <= 0)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;//Dont want the timer to keep going from zero
                return;


            }
            
            else
            {
                Continuebtn.interactable = false;
            }
            

            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);// Keeps the countdown from being less than 0

            waveCountDownText.text = string.Format("{0:00.00}", countdown);

        }
    }
    

    
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;
        Wave wave = waves[WaveNumber]; //get current wave we want to spawn

        for (int z = 0; z < wave.enemies.Length; z++)
        {
            for (int i = 0; i < wave.enemies[z].count; i++)
            {
                SpawnEnemy(wave.enemies[z].enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
            if (WaveNumber == waves.Length)
            {
                this.enabled = false;
            }
        }
        WaveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
    
}
