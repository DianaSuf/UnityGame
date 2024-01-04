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
    public GameObject GameOver;
    public GameObject GameWin;
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
        else if (TimeRemaining < 0 && Movement.score < Movement.MaxCount)
        {
            GameOver.SetActive(true);
        }
        else if (Movement.score == Movement.MaxCount)
        {
            
            GameWin.SetActive(true);
        }
    }
}
