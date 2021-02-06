using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip alienKnell;

    private Global globalObj;
    private Transform bullet;
    private Vector3 thrust;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        thrust.y = 1250.0f;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.z >= 25)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Alien")
        {
            other.gameObject.GetComponent<Alien>().Hit();
            other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(thrust);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "BossAlien")
        {
            other.gameObject.transform.parent.gameObject.GetComponent<AlienParent>().bossHealth -= 1;
            globalObj.score += Random.Range(50, 150);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "MysteryAlien")
        {
            other.gameObject.GetComponent<MysteryAlien>().Hit();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "PowerUp")
        {
            other.gameObject.GetComponent<PowerUp>().Hit();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Base")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "AlienBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
