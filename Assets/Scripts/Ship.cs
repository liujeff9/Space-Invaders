using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Transform player;
    private float speed;

    public AudioClip fireKnell;
    public GameObject bullet;
    private float fireRate;
    private float nextFire; 

    public GameObject deathExplosion;
    public AudioClip rumbleKnell;
    private Camera mainCam;
    private Vector3 initialPosition;
    private float duration = .25f;
    private float magnitude = 1f;

    private Global globalObj;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        player = gameObject.transform;
        fireRate = .5f;
        mainCam = Camera.main;
        NormalSpeed();
    }

    void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        
        if (player.position.x < Global.minBound && direction < 0)
        {
            direction = 0;
        }
        else if (player.position.x > Global.maxBound && direction > 0)
        {
            direction = 0;
        }

        player.position += Vector3.right * direction * speed;
    }

    void Update() 
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            AudioSource.PlayClipAtPoint(fireKnell, gameObject.transform.position);
            nextFire = Time.time + fireRate;
            Vector3 spawnPos = player.position;
            spawnPos.z += 1f;
            if (!globalObj.poweredUp)
            {
                Instantiate(bullet, spawnPos, Quaternion.Euler(90, 0, 0));
            }
            else
            {
                spawnPos.x -= .5f;
                Instantiate(bullet, spawnPos, Quaternion.Euler(90, 0, 0));
                spawnPos.x += 1f;
                Instantiate(bullet, spawnPos, Quaternion.Euler(90, 0, 0));
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "AlienBullet")
        {
            Shake();
            AudioSource.PlayClipAtPoint(rumbleKnell, gameObject.transform.position);

            globalObj.lives -= 1;
            if (globalObj.lives <= 0)
            {
                Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
                Destroy(gameObject);
                globalObj.gameOver = true;
            }
            Destroy(other.gameObject);
        }
    }

    void Shake()
    {
        initialPosition = mainCam.transform.position;
        InvokeRepeating("Shaking", 0f, .005f);
        Invoke("Stop", duration);
    }

    void Shaking()
    {
        float x = Random.Range(-1f, 1f) * magnitude;
        float z = Random.Range(-1f, 1f) * magnitude;
        mainCam.transform.position = new Vector3(x, initialPosition.y, z);
    }

    void Stop()
    {
        CancelInvoke("Shaking");
        mainCam.transform.position = initialPosition;
    }
    
    public void SlowSpeed()
    {
        speed = .10f;
    }

    public void NormalSpeed()
    {
        speed = .25f;
    }
}
