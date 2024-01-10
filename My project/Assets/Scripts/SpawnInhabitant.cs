using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnInhabitant : MonoBehaviour
{
    public GameObject spawnInhabitant;
    public GameObject pointOne;
    public GameObject pointTwo;
    public GameObject pointTree;
    public GameObject pointFour;
    //private bool spawning = true;
    private bool spawnLight = true;  

    void Update()
    {
        if (TimeCounter.TimeRemaining > 0 && !Movement.isFinish && !Movement.isEnemy)
        {
            if (Noise.MaxScaleNoise && (Movement.score <= (Movement.MaxCount / 4)))
            {
                Instantiate(spawnInhabitant, pointOne.transform.position, Quaternion.identity);
                //Destroy(pointOne);
                //spawning = false;
            }
            if ((Noise.MaxScaleNoise  &&
                (Movement.score <= ((Movement.MaxCount / 4) * 2)) && Movement.score > (Movement.MaxCount / 4))
                || (Movement.isLight && (Movement.lightPrefab == "Light") && spawnLight))
            {
                Instantiate(spawnInhabitant, pointTwo.transform.position, Quaternion.identity);
                spawnLight = false; 
                //Destroy(pointTwo);
                //spawning = false;
            }
            if ((Noise.MaxScaleNoise && (Movement.score <=
                ((Movement.MaxCount / 4) * 3)) && Movement.score > ((Movement.MaxCount / 4) * 2)) ||
                (Movement.isLight && (Movement.lightPrefab == "Light1") && spawnLight))
            {
                Instantiate(spawnInhabitant, pointTree.transform.position, Quaternion.identity);
                spawnLight = false;
                //Destroy(pointTree);
                //spawning = false;
            }
            if (Noise.MaxScaleNoise && Movement.score <= Movement.MaxCount && Movement.score > ((Movement.MaxCount / 4) * 3))
            {
                Instantiate(spawnInhabitant, pointFour.transform.position, Quaternion.identity);
                //Destroy(pointFour);
                //spawning = false;
            }
        } 
        //else
        //{
        //    Destroy(pointOne);
        //    Destroy(pointTwo);
        //    Destroy(pointTree);
        //    Destroy(pointFour);
        //    spawning = false;
        //}
    }
}
