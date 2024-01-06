using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnInhabitant : MonoBehaviour
{
    public GameObject spawnInhabitant;
    public GameObject pointOne;
    public GameObject pointTwo;
    public GameObject pointTree;
    public GameObject pointFour;
    private bool spawning = true;

    void Update()
    {
        if (Noise.MaxScaleNoise && spawning && (Movement.score <= (Movement.MaxCount / 4)))
        {
            Instantiate(spawnInhabitant, pointOne.transform.position, Quaternion.identity);
            Destroy(pointOne);
            spawning = false;
        }
        if ((Noise.MaxScaleNoise && spawning && 
            (Movement.score <= ((Movement.MaxCount / 4) * 2)) && Movement.score > (Movement.MaxCount / 4)) 
            || (Movement.isLight && (Movement.lightPrefab == "Light") && spawning))
        {
            Instantiate(spawnInhabitant, pointTwo.transform.position, Quaternion.identity);
            Destroy(pointTwo);
            spawning = false;
        }
        if ((Noise.MaxScaleNoise && spawning && (Movement.score <= 
            ((Movement.MaxCount / 4) * 3)) && Movement.score > ((Movement.MaxCount / 4) * 2)) ||
            (Movement.isLight && (Movement.lightPrefab == "Light1") && spawning))
        {
            Instantiate(spawnInhabitant, pointTree.transform.position, Quaternion.identity);
            Destroy(pointTree);
            spawning = false;
        }
        if (Noise.MaxScaleNoise && spawning && Movement.score <= Movement.MaxCount && Movement.score > ((Movement.MaxCount / 4) * 3))
        {
            Instantiate(spawnInhabitant, pointFour.transform.position, Quaternion.identity);
            Destroy(pointFour);
            spawning = false;
        }
    }
}
