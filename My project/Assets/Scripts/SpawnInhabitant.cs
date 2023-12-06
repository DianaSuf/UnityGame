using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInhabitant : MonoBehaviour
{
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Noise.MaxScaleNoise)
        {
            Debug.Log("Ўкала заполнена!");
        }

    }
}
