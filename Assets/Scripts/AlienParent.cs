using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienParent : MonoBehaviour
{
    public AudioClip shotKnell;

    public GameObject alienBullet;
    public GameObject bossAlien;
    private Global globalObj;
    private Transform alienParent;
    private float distance;
    public int bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        alienParent = gameObject.transform;
        distance = .5f;
        bossHealth = 5;
        InvokeRepeating("Move", .5f, .25f);
    }

    void Move()
    {
        alienParent.position += Vector3.right * distance;

        bool fired = false;
        foreach (Transform alien in alienParent)
        {
            // if an alien in on the edge, switch directions and move down
            if (alien.position.x < Global.minBound || alien.position.x > Global.maxBound)
            {
                distance *= -1;
                alienParent.position += Vector3.forward * -1;
                return;
            }

            // randomly fire bullets
            if ((Random.Range(0f, 50.0f) < 1f && !fired) || (Random.Range(0f, 25.0f) < 1f && bossHealth < 4))
            {
                AudioSource.PlayClipAtPoint(shotKnell, gameObject.transform.position);

                Vector3 spawnPos = alien.position;
                spawnPos.z -= 1f;
                Instantiate(alienBullet, spawnPos, Quaternion.Euler(90, 0, 0));
                fired = true;
            }
        }

        if (bossHealth <= 0)
        {
            globalObj.gameWon = true;
        }
        if (alienParent.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("Move", .1f, .25f);
        }
        else if (alienParent.childCount == 0)
        {
            GameObject boss = Instantiate(bossAlien, alienParent.position, Quaternion.Euler(90, 0, 0));
            boss.transform.SetParent(alienParent);
        }
    }

    void GameWon()
    {
        globalObj.gameWon = true;
    }
}
