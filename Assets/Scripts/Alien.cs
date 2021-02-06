using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Global globalObj;
    private bool died;
    public AudioClip alienKnell;
    public GameObject deathExplosion;
    public int points;
    
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        died = false;
    }

    void Update()
    {
        if (gameObject.transform.position.z <= -25)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ship") {
            other.gameObject.GetComponent<Ship>().SlowSpeed();
        }
        else if (other.gameObject.tag == "Base" && !died)
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Ship") {
            other.gameObject.GetComponent<Ship>().NormalSpeed();
        }
    }

    public void Hit()
    {
        if (!died)
        {
            globalObj.score += gameObject.GetComponent<Alien>().points;

            // update physics and detach from parent
            AudioSource.PlayClipAtPoint(alienKnell, gameObject.transform.position);
            Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right) );
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            gameObject.transform.parent = null;

            if (Random.Range(0f, 10.0f) < 5f)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 10);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * -10);
            }

            died = true;
        }
    }
}
