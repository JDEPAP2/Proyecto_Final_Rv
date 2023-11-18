using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Security : MonoBehaviour
{
    public UnityEvent onAlert;
    public AudioSource aud;
    public bool wall;
    
    public void startAlarm(Collider c)
    {
        if (c.CompareTag("Player") && !wall)
        {
            if (!aud.isPlaying)
            {
                aud.Play();
                onAlert.Invoke();
            }
        }
    }

    public void checkEnterHide(Collider c)
    {
        if (c.CompareTag("Wall"))
        {
            wall = true;
        }
    }

    public void checkExitHide(Collider c)
    {
        if (c.CompareTag("Wall"))
        {
            wall = false;
        }
    }
}
