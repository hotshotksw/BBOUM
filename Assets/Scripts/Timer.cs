using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    enum TimerType {COUNTDOWN, STOPWATCH}
    [SerializeField] private TimerType timerType;
    [SerializeField] public float timeToDisplay = 60.0f;

    private bool isRunning;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }

    private void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }

    private void EventManagerOnTimerStart() => isRunning = true;
    private void EventManagerOnTimerUpdate(float value) => timeToDisplay += value;
    private void EventManagerOnTimerStop() => isRunning = false;

    private void Update()
    {
        if (!isRunning) return;
        if (timerType == TimerType.COUNTDOWN && timeToDisplay < 0.0f)
        {
            EventManager.OnTimerStop();
            return;
        }
        timeToDisplay += timerType == TimerType.COUNTDOWN ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = timeSpan.ToString(format:@"mm\:ss\:ff");
    }
}
