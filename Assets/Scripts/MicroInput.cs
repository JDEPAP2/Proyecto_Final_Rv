using UnityEngine;

public class MicInput : MonoBehaviour
{
    AudioClip micClip;
    AudioSource audioSource;

    public float tiempoDeGrabacion = 10f; // Ajusta el tiempo de grabaci�n seg�n tus necesidades

    void Start()
    {
        // Obt�n el nombre del dispositivo de micr�fono predeterminado
        string micDevice = Microphone.devices.Length > 0 ? Microphone.devices[0] : null;

        if (micDevice != null)
        {
            // Inicia la captura de audio desde el micr�fono
            micClip = Microphone.Start(micDevice, true, Mathf.CeilToInt(tiempoDeGrabacion), AudioSettings.outputSampleRate);

            // Espera a que la captura de audio se inicie
            //while (!(Microphone.GetPosition(micDevice) > 0)) { }

            // Crea un AudioSource para reproducir el audio capturado
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = micClip;

            // No reproduzcas el audio (comenta o elimina la siguiente l�nea si deseas reproducirlo)
            // audioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontr� ning�n dispositivo de micr�fono.");
        }
    }

    void Update()
    {
        // Det�n la reproducci�n despu�s de un tiempo determinado
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
        // Det�n la captura de audio cuando el objeto se desactiva
        if (micClip != null)
        {
            Microphone.End(null);
        }
    }
}
