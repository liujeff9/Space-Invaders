using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryAlien : MonoBehaviour
{
    private Global globalObj;
    public AudioClip alienKnell;
    public GameObject deathExplosion;

    private Transform mysteryAlien;
    public float speed;

    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        mysteryAlien = gameObject.transform;
        speed = .15f;
    }

    void FixedUpdate()
    {
        mysteryAlien.position += Vector3.right * speed;
        if (mysteryAlien.position.x >= 30)
        {
            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        globalObj.score += Random.Range(30, 100);

        // update physics and detach from parent
        AudioSource.PlayClipAtPoint(alienKnell, gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right) );
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Collider>().isTrigger = false;
        gameObject.transform.parent = null;

        if (Random.Range(0f, 10.0f) < 5f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 10);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * -10);
        }
    }
}
