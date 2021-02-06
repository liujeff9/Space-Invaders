using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Global globalObj;
    public AudioClip hitKnell;

    private Transform powerUp;
    private float speed;

    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        powerUp = gameObject.transform;
        speed = .15f;
    }

    void FixedUpdate()
    {
        powerUp.position += Vector3.right * speed;
        if (powerUp.position.x >= 30)
        {
            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        globalObj.score += Random.Range(30, 50);
        globalObj.poweredUp = true;
        AudioSource.PlayClipAtPoint(hitKnell, gameObject.transform.position);
        Destroy(gameObject);
    }
}
