using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpawn : MonoBehaviour
{
    private float timer;
    public GameObject icon;
    void Start()
    {
        timer = 1f;
    }

    void Update()
    {
        if (SpawnInhabitant.isSpawn)
        {
            icon.SetActive(true);
            //timer -= Time.deltaTime;
            //icon.SetActive(false);
            //timer = 1f;
            Debug.Log(SpawnInhabitant.countSpawn);
        }
        else
        {
            icon.SetActive(false);
            Debug.Log(SpawnInhabitant.countSpawn);
        }

    }
}
