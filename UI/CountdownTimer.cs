using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public UnityEvent onTimerFinished;

    private float remainingTime;
    private float initialTime;
    private string timeFormat;
    private bool running;
    private string prefix;
    private string singularPrefix;
    private string timeUpMsg;
    [ContextMenu("StartTimer")]
    public void test()
    {
        StartTimer(5,"ss"," SECONDS"," SECOND");
    }

    void Update()
    {
        if (!running)
        {
            return;
        }

        remainingTime -= Time.deltaTime;
        UpdateText();
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            running = false;
            text.text = timeUpMsg;
            onTimerFinished?.Invoke();
            return;
        }

        
    }

    public void PrimeTimer(float timeInSeconds, string format = @"ss", string prefix = "", string singularPrefix = "")
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(timeInSeconds);
        if ((int)remainingTime == 1)
        {
            
            text.text = t.ToString(format)+singularPrefix;

        }
        else
        {
            text.text = t.ToString(format) + prefix;
        }
    }

    public bool StartTimer(float timeInSeconds, string format=@"ss", string prefix = "", string singularPrefix = "", string TimeUpMsg = "TIMES UP")
    {
        if (running)
        {
            return false;
        }

        this.prefix = prefix;
        initialTime = timeInSeconds;
        remainingTime = timeInSeconds;
        timeFormat = format;
        running = true;
        if (singularPrefix == "")
        {
            this.singularPrefix = prefix;
        }
        else
        {
            this.singularPrefix = singularPrefix;
        }

        UpdateText();
        this.timeUpMsg = TimeUpMsg;
        return true;
    }

    public void StopTimer()
    {
        running = false;
    }

    public void ResetTimer()
    {
        running = false;
        remainingTime = initialTime;
        UpdateText();
    }

    public bool IsRunning()
    {
        return running;
    }

    private void UpdateText()
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(remainingTime);
        if ((int)remainingTime == 1)
        {
            
            text.text = t.ToString(timeFormat)+singularPrefix;

        }
        else
        {
            text.text = t.ToString(timeFormat) + prefix;
        }
        
        
    }
}