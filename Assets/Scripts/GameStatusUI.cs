using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusUI : MonoBehaviour
{
    private Global globalObj;
    private Text gameOver;
    private Text restart;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        gameOver = GetComponent<Text>();
        restart = GameObject.Find("Restart").GetComponent<Text>();
        gameOver.enabled = false;
        restart.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalObj.gameWon) 
        {
            Time.timeScale = 0;
            gameOver.text = "You Won!";
            gameOver.enabled = true;
            restart.enabled = true;
        }
        else if (globalObj.gameOver)
        {
            Time.timeScale = 0;
            gameOver.text = "Game Over";
            gameOver.enabled = true;
            restart.enabled = true;
        }

        if (globalObj.score > globalObj.highScore)
        {
            PlayerPrefs.SetInt("High Score", globalObj.score);
            globalObj.highScore = globalObj.score;
        }
        
        if (Input.GetKeyDown("space") && (globalObj.gameWon || globalObj.gameOver))
        {
            Time.timeScale = 1;
            Application.LoadLevel("GameplayScene");
        }
    }
}
