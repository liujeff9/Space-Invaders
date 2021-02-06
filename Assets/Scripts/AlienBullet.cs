using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    private Transform alienBullet;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        alienBullet = gameObject.transform;
        speed = .35f;
    }

    void FixedUpdate()
    {
        alienBullet.position += Vector3.forward * -1 * speed;

        if (alienBullet.position.z <= -25)
        {
            Destroy(gameObject);
        }
        else if (alienBullet.position.z <= -10)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Collider>().isTrigger = false;
            if (Random.Range(0f, 10.0f) < 5f)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 2);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 2);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Base")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
