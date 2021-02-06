using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParent : MonoBehaviour
{
    private Global globalObj;
    private Transform bases;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find ("GlobalObject");
        globalObj = g.GetComponent<Global>();
        bases = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bases.childCount == 0)
        {
            globalObj.gameOver = true;
        }
    }
}
