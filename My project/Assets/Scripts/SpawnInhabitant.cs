using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnInhabitant : MonoBehaviour
{
    public GameObject spawnInhabitant;
    public GameObject spawnPoint;

    void Update()
    {
        if (Noise.MaxScaleNoise)
        {
            Instantiate(spawnInhabitant, spawnPoint.transform.position, Quaternion.identity);
            Destroy(spawnPoint);
        }

    }
}
