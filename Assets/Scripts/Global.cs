using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{   
    public GameObject mysteryAlien;
    public GameObject powerUp;
    public static float minBound = -20.5f;
    public static float maxBound = 20.5f;
    public int score;
    public int highScore;
    public int lives;
    public bool poweredUp;
    public bool gameOver;
    public bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0f,0f,-9.81f);
        score = 0;
        highScore = PlayerPrefs.GetInt("High Score");;
        lives = 3;
        poweredUp = false;
        gameOver = false;
        gameWon = false;
        Spawn();
    }

    void Spawn()
    {
        Vector3 spawnPos = new Vector3(-30f, 0, 10f);
        if (!poweredUp) 
        {
            if (Random.Range(0f, 10.0f) < 5f)
            {
                Instantiate(mysteryAlien, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(powerUp, spawnPos, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(mysteryAlien, spawnPos, Quaternion.identity);
        }
        float spawnTime = Random.Range(10f, 20f);
        Invoke("Spawn", spawnTime);
    }
}
