using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigAudio : MonoBehaviour
{
    public string activeMicro;
    // Start is called before the first frame update
    void Awake()
    {

        foreach (var micro in Microphone.devices)
        {
            Debug.Log("Microfono Disponible: " + micro);
        }

        activeMicro = Microphone.devices[2];
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
