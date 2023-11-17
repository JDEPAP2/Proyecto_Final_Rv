using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class Micro : MonoBehaviour
{
    [SerializeField] float amplitude = 0, maxAmplitude = 0.0f;
    private float old = 0;
    [Range(0f, 100f)]
    public float sensibility = 1f;
    public ConfigAudio config;
    private float[] audioData = new float[1024];
    private AudioSource audioSource;
    public AudioMixerGroup mixer;
    public UnityEvent onAmplitudGreatherThanMax;
    public UnityEvent<float> onAmplitudeChange;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        initMicro();
    }

    private void FixedUpdate()
    {
        audioSource.GetOutputData(audioData,0);
        float maxValue = audioData[0];
        for (int i = 0; i < audioData.Length; i += 2)
        {
            if(maxValue < Mathf.Abs(audioData[i]))
            {
                amplitude = Mathf.Abs(audioData[i]) * sensibility;
                if (amplitude > maxAmplitude) { amplitude = maxAmplitude; }
            }
            
        }

        float value = amplitude / maxAmplitude;
        onAmplitudeChange.Invoke(value);

        if (value > 0.9)
        {
            onAmplitudGreatherThanMax.Invoke();
        }

        old = amplitude;

    }

    public void initMicro()
    {
        Microphone.End(config.activeMicro);
        if (config.activeMicro == null || config.activeMicro.Length == 0)
        {
            enabled = false;
        }
        else
        {
            audioSource.clip = Microphone.Start(config.activeMicro, true, 1, 33200);
            audioSource.outputAudioMixerGroup = mixer;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void OnDisable()
    {
        audioSource?.Stop();
        Microphone.End(config.activeMicro);
    }

    private void OnDestroy()
    {
        audioSource?.Stop();
        Microphone.End(config.activeMicro);
    }
}
