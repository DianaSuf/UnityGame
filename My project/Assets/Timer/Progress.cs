using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public static float MaxCount;
    public static float RealCount;
    public Image ProgressScale;

    void Start()
    {
        
    }

    void Update()
    {
        MaxCount = Movement.MaxCount;//+1 �� ����� �� ���������--���� ����� ��������!!!
        if (TimeCounter.TimeRemaining > 0)
            GetProgress();
    }

    private void GetProgress () {
        RealCount = Movement.score;
        ProgressScale.fillAmount = RealCount / MaxCount;
    }
}
