using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public delegate void Method();

    private DateTime time;

    public static Method StartTimerDelegate;
    public static Method StopTimerDelegate;

    private void Start()
    {
        StartTimerDelegate = StartTimer;
        StopTimerDelegate = StopTimer;
    }

    public void StartTimer()
    {
        time = new DateTime();
        StartCoroutine(Timer());
    }

    public void StopTimer() 
    { 
        StopAllCoroutines();
    }

    private IEnumerator Timer()
    {   
        while (true)
        {
            time = time.AddSeconds(1);
            _timerText.text = time.ToString("HH:mm:ss"); 

            yield return new WaitForSeconds(1);
        }
    }
}
