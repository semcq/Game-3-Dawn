using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawn : MonoBehaviour
{

    private float delay = 0f;
    public float delayHigh;
    public GameObject battery;                // The enemy prefab to be spawned.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private bool spawnBattery = true;

    public AudioClip batterySpawnSound;

    void Start()
    {
        
    }


    void Update()
    {
        delay += Time.deltaTime;

        if (delay > delayHigh && spawnBattery)
        {
            Spawn();
            spawnBattery = false;
        }
        
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(battery, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        AudioSource.PlayClipAtPoint(batterySpawnSound, transform.position, 1.0f);
    }
}
