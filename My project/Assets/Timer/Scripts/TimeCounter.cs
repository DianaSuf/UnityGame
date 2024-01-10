using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TimeCounter : MonoBehaviour
{
    public float MaxTime;
    public static float TimeRemaining;
    public TextMeshProUGUI time;
    public GameObject Stars3;
    public GameObject Stars2;
    public GameObject Stars1;
    public GameObject Stars0;
    public static int snow;
    public static bool snowslv;
    public static bool menuStars = false;
    private int stars;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        TimeRemaining = MaxTime;
        snowslv = true;
        stars = PlayerPrefs.GetInt("level1");
    }

    void Update()
    {
        //PlayerPrefs.DeleteAll();
        float minutes, seconds;
        if (TimeRemaining > 0 && Movement.score <= Movement.MaxCount)
        {
            minutes = Mathf.FloorToInt(TimeRemaining / 60);
            seconds = Mathf.FloorToInt(TimeRemaining - minutes * 60f);
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            TimeRemaining -= Time.deltaTime;
        }
        if ((TimeRemaining < 0 && Movement.score < 3 && snowslv) || 
            (TimeRemaining > 0 && Movement.score < 3 && snowslv && Movement.isFinish) ||
            (TimeRemaining > 0 && Movement.score < 3 && snowslv && Movement.isEnemy))
        {
            
            Stars0.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 0);
            snow = PlayerPrefs.GetInt("snow");
            snowslv = false;
            menuStars = true;
            if (stars <= 0) PlayerPrefs.SetInt("level1", 0);
        }
        if ((TimeRemaining < 0 && 3 <= Movement.score && Movement.score < 6 && snowslv) 
            || (TimeRemaining > 0 && 3 <= Movement.score && Movement.score < 6 && snowslv && Movement.isFinish)
            || (TimeRemaining > 0 && 3 <= Movement.score && Movement.score < 6 && snowslv && Movement.isEnemy))
        {
            Stars1.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 5);
            snow = PlayerPrefs.GetInt("snow");
            snowslv = false;
            menuStars = true;
            if (stars <= 1) PlayerPrefs.SetInt("level1", 1);
        }
        if ((TimeRemaining < 0 && 6 <= Movement.score && Movement.score < 9 && snowslv) 
            || (TimeRemaining > 0 && 6 <= Movement.score && Movement.score < 9 && snowslv && Movement.isFinish)
            || (TimeRemaining > 0 && 6 <= Movement.score && Movement.score < 9 && snowslv && Movement.isEnemy))
        {
            Stars2.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 10);
            snow = PlayerPrefs.GetInt("snow");      
            snowslv = false;
            menuStars = true;
            if (stars <= 2) PlayerPrefs.SetInt("level1", 2);
        }
        if ((TimeRemaining < 0 && Movement.score == 9 && snowslv) || 
            (TimeRemaining > 0 && Movement.score == 9 && snowslv && Movement.isFinish) ||
            (TimeRemaining > 0 && Movement.score == 9 && snowslv && Movement.isEnemy))
        {
            Stars3.SetActive(true);
            Time.timeScale = 0f;
            snow = PlayerPrefs.GetInt("snow");
            PlayerPrefs.SetInt("snow", snow + 15);
            snow = PlayerPrefs.GetInt("snow");
            snowslv = false;
            menuStars = true;
            if (stars <= 3) PlayerPrefs.SetInt("level1", 3);
        }
        //getSnow();
    }

    //private void getSnow()
    //{
    //    int current = 0;
    //    if (Movement.score < 3)
    //    {
    //        current = 0;
    //    }
    //    if (3 <= Movement.score && Movement.score < 6)
    //    {
    //        current = 5;
    //    }
    //    if (6 <= Movement.score && Movement.score < 9)
    //    {
    //        current = 10;
    //    }
    //    if (Movement.score == 9)
    //    {
    //        current = 15;
    //    }
    //    snow = PlayerPrefs.GetInt("snow");
    //    PlayerPrefs.SetInt("snow", snow + current);
    //}
    //private void getPopap ()
    //{
    //    if (TimeRemaining < 0 && Movement.score < 3)
    //    {
    //        Stars0.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //    if (TimeRemaining < 0 && 3 <= Movement.score && Movement.score < 6)
    //    {
    //        Stars1.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //    if (TimeRemaining < 0 && 6 <= Movement.score && Movement.score < 9)
    //    {
    //        Stars2.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //    if (TimeRemaining < 0 && Movement.score == 9)
    //    {
    //        Stars3.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //}
}
