using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    private Global globalObj;
    private Text livesText;

    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        livesText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        livesText.text = "Lives: " + globalObj.lives.ToString();
    }
}
