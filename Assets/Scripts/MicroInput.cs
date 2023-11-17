using UnityEngine;

public class MicInput : MonoBehaviour
{
    AudioClip micClip;
    AudioSource audioSource;

    public float tiempoDeGrabacion = 10f; // Ajusta el tiempo de grabación según tus necesidades

    void Start()
    {
        // Obtén el nombre del dispositivo de micrófono predeterminado
        string micDevice = Microphone.devices.Length > 0 ? Microphone.devices[0] : null;

        if (micDevice != null)
        {
            // Inicia la captura de audio desde el micrófono
            micClip = Microphone.Start(micDevice, true, Mathf.CeilToInt(tiempoDeGrabacion), AudioSettings.outputSampleRate);

            // Espera a que la captura de audio se inicie
            //while (!(Microphone.GetPosition(micDevice) > 0)) { }

            // Crea un AudioSource para reproducir el audio capturado
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = micClip;

            // No reproduzcas el audio (comenta o elimina la siguiente línea si deseas reproducirlo)
            // audioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró ningún dispositivo de micrófono.");
        }
    }

    void Update()
    {
        // Detén la reproducción después de un tiempo determinado
        if (Time.timeSinceLevelLoad >= tiempoDeGrabacion)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void OnDisable()
    {
        // Detén la captura de audio cuando el objeto se desactiva
        if (micClip != null)
        {
            Microphone.End(null);
        }
    }
}
