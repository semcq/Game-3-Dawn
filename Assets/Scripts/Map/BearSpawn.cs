using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawn : MonoBehaviour
{
    private bool bearSpawn;
    public int bearHigh;

    private float delay = 0f;

    public Renderer rend;

    public AudioClip bearSpawnSound;
    public AudioClip bearPickupSound;

    void Start()
    {
        bearSpawn = false;

        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        System.Random rand = new System.Random();

        int bearSpawnNum = rand.Next(1, bearHigh);

        if (bearSpawnNum == 1 && bearSpawn == false)
        {
            rend.enabled = true;
            bearSpawn = true;

            AudioSource.PlayClipAtPoint(bearSpawnSound, transform.position, 1.0f);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.currFear -= 20;
            AudioSource.PlayClipAtPoint(bearPickupSound, transform.position, 1.0f);
            Destroy(gameObject);
        }
    }

}
