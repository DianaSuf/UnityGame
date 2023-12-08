using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnInhabitant : MonoBehaviour
{
    public GameObject spawnInhabitant;
    public GameObject spawnPoint;
    private bool spawning = true;

    void Update()
    {
        if (Noise.MaxScaleNoise && spawning)
        {
            Instantiate(spawnInhabitant, spawnPoint.transform.position, Quaternion.identity);
            Destroy(spawnPoint);
            spawning = false;
        }

    }
}
