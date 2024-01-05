using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TimeCounter : MonoBehaviour
{
    public float MaxTime = 10f;
    public static float TimeRemaining;
    public TextMeshProUGUI time;
    public GameObject Stars3;
    public GameObject Stars2;
    public GameObject Stars1;
    public GameObject Stars0;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        TimeRemaining = MaxTime;
    }

    void Update()
    {
        float minutes, seconds;
        if (TimeRemaining > 0 && Movement.score < Movement.MaxCount)
        {
            minutes = Mathf.FloorToInt(TimeRemaining / 60);
            seconds = Mathf.FloorToInt(TimeRemaining - minutes * 60f);
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            TimeRemaining -= Time.deltaTime;
        }
        else if (TimeRemaining < 0 && Movement.score < 3)
        {
            Stars0.SetActive(true);
        }
        else if (TimeRemaining < 0 && 3 <= Movement.score && Movement.score < 6)
        {
            Stars1.SetActive(true);
        }
        else if (TimeRemaining < 0 && 6 <= Movement.score && Movement.score < 9)
        {
            Stars2.SetActive(true);
        }
        else if (TimeRemaining < 0 && Movement.score == 9)
        {
            Stars3.SetActive(true);
        }
    }
}
