using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    public AudioSource aud;
    public bool wall;
    
    public void startAlarm(Collider c)
    {
        if (c.CompareTag("Player") && !wall)
        {
            if (!aud.isPlaying)
            {
                aud.Play();
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
