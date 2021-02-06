using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Global globalObj;
    private Text scoreText;

    void Start()
    {
        GameObject g = GameObject.Find ("GlobalObject");
        globalObj = g.GetComponent< Global >();
        scoreText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + globalObj.score.ToString();
    }
}
