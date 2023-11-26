using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject GameOver;
    public Text GameOverText;
    public Image TimerLine;
    private float MaxTime = 10f;
    public Text Counter;
    public static float TimeRemaining;
    public Text scoreText;

    void Start()
    {
        TimeRemaining = MaxTime;
    }

    void Update()
    {
        float time, minutes, seconds;
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
            TimerLine.fillAmount = TimeRemaining / MaxTime;
            time = TimeRemaining + 1;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time - minutes * 60f);
            Counter.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
        else if (TimeRemaining < 0 && !scoreText.text.Equals("All Collected!"))
        {
            GameOver.SetActive(true);
        }
        else
        {
            GameOverText.text = "     Win!";
            GameOver.SetActive(true);
        }
    }
}
