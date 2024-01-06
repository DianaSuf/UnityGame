using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLight : MonoBehaviour
{
    public static bool isLight = false;
    public static string lightPrefab;

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isLight = true;
            lightPrefab = collision.name;
        }
    }
}
