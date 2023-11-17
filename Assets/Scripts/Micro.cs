using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Micro : MonoBehaviour
{
    [SerializeField] float amplitude = 0, maxAmplitude = 0.0f;
    private float old = 0;
    [Range(0f, 100f)]
    public float sensibility = 1f;
    public ConfigAudio config;
    private float[] audioData = new float[1024];
    private AudioSource audioSource;

    public UnityEvent onAmplitudGreatherThanMax;
    public UnityEvent<float> onAmplitudeChange;


    

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Microphone.Start(config.activeMicro, true, 1, 22050);
        audioSource.loop = true;
    }

    private void FixedUpdate()
    {
        audioSource.clip.GetData(audioData, audioSource.timeSamples);
  
        float valorMax = Mathf.Abs(audioData[0]);
        for (int i = 0; i < audioData.Length; i += 2)
        {
            if (Mathf.Abs(audioData[i]) > valorMax)
            {
                valorMax = Mathf.Abs(audioData[i]);
                amplitude = valorMax*sensibility;
                if(amplitude > maxAmplitude) { amplitude = maxAmplitude; }
            }
        }

        //float value = amplitude / maxAmplitude;
        float value = Mathf.Lerp(old, amplitude, 0.4f) / maxAmplitude;
        onAmplitudeChange.Invoke(value);

        if (value > 0.9)
        {
            onAmplitudGreatherThanMax.Invoke();
        }

        old = amplitude;

    }

    void OnDisable()
    {
        audioSource.Stop();
        Microphone.End(null);
    }

    private void OnDestroy()
    {
        audioSource.Stop();
        Microphone.End(null);
    }
}
