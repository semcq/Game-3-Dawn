using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    private bool ghostSpawn;
    public static bool addTime;
    public int ghostHigh;

    private float delay = 0f;

    public Renderer rend;

    public AudioClip ghostSpawnSound;
    public AudioClip ghostDespawnSound;

    void Start()
    {
        ghostSpawn = false;
        addTime = false;

        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        System.Random rand = new System.Random();

        int ghostSpawnNum = rand.Next(1, ghostHigh);

        if (ghostSpawnNum == 1 && ghostSpawn == false)
        {
            rend.enabled = true;
            ghostSpawn = true;
            addTime = true;
            AudioSource.PlayClipAtPoint(ghostSpawnSound, transform.position, 1.0f);

        }

        if (ghostSpawn)
        {
            delay += Time.deltaTime;


            if (delay > 5.0f)
            {
                rend.enabled = false;
                AudioSource.PlayClipAtPoint(ghostDespawnSound, transform.position, 1.0f);
            }
        }
        }
}
