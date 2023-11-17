using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aud : MonoBehaviour
{
    private AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = transform.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aud.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        aud.Stop();
    }
}
