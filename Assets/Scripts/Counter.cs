using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    public float seconds;
    private float time;
    public UnityEvent onTimeFinished, onTimerPaused, onTimerUnpaused, onTimerRestarted;
    TextMeshProUGUI txt;
    Coroutine coroutine;

    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        coroutine = StartCoroutine(Timer(seconds));
    }

    public void PauseTimer(bool state)
    {
        if (state)
        {
            StopCoroutine(coroutine);
            onTimerPaused.Invoke();
        }
        else
        {
            coroutine = StartCoroutine(Timer(time));
            onTimerUnpaused.Invoke();
        }
    }

    public void ResetTimer()
    {
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(Timer(seconds));
        onTimerRestarted.Invoke();
    }


    IEnumerator Timer(float seconds)
    {
        time = seconds;
        while(time > 0)
        {
            time--;
            txt.SetText(time.ToString());
            yield return new WaitForSeconds(1);
        }
        
        onTimeFinished.Invoke();
    }
}
