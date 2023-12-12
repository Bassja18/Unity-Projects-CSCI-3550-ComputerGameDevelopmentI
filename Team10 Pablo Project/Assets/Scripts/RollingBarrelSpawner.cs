using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBarrelSpawner : MonoBehaviour
{
    //Object to spawn
    public GameObject prefab;
    public float spawnRate = 4f;

    float timeOfLastSpawn = 0f;

    bool spawnerActive = false;

    //Only allows spawning if visible by camera
    void OnBecameVisible()
    {
        spawnerActive = true;
    }

    void OnBecameInvisible()
    {
        spawnerActive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerActive) {
            // If it is time to spawn another barrel, reset cooldown and spawn one
            if (Time.time - timeOfLastSpawn > spawnRate)
            {
                timeOfLastSpawn = Time.time;
                Instantiate(prefab, transform);
            }
        }
    }
}
