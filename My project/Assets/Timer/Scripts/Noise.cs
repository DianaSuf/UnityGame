using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Noise : MonoBehaviour
{
    private float Counter;
    public Image NoiseScale;
    private float MaxNoise;

    void Start()
    {
        Counter = 0f;
        MaxNoise = 14f;
    }

    void Update()
    {
        if (TimeCounter.TimeRemaining > 0 && Progress.MaxCount != Progress.RealCount)
        {
            if (!Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.W) 
                || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
                GetNoise();
            else if (Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
                GetSilenceWithCondition();
            else GetSilence();
        }
    }

    private void GetNoise()
    {
        if (Counter <= MaxNoise)
            Counter += 2f * Time.deltaTime;
        else Counter = MaxNoise;
        NoiseScale.fillAmount = Mathf.Lerp(NoiseScale.fillAmount, 0.2f + NoiseScale.fillAmount, Time.deltaTime);
    }

    private void GetSilenceWithCondition()
    {
        if (Counter > 0f)
            Counter -= Time.deltaTime;
        else Counter = 0f;
        NoiseScale.fillAmount = Mathf.Lerp(NoiseScale.fillAmount, NoiseScale.fillAmount - 0.05f, Time.deltaTime);
    }

    private void GetSilence()
    {
        if (Counter > 0f)
            Counter -= Time.deltaTime;
        else Counter = 0f;
        NoiseScale.fillAmount = Mathf.Lerp(NoiseScale.fillAmount, NoiseScale.fillAmount - 0.1f, Time.deltaTime);
    }
}
